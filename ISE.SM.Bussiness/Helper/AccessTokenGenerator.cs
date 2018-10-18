using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Helper
{
    public class AccessTokenGenerator
    {
        public AccessToken GenerateToken(IdentityToken identityToken, SecurityResourceDto resource)
        {
            AccessToken token = new AccessToken();

            ResourceBussiness resourceBa = new ResourceBussiness();
            
            var secutiryResource = resourceBa.GetSingle(it => it.SecurityResourceId == resource.SecurityResourceId);
           
            int userId=0;
            long resourceId=0;
            if (secutiryResource != null)
                resourceId = secutiryResource.SecurityResourceId;
            int.TryParse(identityToken.SubjectId,out userId);

            var operationList = resourceBa.GetAllUserOperations(userId, resourceId);
            token.Operations.AddRange(operationList);
            token.Resource = secutiryResource;
            token.UserName = identityToken.UserName;
            return token;
        }
    }
}
