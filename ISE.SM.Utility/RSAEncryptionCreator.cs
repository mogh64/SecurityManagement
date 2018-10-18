using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Utility
{
    public  class RSAEncryptionCreator
    {
        public RSAEncryptionCreator() { }
        public string PrivateEncryption(string text)
        {
            string encodedText = string.Empty;

            var rsaEncryption = RsaProvider.GetRsaEncryption();
            if (!rsaEncryption.IsPrivateKeyLoaded)
            {
                rsaEncryption.LoadPrivateFromXml();
            }
            var bytes = Encoding.UTF8.GetBytes(text);
            var encBytes = rsaEncryption.PrivateEncryption(bytes);

            encodedText = Convert.ToBase64String(encBytes);

            return encodedText;
        }
        public string PublicEncryption(string text)
        {
            string encodedText = string.Empty;

            var rsaEncryption = RsaProvider.GetRsaEncryption();
            if (!rsaEncryption.IsPublicKeyLoaded)
            {
                rsaEncryption.LoadPublicFromXml();
            }
            var bytes = Encoding.UTF8.GetBytes(text);
            var encBytes = rsaEncryption.PublicEncryption(bytes);

            encodedText = Convert.ToBase64String(encBytes);

            return encodedText;
        }
        public string PrivateDecryption(string text)
        {
            string encodedText = string.Empty;

            var rsaEncryption = RsaProvider.GetRsaEncryption();
            if (!rsaEncryption.IsPrivateKeyLoaded)
            {
                rsaEncryption.LoadPrivateFromXml();
            }
            var bytes = Convert.FromBase64String(text);
            var encBytes = rsaEncryption.PrivateDecryption(bytes);
            encodedText = Encoding.UTF8.GetString(encBytes);

            return encodedText;
        }
        public string PublicDecryption(string encText)
        {
            string plainText = string.Empty;

            var rsaEncryption = RsaProvider.GetRsaEncryption();
            if (!rsaEncryption.IsPublicKeyLoaded)
            {
                rsaEncryption.LoadPublicFromXml();
            }
            var bytes = Convert.FromBase64String(encText);
            var sigendBytes = rsaEncryption.PublicDecryption(bytes);
            plainText = Encoding.UTF8.GetString(sigendBytes);

            return plainText;
        }
    }
}
