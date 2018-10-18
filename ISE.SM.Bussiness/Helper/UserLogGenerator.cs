using ISE.SM.Common.DTO;
using ISE.SM.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness.Helper
{
    public class UserLogGenerator
    {
        public UserLogGenerator()
        { 
        }
        public static void GenerateUserLog(string sessionId, string userId, string accountId, string appDomainId, string action, string actionParams, string description)
        {
            SecurityUserLogBussiness logBs = new SecurityUserLogBussiness();
           
          
            long _userId = -1;
            long.TryParse(userId, out _userId);
            long _accountId = -1;
            long.TryParse(accountId, out _accountId);
            int _appDomainId = -1;
            int.TryParse(appDomainId, out _appDomainId);
            SecurityUserLogDto log=new SecurityUserLogDto(){
                AccountId = _accountId,
                Action = action,
                ActionParam = actionParams,
                AppDomainId = _appDomainId,
                Description=description,
                SessionId = sessionId,
                UserId = _userId
            };
            try
            {
                logBs.Insert(log);
            }
            catch
            {

            }
        }
    }
}
