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
   
    public interface IRoleService : IServiceBase
    {
        [OperationContract]
        [Process]
        ResponseDto ActivateRole(RoleDto role);
        [OperationContract]
        [Process]
        ResponseDto DeActivateRole(RoleDto role);
        [OperationContract]
        [Process]      
        UserDtoContainer AssignedUsers(RoleDto role);
        [OperationContract]
        [Process]
        ResponseDto AddInheritance(int parentRoleId, int childRoleId);
        [OperationContract]
        [Process]
        ResponseDto DeleteInheritance(int parentRoleId, int childRoleId);
        [OperationContract]
        [Process]
        ResponseDto AddAscendant(RoleDto parent, int childRoleId);
       
        [OperationContract]
        [Process]
        ResponseDto AddDescendant(RoleDto child, int parentRoleId);
       
        [OperationContract]
        [Process]
        RoleToRoleConstraintDto AddRoleToRoleConstraint(RoleToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        UserToRoleConstraintDto AddUserToRoleConstraint(UserToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        RoleToRoleConstraintDto UpdateRoleToRoleConstraint(RoleToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        UserToRoleConstraintDto UpdateUserToRoleConstraint(UserToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        ResponseDto RemoveRoleToRoleConstraint(RoleToRoleConstraintDto constraint);
        [OperationContract]
        [Process]
        ResponseDto RemoveUserToRoleConstraint(UserToRoleConstraintDto constraint);
        
        [OperationContract]
        [Process]
        SecurityGroupDtoContainer RoleGroups(RoleDto role);
    }
}
