using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
     [DataContract]
    public class Claim
    {
         public Claim()
         {

         }
         [DataMember]
        public string Type { get; set; }
          [DataMember]
        public string Value { get; set; }
        
        public override string ToString()
        {
            string claimString = string.Format("{0}:{1}",Type,Value);
            return claimString;
        }
        public Claim(string claimString)
        {
            this.Type = claimString.Split(':')[0];
            this.Value = claimString.Split(':')[1];
        }
    }
}
