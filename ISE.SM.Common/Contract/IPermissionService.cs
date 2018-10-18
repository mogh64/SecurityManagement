using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.ServiceBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Contract
{
    [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IPermissionService : IServiceBase
    {
        
        [OperationContract]
        [Process]
        PermissionDtoContainer GetCurrentUserPermissions(long userId);
        [OperationContract]
        [Process]
        PermissionDtoContainer GetCurrentRolePermissions(int roleId);
        [OperationContract]
        [Process]
        PermissionDtoContainer GetAllRolePermissions(int roleId);
        [OperationContract]
        [Process]
        PermissionDtoContainer GetRolePermissions(int roleId);
        [OperationContract]
        [Process]
        PermissionDtoContainer GetGroupPermissions(int groupId);
        [OperationContract]
        [Process]
        PermissionDtoContainer GetAllUserPermissions(long userId);
        [OperationContract]
        [Process]
        ResponseDto GrantUserPermission(UserDto user, int permissionId);
        [OperationContract]
        [Process]
        ResponseDto RevokeUserPermission(UserDto user, int permissionId);
        [OperationContract]
        [Process]
        ResponseDto GrantRolePermission(RoleDto role, int permissionId);
        [OperationContract]
        [Process]
        ResponseDto RevokeRolePermission(RoleDto role, int permissionId);
        [OperationContract]
        [Process]
        PermissionDtoContainer RolePermissions(RoleDto role);
        [OperationContract]
        [Process]
        PermissionDtoContainer UserPermissions(UserDto user);
        [OperationContract]
        [Process]
        PermissionToRoleConstraintDto AddPermissionToRoleConstraint(PermissionToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        PermissionToUserConstraintDto AddPermissionToUserConstraint(PermissionToUserConstraintDto constraint);
        [OperationContract]
        [Process]
        ResponseDto RemovePermissionToRoleConstraint(PermissionToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        ResponseDto RemovePermissionToUserConstraint(PermissionToUserConstraintDto constraint);
        [OperationContract]
        [Process]
        PermissionToRoleConstraintDto UpdatePermissionToRoleConstraint(PermissionToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        PermissionToUserConstraintDto UpdatePermissionToUserConstraint(PermissionToUserConstraintDto constraint);
        [OperationContract]
        [Process]
        ResponseDtoContainer ChangeUserPermissons(List<PermissionDto> permissions,long userId);
        [OperationContract]
        [Process]
        ResponseDtoContainer ChangeRolePermissons(List<PermissionDto> permissions, int roleId);
        
    }
}
