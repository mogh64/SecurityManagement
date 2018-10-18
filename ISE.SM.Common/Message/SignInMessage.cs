using ISE.SM.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
    [DataContract]
    public class SignInMessage
    {
       
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password
        {
            get;
            set;
        }
        public string PlainPassword
        {
            get
            {
                try
                {
                    RSAEncryptionCreator encryption = new RSAEncryptionCreator();
                    return encryption.PrivateDecryption(Password); 
                }
                catch
                {
                    return string.Empty;
                }
            }
        }
          [DataMember]
        public string ClientId { get; set; }
    }
    public class SignInMessageBuilder
    {
        public SignInMessageBuilder()
        {
        }
        public static SignInMessage BuildMessage(string userName, string password, string clientId)
        {
            SignInMessage msg = new SignInMessage()
            {
                ClientId=clientId,
                UserName=userName
            };
            RSAEncryptionCreator encryption = new RSAEncryptionCreator();
            msg.Password = encryption.PublicEncryption(password);
            return msg;
        }
    }
}
