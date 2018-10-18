using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Common.Contract
{
    [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IAuthorizationService : IServiceContract
    {
        [OperationContract]
        [Process]
        AuthorizationResult CheckAccess(AuthorizationRequest request);
        [OperationContract]
        [Process]
        SecurityResourceDtoContainer AccessList(Common.Message.AuthorizationRequest request);
        [OperationContract]
        [Process]
        SecurityResourceDtoContainer MenuList(Common.Message.AuthorizationRequest request);
    }
}
