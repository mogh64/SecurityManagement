using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Message;
using ISE.Framework.Common.Service.ServiceBase;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Common.Contract
{
     [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IResourceService : IServiceBase
    {
         [OperationContract]
         [Process]
         OperationDtoContainer RoleOperations(RoleDto role, SecurityResourceDto resource);
         [OperationContract]
         [Process]
         OperationDtoContainer UserOperations(UserDto role, SecurityResourceDto resource);
         [OperationContract]
         [Process]
         PermissionDto AddOperation(SecurityResourceDto resource, OperationDto operationDto);
         [OperationContract]
         [Process]
         PermissionDtoContainer AddOperations(SecurityResourceDto resource, List<OperationDto> operationDtos);
         [OperationContract]
         [Process]
         ResponseDto RemoveOperation(SecurityResourceDto resource, OperationDto operationDto);
    }
}
