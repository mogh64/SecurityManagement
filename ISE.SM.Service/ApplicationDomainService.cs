using ISE.Framework.Common.Aspects;
using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Service.Message;
using ISE.SM.Bussiness;
using ISE.SM.Common.Contract;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class ApplicationDomainService : ContextBoundObject,IApplicationDomainService
    {
        ApplicationDomainBussiness appDomainBussiness = new ApplicationDomainBussiness();
        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = appDomainBussiness.GetAll();
            ApplicationDomainDtoContainer container = new ApplicationDomainDtoContainer()
            {
                ApplicationDomainDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<ApplicationDomain>(predicate);
            ApplicationDomainDtoContainer container = new ApplicationDomainDtoContainer();
            var dtoResult = appDomainBussiness.GetAll(pars);
            container.ApplicationDomainDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAll(int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.CommonBase.DtoContainer PagedResultGetAllByCondition(string predicate, int page, int pageCount)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = appDomainBussiness.GetSingle(it => it.ApplicationDomainId == id);
            return result;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<ApplicationDomainDto> lst = dtoList.PersistanceList.Cast<ApplicationDomainDto>().ToList();
            appDomainBussiness.Insert(lst);
            ApplicationDomainDtoContainer container = new ApplicationDomainDtoContainer()
            {
                ApplicationDomainDtoList = lst
            };
            return container;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            appDomainBussiness.Insert((ApplicationDomainDto)dto);
            return dto;
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<ApplicationDomainDto> lst = dtoList.PersistanceList.Cast<ApplicationDomainDto>().ToList();
            appDomainBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            appDomainBussiness.Delete((ApplicationDomainDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            throw new NotImplementedException();
        }

        public Framework.Common.Service.Message.ResponseDto Update(Framework.Common.CommonBase.BaseDto dto)
        {
            appDomainBussiness.Update((ApplicationDomainDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }
    }
}
