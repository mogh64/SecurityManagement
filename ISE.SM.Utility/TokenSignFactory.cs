using RSAEncryptionLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Utility
{
    public  class TokenSignFactory
    {
        static RSAEncryptionCreator encryption = new RSAEncryptionCreator();
        public static string SignToken(string token){
            string signedToken = string.Empty;
            string hashData =  HashFactory.GetHash(token);


            signedToken = encryption.PrivateEncryption(hashData);
            return signedToken;
        }
        public static string GetHashData(string signedData)
        {
            string plainData = encryption.PublicDecryption(signedData);
            return plainData;
        }
    }
}
