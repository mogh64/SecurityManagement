using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.Service.Wcf;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Common.Contract
{
    [ServiceContract(Namespace = "http://www.iseikco.com/Sec")]
    public interface IAuthenticationService : IServiceContract
    {
        [OperationContract]
        [Process]
        AuthenticationResult Authenticate(SignInMessage message);
        [OperationContract]
        [Process]
        TokenValidationResult ValidateIdentityToken(IdentityToken token);
        [OperationContract]
        [Process]
        SignOutResult Logout(SignOutMessage message);
    }
}
