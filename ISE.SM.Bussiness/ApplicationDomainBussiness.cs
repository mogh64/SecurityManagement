using ISE.Framework.Server.Core.BussinessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.DataAccess;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Bussiness
{
    public class ApplicationDomainBussiness : BussinessBase<ApplicationDomain, ApplicationDomainDto>
    {
        public ApplicationDomainBussiness()
        {
            this.dataAccess = new AppDomainTDataAccess();
        }
        public ApplicationDomainDtoContainer GetUserAppDomainList(long userId)
        {
            ApplicationDomainDtoContainer container = new ApplicationDomainDtoContainer();
            AccountTDataAccess accDa = new AccountTDataAccess();
            var accounts = accDa.GetAll(it => it.UserId == userId);
            foreach (var acc in accounts)
            {
                foreach (var app in acc.ApplicationDomainDtoList)
                {
                    if (!container.ApplicationDomainDtoList.Exists(it => it.ApplicationDomainId == app.ApplicationDomainId))
                    {
                        container.ApplicationDomainDtoList.Add(app);
                    }
                }
            }
            LoginTypeTDataAccess loginTypeDa = new LoginTypeTDataAccess();
            var loginTypeList = loginTypeDa.GetAll();
            if (loginTypeList != null && loginTypeList.Count > 0)
            {
                container.LoginTypeDtoList.AddRange(loginTypeList);
            }
            return container;
        }
    }
}
