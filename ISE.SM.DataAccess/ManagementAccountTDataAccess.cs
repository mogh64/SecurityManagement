using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class ManagementAccountTDataAccess : TDataAccess<ManagementAccount, ManagementAccountDto, ManagementAccountRepository>
    {
        public ManagementAccountTDataAccess()
            : base(new ManagementAccountRepository())
        {
        }
        public ManagementAccountDto CheckAccount(string userName, string password)
        {

            ManagementAccountDto dtoResult = new ManagementAccountDto();
            string hashed = ISE.Framework.Server.Common.Security.EncryptionAlgorithm.CreateMD5(password);
            var result = this.Repository.Context.ManagementAccounts.Where(it => it.UserName.Equals(userName) && it.Password.Equals(hashed)).FirstOrDefault();
            if (result != null )
            {

                dtoResult = ManagementAccountRepository.GetDto(result);
               
                return dtoResult;
            }


            return null;


        }
    }
}
