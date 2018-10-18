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
    public class SecurityCompanyService : ContextBoundObject, ISecurityCompanyService
    {
        SecurityCompanyBussiness securityCompanyBussiness = new SecurityCompanyBussiness();
        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            securityCompanyBussiness.Delete((CompanyDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<CompanyDto> lst = dtoList.PersistanceList.Cast<CompanyDto>().ToList();
            securityCompanyBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = securityCompanyBussiness.GetAll();
            CompanyDtoContainer container = new CompanyDtoContainer()
            {
                CompanyDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<Company>(predicate);
            CompanyDtoContainer container = new CompanyDtoContainer();
            var dtoResult = securityCompanyBussiness.GetAll(pars);
            container.CompanyDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = securityCompanyBussiness.GetSingle(it => it.CompanyId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            securityCompanyBussiness.Insert((CompanyDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<CompanyDto> lst = dtoList.PersistanceList.Cast<CompanyDto>().ToList();
            securityCompanyBussiness.Insert(lst);
            CompanyDtoContainer container = new CompanyDtoContainer()
            {
                CompanyDtoList = lst
            };
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

        public Framework.Common.Service.Message.ResponseDto Update(Framework.Common.CommonBase.BaseDto dto)
        {
            securityCompanyBussiness.Update((CompanyDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<CompanyDto> lst = dtoList.PersistanceList.Cast<CompanyDto>().ToList();
            securityCompanyBussiness.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }
    }
}
