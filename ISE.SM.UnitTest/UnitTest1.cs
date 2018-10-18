using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ISE.SM.Common.Contract;
using ISE.SM.Service;
using ISE.SM.Common.Message;
using ISE.SM.Common.DTO;
using ISE.SM.Bussiness;
using ISE.SM.Utility;
using ISE.SM.Bussiness.Validator;
using ISE.SM.Bussiness.Dependency;
using ISE.SM.DataAccess;
using ISE.SM.Common.Utils;

using ISE.SecurityLogin;


namespace ISE.SM.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void LoginTestMethod1()
        {
            Configuration.Configure();
            AccountBussiness accountBussines = new AccountBussiness();
            SignInMessage msg = new SignInMessage();
            msg.UserName = "92000711";
            RSAEncryptionCreator encryption = new RSAEncryptionCreator();
            msg.Password = encryption.PublicEncryption("123");
            msg.ClientId = "1";
            var result = accountBussines.Authenticate(msg);
            Assert.AreNotEqual(result.HasError, true);
            Assert.AreNotEqual(result.IdentityToken.Signature, string.Empty);
            
            TokenValidator validator = new TokenValidator();
            var tokenValidation =  validator.ValiateIdentityToken(result.IdentityToken);
            var strToken = result.IdentityToken.ToString();
            IdentityToken cToken = new IdentityToken(strToken);
            var strCtoken=cToken.ToString();
            Assert.AreEqual(strToken, strCtoken);
            Assert.AreEqual(tokenValidation.IsError, true);
        }
        [TestMethod]
        public void RegisterUserTest()
        {
            SecurityUserBussiness provider = new SecurityUserBussiness();
            UserDto user = new UserDto(){
                FirstName = "test2",
                LastName = "ftest2",
                NationalNo= "123457"
            };
            AccountDto acc = new AccountDto()
            {
                Username = "bbb",
                Password = "123"
            };
            user.Accounts.Add(acc);
            var result =  provider.RegisterUser(user);
        }
         [TestMethod]
        public void TestHash()
        {
             string data="mortaza";
             string hash1 = HashFactory.GetHash(data);
             string hash2 = HashFactory.GetHash(data);
             Assert.AreEqual(hash1, hash2);
        }
         [TestMethod]
         public void TestDate()
         {
             DateTime dt = DateTime.Now;
             string dtStr = dt.ToString("yyyy-MM-dd HH:mm tt");
             DateTime dtPars = DateTime.Parse(dtStr);
         }
         [TestMethod]
         public void AttributeTest()
         {
             Configuration.Configure();
             RoleDto role = new RoleDto() { RoleId=1};
             IRoleService bs = new RoleService();
             var users = bs.AssignedUsers(role);
         }
        [TestMethod]
         public void GetAllPermissionTest()
         {
             PermissionTDataAccess da = new PermissionTDataAccess();
             var result = da.GetCurrentUserPermissions(1);
             Assert.AreNotEqual(result.PermissionDtoList.Count, 0);
         }
        [TestMethod]
        public void TestSessionId()
        {
            var sessionId = SessionIdGenerator.GenrateNewSessionId();
            var bytes = SessionIdGenerator.GetByteSessionId(sessionId);
            var strs = SessionIdGenerator.GetStringSessionId(bytes);
            var rebyte = SessionIdGenerator.GetByteSessionId(strs);
            Assert.AreEqual(sessionId, strs);
            Assert.AreEqual(bytes.ToString(), rebyte.ToString());
        }
         [TestMethod]
        public void TestRemoteLogin()
        {
            var link = TokenLinkFacade.GenerateLink("http://localhost:58782/login.aspx", 11, "4285705761", "92000711");
           
            
        }
        [TestMethod]
         public void TestRemoteValidator()
         {
             string str = "hellowordmetos313";
             //RemoteTokenValidator valid = new RemoteTokenValidator();
             //var s =  valid.GetNationalCode("Ye+4ymDy41JUATbgtSeNvsQljQLM6j+EXVVdv9f/Gz7QI/sPnUJcVyO9h2uM4gAzcSN9yl80xsKgFaNaZWKhwE96oNQw+4rk+Ss0dR5c+zQtYjf4KJGXiTdB8OIrvX601WUsq/Bd2NF//lrp3BMY2oodhxXdor50PKlF+heFuoQ=");
             var sign = Encryption.EncryptData(str);
             var da = Encryption.DecryptData(sign);


             Assert.AreEqual(str, da);

         }
        [TestMethod]
        public void GenerateToken()
        {
            var token =  TokenGenerator.GenerateToken("1231", "54654", 123);
            TokenStorage.StoreToken(token);
            var token1 = TokenStorage.GetData(token.Token);
        }
        [TestMethod]
        public void GetToken()
        {
            string token = "EF3640BA157F4A739BD45D9330D95011";
            RemoteTokenValidator validator = new RemoteTokenValidator();
            var result = validator.GetToken(token);
        }
        private string GetQueryString(string key,string url)
        {
            string sub = string.Format("/?{0}=",key);
            string value = "";
            for (int i = 0; i < url.Length; i++)
            {
                string val = url.Substring(i, sub.Length);
                if (val == sub)
                {
                    value = url.Substring(i + sub.Length);
                    return value;
                }
            }
            return "";
        }

    }
}
