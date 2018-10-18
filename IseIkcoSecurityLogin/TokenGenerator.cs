

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SecurityLogin
{
    public class TokenGenerator
    {
        static int lifeTimeSecond = 50;
        public static TokenData GenerateToken(string nationalCode, string personelCode, int appCode)
        {
            TokenData data = new TokenData()
            {
                AppCode=appCode,
                CreateDate=DateTime.Now,
                NationalCode = nationalCode,
                PersonelCode = personelCode,
                Token = GetNewGuid()
            };
            data.ExpiredDate = data.CreateDate.AddSeconds(lifeTimeSecond);

            data.SignedToken = SignToken(data.Token.ToString());
            return data;
        }
        public static string SignToken(string token)
        {
            return Encryption.EncryptData(token);
        }
        public static string GetToken(string value)
        {
            return Encryption.DecryptData(value);
        }
      
        private static string GetNewGuid()
        {
            var guid =Guid.NewGuid();
            return guid.ToString().Replace("-","").ToUpper();
        }
    }
}
