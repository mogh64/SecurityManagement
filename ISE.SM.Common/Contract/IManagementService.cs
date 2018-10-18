using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Contract
{
     [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IManagementService : IServiceContract
    {
         [OperationContract]
         [Process]
         AuthenticationResult Authenticate(SignInMessage message);
    }
}
