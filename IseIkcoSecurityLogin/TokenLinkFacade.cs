using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SecurityLogin
{
    public class TokenLinkFacade
    {
        public static string GenerateLink(string destinationLink,int applicationCode, string nationalCode, string personelCode)
        {
            var token = TokenGenerator.GenerateToken(nationalCode, personelCode,applicationCode);
            var link = LinkGenerator.GenerateLink(destinationLink, token.SignedToken);
            TokenStorage.StoreToken(token);
           
            return link;
        }
    }
}
