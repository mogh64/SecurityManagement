using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Wcf;
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
    public interface IDataService : IServiceContract
    {
        [OperationContract]
        [Process]
        ApplicationDomainDtoContainer GetAppDomainList();
        [OperationContract]
        [Process]
        ApplicationDomainDtoContainer GetUserAppDomainList(long userId);
        [OperationContract]
        [Process]
        ResourceTypeDtoContainer GetResourceTypeList();
        [OperationContract]
        [Process]
        UserLogDto TestUserLog();
        [OperationContract]
        [Process]
        UserLogDto TestWaitUserLog();
    }
}
