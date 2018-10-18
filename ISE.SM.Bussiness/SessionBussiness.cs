using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Common.Utils;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class SessionBussiness : BussinessBase<SecuritySession, SecuritySessionDto>
    {
        public SessionBussiness()
        {
            this.dataAccess = new SessionTDataAccess();
        }
        public SecuritySessionDto CreateSession(AccountDto account, string appDomainId)
        {
            try
            {
                if (account != null)
                {
                    int appId = 0;
                    int.TryParse(appDomainId, out appId);
                    SecuritySessionDto sessionDto = new SecuritySessionDto()
                    {
                        AccountId = account.AccountId,
                        AppDomainId = appId,
                        CreateDate = DateTime.Now,
                        SecuritySessionId = SessionIdGenerator.GenrateNewSessionId(),
                    };
                    this.Insert(sessionDto);
                    return sessionDto;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void ExpireSession(string sessionId)
        {
            

            var session = this.GetSingle(it => it.SecuritySessionId == sessionId);
            if (session != null)
            {
                session.ExpiredDate = DateTime.Now;
            }
            this.Update(session);
        }
        public SecuritySessionDtoContainer GetOnlineUsers(int appdomainId)
        {
            SecuritySessionDtoContainer container = new SecuritySessionDtoContainer();
             
            if (appdomainId == 0) // for all appdomains
            {
                var onSessions = this.GetAll(it => it.ExpiredDate == null);
                foreach (var session in onSessions)
                {
                   
                }
            }
            else if (appdomainId > 0)
            {

            }
            return container;
        }
    }
}
