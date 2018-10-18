using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.Common.Presenter
{
    public class AccountPresenter
    {
        private ServiceAdapter<IMembershipProviderService> MembershipProviderServiceAdapter;
        public AccountPresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            MembershipProviderServiceAdapter = new ServiceAdapter<IMembershipProviderService>(exceptionManager);
        }
        public AccountDto CreateAccount(AccountDto account, UserDto user)
        {
            var result = MembershipProviderServiceAdapter.Execute(it => it.CreateAccount(account, user));
            if (result.Response.HasException)
            {
                return null;
            }
            account.AccountId = result.AccountId;
            return result;
        }
        public ResponseDto DeleteAccount(AccountDto account)
        {
            var result = MembershipProviderServiceAdapter.Execute(it => it.DeleteAccount(account));
            if (result.Response.HasException)
            {
                return null;
            }
          
            return result;
        }
        public ResponseDto UpdateAccount(AccountDto account)
        {
            var result = MembershipProviderServiceAdapter.Execute(it => it.UpdateAccount(account));
            if (result.Response.HasException)
            {
                return null;
            }

            return result;
        }
        public AccountDto ChangePassword(string userName, string newPassword, string currentPassword)
        {
            var result = MembershipProviderServiceAdapter.Execute(it => it.ChangePassword(userName, newPassword, currentPassword));
            if (result.Response.HasException)
            {
                return null;
            }

            return result;
        }
        public AccountDto ResetPassword(string userName, long userId)
        {
            var result = MembershipProviderServiceAdapter.Execute(it => it.ResetPassword(userName, userId));
            if (result.Response.HasException)
            {
                return null;
            }

            return result;
         
        }
    }
}
