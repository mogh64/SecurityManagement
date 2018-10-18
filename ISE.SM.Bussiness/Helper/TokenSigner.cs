using ISE.SM.Common.Message;
using ISE.SM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class TokenSigner
    {
        public static void SignIdentityToken(IdentityToken token)
        {
            string text =  token.PayloadString();
            string signature =  TokenSignFactory.SignToken(text);
            token.Signature = signature;
        }
    }
}
