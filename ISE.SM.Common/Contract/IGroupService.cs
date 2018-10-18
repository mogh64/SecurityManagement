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
    public interface IGroupService : IServiceBase
    {
        [OperationContract]
        [Process]
        ResponseDto AssignUsers(List<UserDto> users,int groupId);
        [OperationContract]
        [Process]
        ResponseDto AssignRoles(List<RoleDto> roles, int groupId);
        [OperationContract]
        [Process]
        ResponseDto DeAssignUsers(List<UserDto> users, int groupId);
        [OperationContract]
        [Process]
        ResponseDto DeAssignRoles(List<RoleDto> roles, int groupId);
        [OperationContract]
        [Process]
        UserDtoContainer AssignedUsers(int groupId);
        [OperationContract]
        [Process]
        RoleDtoContainer AssignedRoles(int groupId);
    }
}
