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
using System.Threading.Tasks;

namespace ISE.SM.Client.Common.Presenter
{
    public class SecurityGroupPresenter
    {
        private ServiceAdapter<IGroupService> SecurityGroupServiceAdapter;
        public SecurityGroupPresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            SecurityGroupServiceAdapter = new ServiceAdapter<IGroupService>(exceptionManager);
        }
        public SecurityGroupDtoContainer GetAll()
        {
            var result = (SecurityGroupDtoContainer)SecurityGroupServiceAdapter.Execute(s => s.GetAll());
            return result;
        }
        public SecurityGroupDto Insert(SecurityGroupDto SecurityGroup)
        {

            SecurityGroupDto result = (SecurityGroupDto)SecurityGroupServiceAdapter.Execute(s => s.Insert(SecurityGroup));
            if (result.Response.HasException)
            {
                return null;
            }
            SecurityGroup.SecurityGroupId = result.SecurityGroupId;
            return SecurityGroup;
        }
        public List<UserDto> GetGroupUsers(SecurityGroupDto group)
        {
           var result = SecurityGroupServiceAdapter.Execute(s => s.AssignedUsers(group.SecurityGroupId));
           if (result.Response.HasException)
           {
               return null;
           }
           return result.UserDtoList;
        }
        public List<RoleDto> GetGroupRole(SecurityGroupDto group)
        {
            var result = SecurityGroupServiceAdapter.Execute(s => s.AssignedRoles(group.SecurityGroupId));
            if (result.Response.HasException)
            {
                return null;
            }
            return result.RoleDtoList;
        }

        public bool Update(SecurityGroupDto SecurityGroup)
        {

            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.Update(SecurityGroup));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool Remove(SecurityGroupDto SecurityGroup)
        {

            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.Delete(SecurityGroup));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool AssignUsers(List<UserDto> users, int groupId)
        {
            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.AssignUsers(users, groupId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool AssignRoles(List<RoleDto> roles, int groupId)
        {
            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.AssignRoles(roles, groupId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool DeAssignRoles(List<RoleDto> roles, int groupId)
        {
            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.DeAssignRoles(roles, groupId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool DeAssignUsers(List<UserDto> users, int groupId)
        {
            ResponseDto response = SecurityGroupServiceAdapter.Execute(s => s.DeAssignUsers(users, groupId));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
    }
}
