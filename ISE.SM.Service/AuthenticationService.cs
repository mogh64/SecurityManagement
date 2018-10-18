using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
using ISE.SM.Bussiness.Validator;
using ISE.SM.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class AuthenticationService :ContextBoundObject, IAuthenticationService
    {
        public Common.Message.AuthenticationResult Authenticate(Common.Message.SignInMessage message)
        {
            AccountBussiness accountBussines = new AccountBussiness();
            return  accountBussines.Authenticate(message);
        }


        public Common.Message.TokenValidationResult ValidateIdentityToken(Common.Message.IdentityToken token)
        {
            TokenValidator validator = new TokenValidator();
            return validator.ValiateIdentityToken(token);
        }


        public Common.Message.SignOutResult Logout(Common.Message.SignOutMessage message)
        {
            AccountBussiness accountBussines = new AccountBussiness();
            return accountBussines.Logout(message);
        }
    }
}
