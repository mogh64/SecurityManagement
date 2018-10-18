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
    public class TokenValidationResult:BaseDto
    {
        public TokenValidationResult()
        {

        }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public bool IsValid { get; set; }
       
        public bool IsError { get { return !string.IsNullOrWhiteSpace(Error) || !IsValid; } }
    }
}
