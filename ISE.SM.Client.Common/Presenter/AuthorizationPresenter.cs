using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.Service;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.Common.Presenter
{
    public class AuthorizationPresenter
    {
        private ServiceAdapter<IAuthorizationService> AuthorizationServiceAdapter;
        private ServiceAdapter<IAuthenticationService> AuthenticationServiceAdapter;
        public AuthorizationPresenter() 
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            AuthorizationServiceAdapter = new ServiceAdapter<IAuthorizationService>(exceptionManager);
            AuthenticationServiceAdapter = new ServiceAdapter<IAuthenticationService>(exceptionManager);      
        }
        public AuthenticationResult Authenticate(string userName, string password,string clientId)
        {
            var msg = SignInMessageBuilder.BuildMessage(userName, password, clientId);
           
            var result = AuthenticationServiceAdapter.Execute(it => it.Authenticate(msg));
           
            return result;
        }
        public void Logout(IdentityToken token,string clientId)
        {
            SignOutMessage msg = new SignOutMessage() { 
                ClientId=clientId,
                IdentityToken=token
            };
            var result = AuthenticationServiceAdapter.Execute(it => it.Logout(msg));
            token = result.IdentityToken;
        }
        public bool ValidateIdentityToken(IdentityToken token)
        {
            var result = AuthenticationServiceAdapter.Execute(it => it.ValidateIdentityToken(token));
            return result.IsValid;
        }
        public List<SecurityResourceDto> GetMenuList(IdentityToken token, int appDomainId)
        {
            AuthorizationRequest request = new AuthorizationRequest()
            {
                AppDomainId=appDomainId,
                IdentityToken=token,                
            };
            var result = AuthorizationServiceAdapter.Execute(it => it.MenuList(request));
            if(result.Response.HasException)
                return null;
            
            return result.SecurityResourceDtoList;
        }
        public AuthorizationResult CheckAccess(SecurityResourceDto resource, IdentityToken token)
        {
            AuthorizationRequest request = new AuthorizationRequest() {
                IdentityToken=token,
                Resource=resource
            };
            var result = AuthorizationServiceAdapter.Execute(it => it.CheckAccess(request));
            //if (result.HasError)
            //    return null;
            return result;
        }
    }
}
