using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISESecurityLoginRemote
{
    internal class PathProvider
    {
        public static string RemoteLoginDll()
        {
            return @"\\isesrv4\iseapp$\common\ISE\ISESecurityLogin.dll";
        }
    }
}
