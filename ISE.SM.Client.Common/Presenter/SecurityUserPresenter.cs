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
    public class SecurityUserPresenter
    {
        private ServiceAdapter<ISecurityUserService> SecurityUserServiceAdapter;
        private ServiceAdapter<IMembershipProviderService> MembershipServiceAdapter;
        public SecurityUserPresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            SecurityUserServiceAdapter = new ServiceAdapter<ISecurityUserService>(exceptionManager);
            MembershipServiceAdapter = new ServiceAdapter<IMembershipProviderService>(exceptionManager);
        }
        public UserDtoContainer GetAll()
        {
            var result = (UserDtoContainer)SecurityUserServiceAdapter.Execute(s => s.GetAll());
            return result;
        }
        public UserDto Insert(UserDto securityUser)
        {

            UserDto result = (UserDto)SecurityUserServiceAdapter.Execute(s => s.Insert(securityUser));
            if (result.Response.HasException)
            {
                return null;
            }
            securityUser.UserId = result.UserId;
            return securityUser;
        }
        public bool Update(UserDto SecurityUser)
        {

            ResponseDto response = SecurityUserServiceAdapter.Execute(s => s.Update(SecurityUser));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool Remove(UserDto SecurityUser)
        {

            ResponseDto response = SecurityUserServiceAdapter.Execute(s => s.Delete(SecurityUser));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool AssignUserToRole(UserDto user, int roleId)
        {
            ResponseDto response = SecurityUserServiceAdapter.Execute(s => s.AssignUser(user, roleId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool DeAssignUserToRole(UserDto user, int roleId)
        {
            ResponseDto response = SecurityUserServiceAdapter.Execute(s => s.DeAssignUser(user, roleId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public List<AccountDto> GetUserAccounts(UserDto user)
        {
            var result = (AccountDtoContainer)MembershipServiceAdapter.Execute(s => s.GetUserAccounts(user));
            if (result.Response.HasException)
            {
                return null;
            }
            return result.AccountDtoList;
        }
        public List<int> GetUserRoleIds(long userId)
        {
            var result = SecurityUserServiceAdapter.Execute(s => s.GetUserRoleIds(userId));

            return result.RoleIdList;
        }
        public List<int> GetUserGroupIds(long userId)
        {
            var result = SecurityUserServiceAdapter.Execute(s => s.GetUserGroupIds(userId));

            return result.GroupIdList;
        }
    }
}
