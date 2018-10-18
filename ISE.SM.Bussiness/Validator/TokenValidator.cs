using ISE.SM.Common.Message;
using ISE.SM.Common.Utils;
using ISE.SM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Validator
{
    public class TokenValidator
    {
        public TokenValidationResult ValiateIdentityToken(IdentityToken token)
        {
            if (token != null)
            {
                TokenValidationResult result = new TokenValidationResult();
                if (DateTime.Now > token.ExpirationTime)
                {
                    result.Error = "Token Expired.";
                    result.IsValid = false;
                    return result;
                }
                var hashData = HashFactory.GetHash(token.PayloadString());
                var plainData = TokenSignFactory.GetHashData(token.Signature);
                if (!string.Equals(hashData, plainData))
                {
                    result.Error = "Token Not Verified.";
                    result.IsValid = false;
                    return result;
                }
                SessionBussiness sessionBs = new SessionBussiness();

               
                var session = sessionBs.GetSingle(it => it.SecuritySessionId == token.SessionId);
                if (session != null)
                {
                    if (session.ExpiredDate != null)
                    {
                        result.Error = "Session Is Expired.";
                        result.IsValid = false;
                        return result;
                    }
                }
                else
                {
                    result.Error = "Session not exist.";
                    result.IsValid = false;
                    return result;
                }
                result.IsValid = true;
                return result;
            }
            return null;
        }
    }
}
