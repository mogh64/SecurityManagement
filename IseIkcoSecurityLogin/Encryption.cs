using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ISE.SecurityLogin
{
    public static class Encryption
    {
        private const string MyKey = "$95*#Hwl5679";

        private static string AlgorithmName = "TripleDES";

        private static Rfc2898DeriveBytes GetKey()
        {
            byte[] salt = StrToByteArray("01234567");
            var key = new Rfc2898DeriveBytes(MyKey, salt);
            return key;
        }
        private static Rfc2898DeriveBytes GetKey(string key)
        {
            byte[] salt = StrToByteArray("01234567");
            var rkey = new Rfc2898DeriveBytes(key, salt);
            return rkey;
        }
        public static byte[] StrToByteArray(string str)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }
        public static string EncryptData(string ClearData)
        {
            // Convert string ClearData to byte array
            byte[] ClearData_byte_Array = Encoding.UTF8.GetBytes(ClearData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = GetKey().GetBytes(Algorithm.KeySize / 8);

            // Encrypt information
            MemoryStream Target = new MemoryStream();

            // Append IV
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            // Encrypt Clear Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData_byte_Array, 0, ClearData_byte_Array.Length);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Convert.ToBase64String(Target_byte_Array);
            string target_url_string = HttpUtility.UrlEncode(Target_string); 
            return  target_url_string;
        }

        public static string DecryptData(string EncryptedData)
        {
            string target_encoded_string = HttpUtility.UrlDecode(EncryptedData);
            byte[] EncryptedData_byte_Array = Convert.FromBase64String(target_encoded_string);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = Algorithm.Key = GetKey().GetBytes(Algorithm.KeySize / 8);

            // Decrypt information
            MemoryStream Target = new MemoryStream();

            // Read IV
            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(EncryptedData_byte_Array, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            // Decrypt Encrypted Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(EncryptedData_byte_Array, ReadPos, EncryptedData_byte_Array.Length - ReadPos);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Encoding.UTF8.GetString(Target_byte_Array);
            return Target_string;
        }
        public static string EncryptData(string ClearData, string key)
        {
            // Convert string ClearData to byte array
            byte[] ClearData_byte_Array = Encoding.UTF8.GetBytes(ClearData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = GetKey(key).GetBytes(Algorithm.KeySize / 8);

            // Encrypt information
            MemoryStream Target = new MemoryStream();

            // Append IV
            Algorithm.GenerateIV();
            Target.Write(Algorithm.IV, 0, Algorithm.IV.Length);

            // Encrypt Clear Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(ClearData_byte_Array, 0, ClearData_byte_Array.Length);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Convert.ToBase64String(Target_byte_Array);
            return Target_string;
        }

        public static string DecryptData(string EncryptedData, string key)
        {
            byte[] EncryptedData_byte_Array = Convert.FromBase64String(EncryptedData);

            // Now Create The Algorithm
            SymmetricAlgorithm Algorithm = SymmetricAlgorithm.Create(AlgorithmName);
            Algorithm.Key = Algorithm.Key = GetKey(key).GetBytes(Algorithm.KeySize / 8);

            // Decrypt information
            MemoryStream Target = new MemoryStream();

            // Read IV
            int ReadPos = 0;
            byte[] IV = new byte[Algorithm.IV.Length];
            Array.Copy(EncryptedData_byte_Array, IV, IV.Length);
            Algorithm.IV = IV;
            ReadPos += Algorithm.IV.Length;

            // Decrypt Encrypted Data
            CryptoStream cs = new CryptoStream(Target, Algorithm.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(EncryptedData_byte_Array, ReadPos, EncryptedData_byte_Array.Length - ReadPos);
            cs.FlushFinalBlock();

            // Output
            byte[] Target_byte_Array = Target.ToArray();
            string Target_string = Encoding.UTF8.GetString(Target_byte_Array);
            return Target_string;
        }

    }
}
