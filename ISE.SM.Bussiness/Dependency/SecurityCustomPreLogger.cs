using ISE.Framework.Common.Logger;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Token;
using ISE.SM.Bussiness.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Dependency
{
    public class SecurityCustomPreLogger:IInternalPreLogger
    {
        public void PreLog(string requestId, string contrat, string serviceType, string method, string inParams)
        {
            if (contrat.Contains("IAuthenticationService") && contrat.Contains("IAuthorizationService"))
                return;
            UserIdentity currentUser = WcfCurrentContext.CurrentUser;
            long userId = -1;
            if (currentUser != null)
            {
                long.TryParse(currentUser.UserId,out userId);
            }
            ManagementLogGenerator.GenerateManagementLog(userId, method, serviceType, 0, inParams, 0);
        }
    }
}
