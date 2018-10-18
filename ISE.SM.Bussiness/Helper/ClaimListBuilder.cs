using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Helper
{
    public class ClaimListBuilder
    {
        public ClaimListBuilder() { }
        public List<Claim> GetIdentityClaimList(AccountDto account, SignInMessage sgnMessage)
        {
             List<Claim> claimList = new List<Claim>();
            if(account!=null){
                SecurityUserBussiness userBussiness = new SecurityUserBussiness();
                var user =  userBussiness.GetSingle(it => it.UserId == account.UserId);
                if (user != null)
                {
                    Claim subjectClaim = new Claim()
                    {
                        Type = ClaimTypes.Subject,
                        Value = user.UserId.ToString()
                    };
                    claimList.Add(subjectClaim);

                    Claim fnameClaim = new Claim()
                    {
                        Type = ClaimTypes.Name,
                        Value = user.FirstName
                    };
                   
                    claimList.Add(fnameClaim);
                    Claim perId = new Claim()
                    {
                        Type = ClaimTypes.PersonId,
                        Value = user.PerId.ToString()
                    };
                    claimList.Add(perId);
                    Claim lnameClaim = new Claim()
                    {
                        Type = ClaimTypes.FamilyName,
                        Value = user.LastName
                    };
                    claimList.Add(lnameClaim);

                    Claim unameClaim = new Claim()
                    {
                        Type = ClaimTypes.PreferredUserName,
                        Value = account.Username
                    };
                    claimList.Add(unameClaim);
                    
                    Claim clientIdClaim = new Claim()
                    {
                        Type = ClaimTypes.ClientId,
                        Value = sgnMessage.ClientId
                    };
                    claimList.Add(clientIdClaim);


                    Claim expClaim = new Claim()
                    {
                        Type = ClaimTypes.Expiration,
                        Value = string.Empty
                    };                    
                    if (account.ExpiredDate.HasValue)
                    {
                        expClaim.Value = account.ExpiredDate.Value.ToString("yyyy-MM-dd HH:mm tt");
                    }
                    claimList.Add(expClaim);
                    var roleIds =  userBussiness.GetUserRoleIds(user.UserId);
                    foreach (var roleId in roleIds)
                    {
                         Claim roleClaim = new Claim()
                         {
                             Type = ClaimTypes.Role,
                             Value = roleId.ToString()
                         };
                         claimList.Add(roleClaim);
                    }
                    var groupIds = userBussiness.GetUserGroupIds(user.UserId);
                    foreach (var groupId in groupIds)
                    {
                        Claim groupClaim = new Claim()
                        {
                            Type = ClaimTypes.Group,
                            Value = groupId.ToString()
                        };
                        claimList.Add(groupClaim);
                    }
                }           
            }
            

            return claimList;
        }
        public List<Claim> GetAccessClaimList(AccountDto account, SignInMessage sgnMessage)
        {
            List<Claim> claimList = new List<Claim>();
            if (account != null)
            {
                SecurityUserBussiness userBussiness = new SecurityUserBussiness();
                var user = userBussiness.GetSingle(it => it.UserId == account.UserId);
                if (user != null)
                {
                                    
                }
            }


            return claimList;
        }
    }
}
