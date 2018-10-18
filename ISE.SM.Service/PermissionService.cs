using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class PermissionService : ContextBoundObject, IPermissionService
    {
        PermissionBussiness permissionBussiness = new PermissionBussiness();
        public Framework.Common.Service.Message.ResponseDto GrantUserPermission(Common.DTO.UserDto user, int permissionId)
        {
            return  permissionBussiness.GrantUserPermission(user, permissionId);
        }

        [Process(true)]
        public Framework.Common.Service.Message.ResponseDto RevokeUserPermission(Common.DTO.UserDto user, int permissionId)
        {
            return permissionBussiness.RevokeUserPermission(user, permissionId);
        }

        public Framework.Common.Service.Message.ResponseDto GrantRolePermission(Common.DTO.RoleDto role, int permissionId)
        {
            return  permissionBussiness.GrantRolePermission(role, permissionId);
        }

        public Framework.Common.Service.Message.ResponseDto RevokeRolePermission(Common.DTO.RoleDto role, int permissionId)
        {
            return permissionBussiness.RevokeRolePermission(role, permissionId);
        }

        public Common.DTOContainer.PermissionDtoContainer RolePermissions(Common.DTO.RoleDto role)
        {
            return permissionBussiness.RolePermissions(role);
        }

        public Common.DTOContainer.PermissionDtoContainer UserPermissions(Common.DTO.UserDto user)
        {
            return permissionBussiness.UserPermissions(user);
        }

        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            permissionBussiness.Delete((PermissionDto)dto);
            return ResponseBuilder.GetResponse(dto); 
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<PermissionDto> lst = dtoList.PersistanceList.Cast<PermissionDto>().ToList();
            permissionBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = permissionBussiness.GetAll();
            PermissionDtoContainer container = new PermissionDtoContainer()
            {
                PermissionDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<Permission>(predicate);
            PermissionDtoContainer container = new PermissionDtoContainer();
            var dtoResult = permissionBussiness.GetAll(pars);
            container.PermissionDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = permissionBussiness.GetSingle(it => it.PermissionId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            permissionBussiness.Insert((PermissionDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<PermissionDto> lst = dtoList.PersistanceList.Cast<PermissionDto>().ToList();
            permissionBussiness.Insert(lst);
            PermissionDtoContainer container = new PermissionDtoContainer()
            {
                PermissionDtoList = lst
            };
            return container;
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAllByCondition(string predicate, int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.Service.Message.ResponseDto Update(Framework.Common.CommonBase.BaseDto dto)
        {
            permissionBussiness.Update((PermissionDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<PermissionDto> lst = dtoList.PersistanceList.Cast<PermissionDto>().ToList();
            permissionBussiness.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }


        public PermissionToRoleConstraintDto AddPermissionToRoleConstraint(PermissionToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public PermissionToUserConstraintDto AddPermissionToUserConstraint(PermissionToUserConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public ResponseDto RemovePermissionToRoleConstraint(PermissionToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public ResponseDto RemovePermissionToUserConstraint(PermissionToUserConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public PermissionToRoleConstraintDto UpdatePermissionToRoleConstraint(PermissionToRoleConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public PermissionToUserConstraintDto UpdatePermissionToUserConstraint(PermissionToUserConstraintDto constraint)
        {
            throw new NotImplementedException();
        }

        public PermissionDtoContainer GetAllUserPermissions(long userId)
        {
            return permissionBussiness.GetAllUserPermissions(userId);
        }

        public PermissionDtoContainer GetCurrentUserPermissions(long userId)
        {
             return permissionBussiness.GetCurrentUserPermissions(userId);
        }


        public ResponseDtoContainer ChangeUserPermissons(List<PermissionDto> permissions, long userId)
        {
            return permissionBussiness.ChangeUserPermissons(permissions, userId);
        }
        public ResponseDtoContainer ChangeRolePermissons(List<PermissionDto> permissions, int roleId)
        {
            return permissionBussiness.ChangeRolePermissons(permissions, roleId);
        }

        public PermissionDtoContainer GetGroupPermissions(int groupId)
        {
            return permissionBussiness.GetGroupPermissions(groupId);
        }


        public PermissionDtoContainer GetRolePermissions(int roleId)
        {
            return permissionBussiness.GetRolePermissions(roleId);
        }


        public PermissionDtoContainer GetCurrentRolePermissions(int roleId)
        {
            return permissionBussiness.GetCurrentRolePermissions(roleId);
        }

        public PermissionDtoContainer GetAllRolePermissions(int roleId)
        {
            return permissionBussiness.GetAllRolePermissions(roleId);
        }
    }
}
