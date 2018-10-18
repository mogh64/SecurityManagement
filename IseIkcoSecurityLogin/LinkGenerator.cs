using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SecurityLogin
{
    public class LinkGenerator
    {
        public static string GenerateLink(string address, string token)
        {
            if (!address.EndsWith("/"))
                address = address + "/";
            address = address + "?token=";
            return address + token;
        }
    }
}
