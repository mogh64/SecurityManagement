using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
   [DataContract]
    public class SignOutMessage
    {
       public SignOutMessage()
       {

       }
       public IdentityToken IdentityToken { get; set; }
       public string ClientId { get; set; }
    }
}
