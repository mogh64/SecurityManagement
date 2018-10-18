using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ISE.SM.RSALib
{
    public class KeyGenerator
    {
        public static KeyValuePair<string, string> GeneratePrivatePublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string privateKey = rsa.ToXmlString(true);
            string publicKey = rsa.ToXmlString(false);
            KeyValuePair<string, string> pair = new KeyValuePair<string, string>(privateKey, publicKey);            
            return pair;
        }
        public static void StoreKey(string xmlKey, string fileName)
        {
            File.WriteAllText(System.IO.Directory.GetCurrentDirectory() + "\\" + fileName, xmlKey);
        }
        public static void StorePrivateKey(string xmlKey, string directoryPath = "")
        {
            string directory = directoryPath;
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = System.IO.Directory.GetCurrentDirectory();
            }
            File.WriteAllText(directory + "\\PrivateKey.xml", xmlKey);
        }
        public static void StorePublicKey(string xmlKey, string directoryPath = "")
        {
            string directory = directoryPath;
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = System.IO.Directory.GetCurrentDirectory();
            }
            File.WriteAllText(directory + "\\PublicKey.xml", xmlKey);
        }
        public static string LoadPrivateKey(string directoryPath = "")
        {
            string directory = directoryPath;
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = System.IO.Directory.GetCurrentDirectory();
            }
           string xmlText =  File.ReadAllText(directory + "\\PrivateKey.xml");
           return xmlText;
        }
        public static string LoadPublicKey(string directoryPath = "")
        {
            string directory = directoryPath;
            if (string.IsNullOrWhiteSpace(directory))
            {
                directory = System.IO.Directory.GetCurrentDirectory();
            }
          string xmlText = File.ReadAllText(directory + "\\PublicKey.xml");
          return xmlText;
        }
    }
}
