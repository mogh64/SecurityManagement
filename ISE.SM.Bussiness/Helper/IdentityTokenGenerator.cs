using ISE.SM.Bussiness.Helper;
using ISE.SM.Bussiness.Validator;
using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using ISE.SM.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class IdentityTokenGenerator
    {
        public IdentityToken GenerateToken(AccountDto account,SignInMessage sgnMessage)
        {
            SessionBussiness sessionBs = new SessionBussiness();
            IdentityToken token = new IdentityToken();
            ClaimListBuilder claimBuilder = new ClaimListBuilder();
            if (account != null)
            {
                token.UserName = account.Username;
                var claims = claimBuilder.GetIdentityClaimList(account,sgnMessage);
                if (claims != null && claims.Count>0)
                   token.Claims.AddRange(claims);
                var newSession =  sessionBs.CreateSession(account,sgnMessage.ClientId);
                token.HasLogin = true;
                if (newSession != null)
                {
                    token.SessionId = newSession.SecuritySessionId;
                }
                TokenSigner.SignIdentityToken(token);
            }
            return token;
        }
        public IdentityToken ExpireToken(IdentityToken token)
        {
            SessionBussiness sessionBs = new SessionBussiness();
           
            TokenValidator tokenValidator = new TokenValidator();
            var validationResult = tokenValidator.ValiateIdentityToken(token);
            if (validationResult.IsError)
            {             
                return token;
            }
            if (token.HasLogin )
            {
                
                sessionBs.ExpireSession(token.SessionId);
                token.HasLogin = false;                
                TokenSigner.SignIdentityToken(token);
            }
            return token;
        }
    }
}
