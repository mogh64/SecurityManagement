using ISE.ClassLibrary;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Common.Message
{
    public class UserInfoGenerator
    {
        public static UserInformation GenerateUserInfo(AccessToken aToken,IdentityToken iToke)
        {
            int userId = 0;
            int perId=0;
            int actionId = -1;
            bool noUpdate = false;
            int.TryParse(iToke.ClaimValue(ClaimTypes.Subject), out userId);
            string fname= iToke.ClaimValue(ClaimTypes.Name);
            string lname= iToke.ClaimValue(ClaimTypes.FamilyName);
            string userName = iToke.ClaimValue(ClaimTypes.PreferredUserName);
            int.TryParse(iToke.ClaimValue(ClaimTypes.PersonId),out perId);
            var actionOperation = aToken.Operations.Where(it => it.IsActionId>0).FirstOrDefault();
            var viewOperation = aToken.Operations.Where(it => it.OperationName.ToLower() == "view").FirstOrDefault();
            if (actionOperation != null)
            {
                actionId = (int)actionOperation.OperationId;
            }
            if (viewOperation != null && aToken.Operations.Count == 1)
            {
                noUpdate = true;
            }
            UserInformation userInfo = new UserInformation(userId, userName, fname, lname, perId, actionId, noUpdate);
            return userInfo;
        }
    }
}
