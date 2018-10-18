using ISE.Framework.Client.Common.ExceptionManager;
using ISE.Framework.Common.Service;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Client.Common.Presenter
{
    public class AppDomainPresenter
    {
        private ServiceAdapter<IApplicationDomainService> AppDomainServiceAdapter;
        private ServiceAdapter<IDataService> DataServiceAdapter;
        public AppDomainPresenter()
        {
            IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
            AppDomainServiceAdapter = new ServiceAdapter<IApplicationDomainService>(exceptionManager);
            DataServiceAdapter = new ServiceAdapter<IDataService>(exceptionManager);
        }
        public List<ApplicationDomainDto> GetAppDomainList()
        {
            var container = DataServiceAdapter.Execute(it => it.GetAppDomainList());
            if (container.Response.HasException)
            {
                return null;
            }
            return container.ApplicationDomainDtoList;
        }
        public ApplicationDomainDtoContainer GetAppDomainContainer(long userId)
        {
            var container = DataServiceAdapter.Execute(it => it.GetUserAppDomainList(userId));
            if (container.Response.HasException)
            {
                return null;
            }
            return container;
        }
        public ApplicationDomainDtoContainer GetAppDomainContainer()
        {
            var container = DataServiceAdapter.Execute(it => it.GetAppDomainList());
            if (container.Response.HasException)
            {
                return null;
            }
            return container;
        }
        public List<ResourceTypeDto> GetResourceTypeList()
        {
            var container = DataServiceAdapter.Execute(it => it.GetResourceTypeList());
            if (container.Response.HasException)
            {
                return null;
            }
            return container.ResourceTypeDtoList;
        }
        public ApplicationDomainDto Insert(ApplicationDomainDto appDomain)
        {

            ApplicationDomainDto result = (ApplicationDomainDto)AppDomainServiceAdapter.Execute(s => s.Insert(appDomain));
            if (result.Response.HasException)
            {
                return null;
            }
            appDomain.ApplicationDomainId = result.ApplicationDomainId;
            return appDomain;
        }
        public bool Update(ApplicationDomainDto appDomain)
        {

            ResponseDto response = AppDomainServiceAdapter.Execute(s => s.Update(appDomain));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public bool Remove(ApplicationDomainDto appDomain)
        {

            ResponseDto response = AppDomainServiceAdapter.Execute(s => s.Delete(appDomain));
            if (response.Response.HasException)
            {
                return false;
            }
            return true;
        }
        public string TestResult()
        {
            var result = DataServiceAdapter.Execute(s => s.TestUserLog());

            return result.ComputerName;
        }
        public string TestWaitResult()
        {
            var result = DataServiceAdapter.Execute(s => s.TestWaitUserLog());

            return result.ComputerName;
        }
    }
}
