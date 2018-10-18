using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTOContainer;
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
    public class SessionService : ContextBoundObject,ISessionService
    {
        SessionBussiness sessionBs = new SessionBussiness();
        public SecuritySessionDtoContainer GetOnlineUsers(int appdomainId)
        {
            return sessionBs.GetOnlineUsers(appdomainId);
        }
    }
}
