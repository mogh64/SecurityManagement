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
    public class OperationService : ContextBoundObject, IOperationService
    {
        OperationBussiness operationBs = new OperationBussiness();
        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            operationBs.Delete((OperationDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<OperationDto> lst = dtoList.PersistanceList.Cast<OperationDto>().ToList();
            operationBs.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = operationBs.GetAll();
            OperationDtoContainer container = new OperationDtoContainer()
            {
                OperationDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<Operation>(predicate);
            OperationDtoContainer container = new OperationDtoContainer();
            var dtoResult = operationBs.GetAll(pars);
            container.OperationDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = operationBs.GetSingle(it => it.OperationId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            operationBs.Insert((OperationDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<OperationDto> lst = dtoList.PersistanceList.Cast<OperationDto>().ToList();
            operationBs.Insert(lst);
            OperationDtoContainer container = new OperationDtoContainer()
            {
                OperationDtoList = lst
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
            operationBs.Update((OperationDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<OperationDto> lst = dtoList.PersistanceList.Cast<OperationDto>().ToList();
            operationBs.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }
    }
}
