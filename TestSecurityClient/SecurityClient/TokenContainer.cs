using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityClient
{
    public class TokenContainer
    {
        private static IdentityToken Token = null;
        public static void SetToken(IdentityToken token)
        {
            Token = token;
        }
        public static IdentityToken CurrentToken
        {
            get
            {
                return Token;
            }
        }
    }
}
