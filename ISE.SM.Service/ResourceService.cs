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

namespace ISE.SM.Service
{
    [Intercept]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, UseSynchronizationContext = false, AddressFilterMode = AddressFilterMode.Any)]
    public class ResourceService : ContextBoundObject, IResourceService
    {
        ResourceBussiness resourceBussiness = new ResourceBussiness();
        public Common.DTOContainer.OperationDtoContainer RoleOperations(Common.DTO.RoleDto role, Common.DTO.SecurityResourceDto resource)
        {
            return resourceBussiness.RoleOperations(role, resource);           
        }

        public Common.DTOContainer.OperationDtoContainer UserOperations(Common.DTO.UserDto user, Common.DTO.SecurityResourceDto resource)
        {
            return resourceBussiness.UserOperations(user, resource);
        }

        public Framework.Common.Service.Message.ResponseDto Delete(Framework.Common.CommonBase.BaseDto dto)
        {
            resourceBussiness.Delete((SecurityResourceDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer DeleteBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityResourceDto> lst = dtoList.PersistanceList.Cast<SecurityResourceDto>().ToList();
            resourceBussiness.Delete(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public Framework.Common.CommonBase.DtoContainer GetAll()
        {
            var result = resourceBussiness.GetAll();
            SecurityResourceDtoContainer container = new SecurityResourceDtoContainer()
            {
                SecurityResourceDtoList = result.ToList()
            };

            return container;
        }

        public Framework.Common.CommonBase.DtoContainer GetAllByCondition(string predicate)
        {
            var pars = EntityHelper.ConvertExpression<SecurityResource>(predicate);
            SecurityResourceDtoContainer container = new SecurityResourceDtoContainer();
            var dtoResult = resourceBussiness.GetAll(pars);
            container.SecurityResourceDtoList.AddRange(dtoResult);
            return container;
        }

        public Framework.Common.CommonBase.BaseDto GetSingle(long id)
        {
            var result = resourceBussiness.GetSingle(it => it.SecurityResourceId == id);
            return result;
        }

        public Framework.Common.CommonBase.BaseDto Insert(Framework.Common.CommonBase.BaseDto dto)
        {
            resourceBussiness.Insert((SecurityResourceDto)dto);
            return dto;
        }

        public Framework.Common.CommonBase.DtoContainer InsertBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityResourceDto> lst = dtoList.PersistanceList.Cast<SecurityResourceDto>().ToList();
            resourceBussiness.Insert(lst);
            SecurityResourceDtoContainer container = new SecurityResourceDtoContainer()
            {
                SecurityResourceDtoList = lst
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
            resourceBussiness.Update((SecurityResourceDto)dto);
            return ResponseBuilder.GetResponse(dto);
        }

        public Framework.Common.Service.Message.ResponseDtoContainer UpdateBatch(Framework.Common.PersistantPackage.PersistanceBox dtoList)
        {
            List<SecurityResourceDto> lst = dtoList.PersistanceList.Cast<SecurityResourceDto>().ToList();
            resourceBussiness.Update(lst);
            return ResponseBuilder.GetResponse(dtoList.PersistanceList);
        }

        public void UpdatePackage(Framework.Common.PersistantPackage.UpdatePackageBox updatePackage)
        {
            throw new NotImplementedException();
        }


        public PermissionDto AddOperation(SecurityResourceDto resource, OperationDto operationDto)
        {
            return resourceBussiness.AddOperation(resource, operationDto);
        }


        public PermissionDtoContainer AddOperations(SecurityResourceDto resource, List<OperationDto> operationDtos)
        {
            return resourceBussiness.AddOperations(resource, operationDtos);
        }


        public ResponseDto RemoveOperation(SecurityResourceDto resource, OperationDto operationDto)
        {
            return resourceBussiness.RemoveOperation(resource, operationDto);
        }
    }
}
