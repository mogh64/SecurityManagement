using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
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
    public class AuthorizationService :ContextBoundObject, IAuthorizationService
    {
        AuthorizationBussiness authBussines = new AuthorizationBussiness();
        public Common.DTOContainer.SecurityResourceDtoContainer AccessList(Common.Message.AuthorizationRequest request)
        {
            AuthorizationBussiness securityBussiness = new AuthorizationBussiness();
            return securityBussiness.AccessList(request);            
        }

        public Common.Message.AuthorizationResult CheckAccess(Common.Message.AuthorizationRequest request)
        {
            return  authBussines.CheckAccess(request);
        }


        public Common.DTOContainer.SecurityResourceDtoContainer MenuList(Common.Message.AuthorizationRequest request)
        {
            AuthorizationBussiness securityBussiness = new AuthorizationBussiness();
            return securityBussiness.MenuList(request);      
        }
    }
}
