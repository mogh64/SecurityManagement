using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
     [DataContract]
    public class IdentityToken
    {
        
        public IdentityToken()
        {
            Claims = new List<Claim>();
            CreationTime = DateTime.Now;
            LifeTimeMinute = 60*4;
            HasLogin = false;
        }
        public IdentityToken(string tokenString)
        {
           Claims = new List<Claim>();
           string[] splitStr = tokenString.Split('.');
           string[] splitpayload = splitStr[0].Split('|');
           string[] data = splitpayload[0].Split(',');
           string[] claims = splitpayload[1].Split(',');

           SessionId = data[0].ToString();
           string hasLogin = data[1].ToString();
           if (hasLogin.ToLower() == "true")
           {
               HasLogin = true;
           }
           else
           {
               HasLogin = false;
           }

           UserName = data[2].ToString();
           CreationTime = DateTime.Parse(data[3].ToString());
            
           string lifeTimeMin = data[4].ToString();
           LifeTimeMinute = int.Parse(lifeTimeMin);
           foreach (var claimStr in claims)
           {
               if (!string.IsNullOrWhiteSpace(claimStr))
               {
                   Claim claim = new Claim(claimStr);
                   Claims.Add(claim);
               }
               
           }
           this.Signature = splitStr[1];
        }
         [DataMember]
        public bool HasLogin { get; set; }
         [DataMember]
        public string SessionId { get; set; }
         [DataMember]
        public List<Claim> Claims { get; set; }
         [DataMember]
        public string UserName { get; set; }
         [DataMember]
        public int LifeTimeMinute { get; set; }
         [DataMember]
        public DateTime CreationTime { get; set; }
         
        public DateTime ExpirationTime { get { return CreationTime.AddSeconds(LifeTimeMinute); } }
         
        public string SubjectId {
            get { return Claims.Where(x => x.Type == ClaimTypes.Subject).Select(x => x.Value).SingleOrDefault() ?? string.Empty; }
        }
        public string ClaimValue(string claimType)
        {
           
             return Claims.Where(x => x.Type == claimType).Select(x => x.Value).SingleOrDefault() ?? string.Empty;
            
        }
        public string RefrenceTokenId {
                 get {
                 
                     return Claims.Where(x => x.Type == ClaimTypes.ReferenceTokenId).Select(x => x.Value).SingleOrDefault()??string.Empty;
                 }
            }
         [DataMember]
        public string Signature { get; set; }
        public override string ToString()
        {

            string text = string.Empty;
           
           
            text += SessionId;
            text += ",";
            text += HasLogin;
            text += ",";            
            text += UserName;
            text += ",";
            text += CreationTime.ToString("yyyy-MM-dd HH:mm tt");
            text += ",";
            text += LifeTimeMinute.ToString();
            text += ",";
                        
            text += "|";
            foreach (var claim in Claims)
            {
                text += claim.ToString();
                text += ",";
            }

            text += ".";
            text += Signature;
            return text;
        }
        public string PayloadString()
        {
            string [] str = this.ToString().Split('.').ToArray();
            return str[0].ToString();
        }
    }
}
