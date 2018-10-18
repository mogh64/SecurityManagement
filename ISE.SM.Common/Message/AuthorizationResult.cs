using ISE.Framework.Common.CommonBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
     [DataContract]
    public class AuthorizationResult:BaseDto
    {
         [DataMember]
        public string ErrorMessage { get; set; }
        public bool HasError { get { if (string.IsNullOrWhiteSpace(ErrorMessage)) { return false; } return true; } }
         [DataMember]
        public AccessToken AccessToken { get; set; }
    }
}
