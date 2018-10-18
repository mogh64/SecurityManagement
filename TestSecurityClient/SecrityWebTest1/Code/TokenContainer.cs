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
           // HttpContext.Current.Session["identityToken"] = token;
            var strToken = token.ToString();
            var encToken = ISE.Framework.Utility.Utils.Encryption.EncryptData(strToken);
           
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("identityToken", encToken));
        }
       
    }
}
