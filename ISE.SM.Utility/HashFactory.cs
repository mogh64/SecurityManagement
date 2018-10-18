using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ISE.SM.Utility
{
    public class HashFactory
    {
        public static string GetHash(string data)
        {
            string hashed = string.Empty;
            SHA256 mySHA256 = SHA256Managed.Create();
            var bytes=  System.Text.Encoding.ASCII.GetBytes(data);
            var hashBytes= mySHA256.ComputeHash(bytes);

            hashed = System.Text.Encoding.ASCII.GetString(hashBytes);
            return hashed;
        }
    }
}
