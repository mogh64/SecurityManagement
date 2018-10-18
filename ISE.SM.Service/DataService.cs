using ISE.Framework.Common.Aspects;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTOContainer;
using ISE.SM.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class DataService : ContextBoundObject,IDataService
    {

        public ApplicationDomainDtoContainer GetAppDomainList()
        {
            ApplicationDomainDtoContainer container = new ApplicationDomainDtoContainer();
            AppDomainTDataAccess appDomainDa = new AppDomainTDataAccess();
            LoginTypeTDataAccess loginTypeDa = new LoginTypeTDataAccess();
            var appDomainList = appDomainDa.GetAll();
            var loginTypeList = loginTypeDa.GetAll();
            if (appDomainList != null && appDomainList.Count>0)
               container.ApplicationDomainDtoList.AddRange(appDomainList);
            if (loginTypeList != null && loginTypeList.Count > 0)
            {
                container.LoginTypeDtoList.AddRange(loginTypeList);
            }
            return container;
        }


        public ResourceTypeDtoContainer GetResourceTypeList()
        {
            ResourceTypeDtoContainer container = new ResourceTypeDtoContainer();
            ResourceTypeTDataAccess resourceTypeDa = new ResourceTypeTDataAccess();
            var lst = resourceTypeDa.GetAll().ToList();
            container.ResourceTypeDtoList.AddRange(lst);
            return container;
        }


        public ApplicationDomainDtoContainer GetUserAppDomainList(long userId)
        {
            ApplicationDomainBussiness appBs = new ApplicationDomainBussiness();
            return appBs.GetUserAppDomainList(userId);
        }


        public Common.DTO.UserLogDto TestUserLog()
        {
            return new Common.DTO.UserLogDto()
            {
                ComputerName="aa"
            };
        }


        public Common.DTO.UserLogDto TestWaitUserLog()
        {
            Thread.Sleep(10000);
            return new Common.DTO.UserLogDto()
            {
                ComputerName = "aw"
            };
        }
    }
}
