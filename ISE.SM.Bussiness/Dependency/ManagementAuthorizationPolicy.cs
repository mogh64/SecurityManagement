using ISE.Framework.Common.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Dependency
{
    public class ManagementAuthorizationPolicy : IServiceAuthorize
    {
        public bool Authorize(Framework.Common.Token.UserIdentity identity, string contractName, string operationName)
        {
            return true;
        }
    }
}
