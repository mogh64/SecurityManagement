using ISE.Framework.Common.Dependency;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Dependency
{
    public class Configuration
    {
        public static void Configure()
        {
            DependencyContainer.ServiceAuthorization = new ManagementAuthorizationPolicy();
            DependencyContainer.CustomPreLogger = new SecurityCustomPreLogger();
        }
    }
}
