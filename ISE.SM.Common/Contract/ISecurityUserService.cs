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
    public interface ISecurityUserService : IServiceBase
    {
        [OperationContract]
        [Process]
        ResponseDto AssignUser(UserDto user, int roleId);
        [OperationContract]
        [Process]
        ResponseDto DeAssignUser(UserDto user, int roleId);
        [OperationContract]
        [Process]
        ResponseDto ActivateUser(UserDto user);
        [OperationContract]
        [Process]
        ResponseDto DeActivateUser(UserDto user);
        [OperationContract]
        [Process]
        RoleDtoContainer AssignedRoles(UserDto user);
        [OperationContract]
        [Process]
        UserDto GetUserRoleIds(long userId);
        [OperationContract]
        [Process]
        UserDto GetUserGroupIds(long userId);
    }
}
