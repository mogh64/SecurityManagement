
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SecurityLogin
{
    public  class RemoteTokenValidator
    {
        public Dictionary<string, string> GetToken(string token)
        {
            Dictionary<string, string> tokenValues = new Dictionary<string, string>();
           var result = TokenStorage.CheckToken(Encryption.DecryptData(token));
           if (result != null && result.IsValid())
           {
            
               tokenValues.Add("nationalCode", result.NationalCode);
               tokenValues.Add("personelCode", result.PersonelCode);               
           }
            return tokenValues;
        }
       
    }
}
