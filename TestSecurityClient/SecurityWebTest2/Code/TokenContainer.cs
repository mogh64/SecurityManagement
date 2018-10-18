using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace SecurityWeb
{
    public class TokenContainer
    {
        
        public static void SetToken(IdentityToken token)
        {
            HttpContext.Current.Session["identityToken"] = token;
        }
        public static IdentityToken CurrentToken
        {
            get
            {
                return (IdentityToken)HttpContext.Current.Session["identityToken"];
            }
        }
    }
}
