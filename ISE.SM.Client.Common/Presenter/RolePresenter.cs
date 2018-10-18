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
    public class RolePresenter
    {
        private ServiceAdapter<IRoleService> RoleServiceAdapter;
        public RolePresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            RoleServiceAdapter = new ServiceAdapter<IRoleService>(exceptionManager);
        }
        public RoleDtoContainer GetAll()
        {
            var result = (RoleDtoContainer)RoleServiceAdapter.Execute(s => s.GetAll());
            return result;
        }
        public List<UserDto> GetRoleUsers(RoleDto role)
        {
             var result = RoleServiceAdapter.Execute(s => s.AssignedUsers(role));
             if (result.Response.HasException)
             {
                 return null;
             }
             return result.UserDtoList;
        }
        public List<SecurityGroupDto> GetRoleGroups(RoleDto role)
        {
            var result = RoleServiceAdapter.Execute(s => s.RoleGroups(role));
            if (result.Response.HasException)
            {
                return null;
            }
            return result.SecurityGroupDtoList;
        }
        public RoleDto Insert(RoleDto Role)
        {

            RoleDto result = (RoleDto)RoleServiceAdapter.Execute(s => s.Insert(Role));
            if (result.Response.HasException)
            {
                return null;
            }
            Role.RoleId = result.RoleId;
            return Role;
        }
        public bool Update(RoleDto Role)
        {

            ResponseDto response = RoleServiceAdapter.Execute(s => s.Update(Role));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool Remove(RoleDto Role)
        {

            ResponseDto response = RoleServiceAdapter.Execute(s => s.Delete(Role));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
    }
}
