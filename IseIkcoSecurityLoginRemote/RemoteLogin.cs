using System;
using System.Collections.Generic;
using System.Reflection;

namespace ISESecurityLoginRemote
{
    public class RemoteLogin
    {
        string path = PathProvider.RemoteLoginDll();
        string extToken = "";
        Dictionary<string,string> tokenData=new Dictionary<string,string>();
        public RemoteLogin()
        {

        }
        //public RemoteLogin(string link)
        //{
        //    SetToken(link);
        //}
        public RemoteLogin(string token)
        {
            extToken = token;
        }
        public bool IsValidToken()
        {
            var token =  GetToken();
           
            return  ReadToken(token);
        }
        public string GetNationalCode()
        {
            if (tokenData != null)
                return tokenData["nationalCode"];
            return string.Empty;
        }
        public string GetPersonelCode()
        {
            if (tokenData != null)
                return tokenData["personelCode"];
            return string.Empty;
        }
        private bool ReadToken(string token)
        {
            var assembly = AssemblyLoader.Load(path);
            var obj =  assembly.CreateInstance("ISESecurityLogin.RemoteTokenValidator");
            Object ret = obj.GetType().InvokeMember("GetToken", BindingFlags.InvokeMethod, null, obj, new object[] { token });
            tokenData = (Dictionary<string,string>)ret;
            return tokenData.Keys.Count>0 ;
        }
        
        private string GetToken()
        {
            string token = "";
            if (extToken.Length > 0)
                token = extToken;
            
            return token;
        }
       
    }
}
