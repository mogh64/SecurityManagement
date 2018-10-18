using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Bussiness.Helper;
using ISE.SM.Common.DTO;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class ManagementAccountBussiness : BussinessBase<ManagementAccount, ManagementAccountDto>
    {
        public ManagementAccountBussiness()
        {
            this.dataAccess = new ManagementAccountTDataAccess();
        }
        public Common.Message.AuthenticationResult Authenticate(Common.Message.SignInMessage message)
        {
            Common.Message.AuthenticationResult result = new Common.Message.AuthenticationResult();
            var userAccount = ((ManagementAccountTDataAccess)this.dataAccess).CheckAccount(message.UserName, message.Password);
            if (userAccount != null)
            {
                IdentityTokenGenerator generator = new IdentityTokenGenerator();
                var token = generator.GenerateToken(userAccount.MapToAccountDto(), message);
                result.IdentityToken = token;
                ManagementLogGenerator.GenerateManagementLog(userAccount.SecurityUserId, "Login", "ManagementService", 1, "success login", 0);
            }
            else
            {
                result.ErrorMessage = "اطلاعات حساب کاربری اشتباه است!";
                ManagementLogGenerator.GenerateManagementLog(userAccount.SecurityUserId, "Login", "ManagementService", 0, "failed login", 0);
            }

            return result;
        }
    }
}
