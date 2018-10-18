using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Bussiness.Helper;
using ISE.SM.Bussiness.Validator;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Common.Message;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class AuthorizationBussiness 
    {
        public Common.Message.AuthorizationResult CheckAccess(Common.Message.AuthorizationRequest request)
        {
            AuthorizationResult result = new AuthorizationResult();
            TokenValidator tokenValidator = new TokenValidator();
            
            var validationResult = tokenValidator.ValiateIdentityToken(request.IdentityToken);
            if (validationResult.IsError)
            {
                result.ErrorMessage =validationResult.Error;
                return result;
            }
            AccessTokenGenerator generator = new AccessTokenGenerator();
            var accessToken = generator. GenerateToken(request.IdentityToken, request.Resource);
            result.AccessToken = accessToken;
            return result;
        }
        public SecurityResourceDtoContainer AccessList(Common.Message.AuthorizationRequest request)
        {
            SecurityResourceDtoContainer container = new SecurityResourceDtoContainer();
            TokenValidator tokenValidator = new TokenValidator();
            var validationResult = tokenValidator.ValiateIdentityToken(request.IdentityToken);
            if (validationResult.IsError)
            {
                container.Response.AddBusinessException(validationResult.Error,Framework.Common.Service.Message.BusinessExceptionEnum.Validation);
                return container;
            }
            else
            {
                ResourceTDataAccess resource = new ResourceTDataAccess();
                int userId=0;
                int.TryParse(request.IdentityToken.SubjectId,out userId);
                var resourceList = resource.GetResourceAccessList(request.ResourceTypeId, request.AppDomainId, userId);
                container.SecurityResourceDtoList.AddRange(resourceList);
            }
            return container;
        }
        public SecurityResourceDtoContainer MenuList(Common.Message.AuthorizationRequest request)
        {
            SecurityResourceDtoContainer container = new SecurityResourceDtoContainer();
            TokenValidator tokenValidator = new TokenValidator();
            PermissionTDataAccess permissionDa = new PermissionTDataAccess();
            var validationResult = tokenValidator.ValiateIdentityToken(request.IdentityToken);
            if (validationResult.IsError)
            {
                container.Response.AddBusinessException(validationResult.Error, Framework.Common.Service.Message.BusinessExceptionEnum.Validation);
                return container;
            }
            else
            {
               
                ResourceTDataAccess resource = new ResourceTDataAccess();
                int userId = 0;
                int.TryParse(request.IdentityToken.SubjectId, out userId);
               
                 var menuItemList = resource.GetMenuAccessList(request.AppDomainId, userId);
                 //  container.SecurityResourceDtoList.AddRange(menuItemList);

                 foreach (var item in menuItemList)
                 {
                     permissionDa.AddResources(item, container.SecurityResourceDtoList);
                 }
                 // container.SecurityResourceDtoList.AddRange(submenuList);
              
                                              
            }
            return container;
        }
    }
}
