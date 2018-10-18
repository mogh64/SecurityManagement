using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class ManagementService : ContextBoundObject,IManagementService
    {
        ManagementAccountBussiness managementBs = new ManagementAccountBussiness();
        public Common.Message.AuthenticationResult Authenticate(Common.Message.SignInMessage message)
        {
            return managementBs.Authenticate(message);
        }
    }
}
