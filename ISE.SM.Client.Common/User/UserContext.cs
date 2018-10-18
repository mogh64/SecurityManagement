using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.Common.User
{
    public class UserContext
    {
        private static IdentityToken userToken=null;
        public static void SetToken(IdentityToken token)
        {
            userToken = token;
        }
        public static IdentityToken CurrentToken
        {
            get{
                return userToken;
            }
            
        }
    }
}
