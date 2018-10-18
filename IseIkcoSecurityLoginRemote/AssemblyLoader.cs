using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISESecurityLoginRemote
{
    public class AssemblyLoader
    {
        internal static Assembly Load(string sharedPath)
        {
            byte[] AssmBytes = File.ReadAllBytes(sharedPath);
            Assembly a = Assembly.Load(AssmBytes);
            return a;
        }
        
    }
}
