using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class MembershipProviderService :ContextBoundObject, IMembershipProviderService
    {
        SecurityUserBussiness userBussiness = new SecurityUserBussiness();
        public Framework.Common.Service.Message.ResponseDto RegisterUser(Common.DTO.UserDto userMember)
        {
            var response = userBussiness.RegisterUser(userMember);
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto UnRegisterUser(Common.DTO.UserDto userMember)
        {
            var response = userBussiness.UnRegisterUser(userMember);
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto AssignAccountAppDomain(Common.DTO.AccountDto account, int appDomain)
        {
            var response = userBussiness.AssignAccountAppDomain(account,appDomain);
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeAssignAccountAppDomain(Common.DTO.AccountDto account, int appDomain)
        {
            var response = userBussiness.DeAssignAccountAppDomain(account, appDomain);
            return response;
        }

        public Common.DTOContainer.AccountDtoContainer GetUserAccounts(Common.DTO.UserDto userMember)
        {
            var response = userBussiness.GetUserAccounts(userMember);
            return response;
        }


        public Common.DTO.AccountDto CreateAccount(Common.DTO.AccountDto account, Common.DTO.UserDto user)
        {
            AccountBussiness accBs = new AccountBussiness();
            var response = accBs.CreateAccount(account, user);
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto DeleteAccount(Common.DTO.AccountDto account)
        {
            AccountBussiness accBs = new AccountBussiness();
            var response = accBs.DeleteAccount(account);
            return response;
        }


        public Framework.Common.Service.Message.ResponseDto UpdateAccount(Common.DTO.AccountDto account)
        {
            AccountBussiness accBs = new AccountBussiness();
            var response = accBs.UpdateAccount(account);
            return response;
        }


        public AccountDto ChangePassword(string userName, string newPassword, string currentPassword)
        {
            AccountBussiness accBs = new AccountBussiness();
            var response = accBs.ChangePassword(userName, currentPassword, newPassword);
            return response;
        }

        public AccountDto ResetPassword(string userName, long userId)
        {
            AccountBussiness accBs = new AccountBussiness();
            var response = accBs.ResetPassword(userName, userId);
            return response;
        }
    }
}
