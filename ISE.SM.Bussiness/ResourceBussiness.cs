using ISE.Framework.Common.Service.Message;
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
    public class ResourceBussiness : BussinessBase<SecurityResource, SecurityResourceDto>
    {
        public ResourceBussiness()
        {
            this.dataAccess = new ResourceTDataAccess();
        }
        public Common.DTOContainer.OperationDtoContainer RoleOperations(Common.DTO.RoleDto role, Common.DTO.SecurityResourceDto resource)
        {
            var operations = ((ResourceTDataAccess)this.dataAccess).RoleOperations(role, resource);
            OperationDtoContainer container = new OperationDtoContainer();
            if (operations != null && operations.Count>0)
            {
                container.OperationDtoList.AddRange(operations);
            }
            return container;
        }

        public Common.DTOContainer.OperationDtoContainer UserOperations(Common.DTO.UserDto user, Common.DTO.SecurityResourceDto resource)
        {
            var operations = ((ResourceTDataAccess)this.dataAccess).UserOperations(user, resource);
            OperationDtoContainer container = new OperationDtoContainer();
            if (operations != null && operations.Count > 0)
            {
                container.OperationDtoList.AddRange(operations);
            }
            return container;
        }
        public PermissionDto AddOperation(SecurityResourceDto resource, OperationDto operationDto)
        {
            PermissionDto response = new PermissionDto();
            PermissionTDataAccess rtoDa = new PermissionTDataAccess();
            var relations = rtoDa.GetSingle(it => it.ResourceId == resource.SecurityResourceId && it.OperationId == operationDto.OperationId);
            if (relations == null)
            {
                response = new PermissionDto() 
                {
                    ResourceId = resource.SecurityResourceId,
                    OperationId = operationDto.OperationId
                };
                rtoDa.Insert(response);
            }
            else
            {
                response.Response.AddBusinessException("ارتباط قبلا تعریف شده است!", BusinessExceptionEnum.Operational);
            }
            return response;
        }
        public PermissionDtoContainer AddOperations(SecurityResourceDto resource, List<OperationDto> operationDtos)
        {
            PermissionDtoContainer responseContainer = new PermissionDtoContainer();
            PermissionTDataAccess rtoDa = new PermissionTDataAccess();
            List<PermissionDto> insertList = new List<PermissionDto>();
            foreach (var operationDto in operationDtos)
            {
                var relations = rtoDa.GetSingle(it => it.ResourceId == resource.SecurityResourceId && it.OperationId == operationDto.OperationId);
                if (relations == null)
                {
                    PermissionDto dto = new PermissionDto()
                    {
                        ResourceId = resource.SecurityResourceId,
                        OperationId = operationDto.OperationId
                    };
                    insertList.Add(dto);
                    responseContainer.PermissionDtoList.Add(dto);
                }
                //else
                //{
                //    PermissionDto response = new PermissionDto();
                //    resource.SetIdentity(operationDto.Id);
                //    response.Response.AddBusinessException("ارتباط قبلا تعریف شده است!", BusinessExceptionEnum.Operational);
                  
                //}
            }
            if (insertList.Count>0)
                rtoDa.Insert(insertList);

            return responseContainer;
        }
        public List<SecurityResourceDto> GetResourceAccessList(int resourceTypeId, int appDomainId, long userId)
        {
            var result = ((ResourceTDataAccess)this.dataAccess).GetResourceAccessList(resourceTypeId, appDomainId, userId);
            return result;
        }
        public List<OperationDto> GetAllUserOperations(int securityUserId, long securityResourceId)
        {
            List<OperationDto> operations = new List<OperationDto>();
            SecurityUserBussiness userBs = new SecurityUserBussiness();
            ResourceBussiness resourceBa=new ResourceBussiness();
            GroupBussiness groupBa=new GroupBussiness();
            var resource = resourceBa.GetSingle(it=>it.SecurityResourceId==securityResourceId);
            var user = userBs.GetUserById(securityUserId);
            var userOps = UserOperations(user, resource);
            operations.AddRange(userOps.OperationDtoList);
            foreach (var role in user.Roles)
            {
                var roleOps = RoleOperations(role, resource);
                foreach (var roleOp in roleOps.OperationDtoList)
                {
                    if (!operations.Exists(it => it.OperationId == roleOp.OperationId))
                        operations.Add(roleOp);
                }
            }
            foreach (var group in user.Groups)
            {
                var roles = groupBa.AssignedRoles(group.SecurityGroupId);
                foreach (var role in roles.RoleDtoList)
                {
                     var roleOps = RoleOperations(role, resource);
                     foreach (var roleOp in roleOps.OperationDtoList)
                     {
                         if (!operations.Exists(it => it.OperationId == roleOp.OperationId))
                             operations.Add(roleOp);
                     }
                }
            }
            return operations;
        }
        public ResponseDto RemoveOperation(SecurityResourceDto resource, OperationDto operationDto)
        {
            ResponseDto response = new ResponseDto();
            PermissionTDataAccess permissionDa = new PermissionTDataAccess();
            var permission = permissionDa.GetSingle(it => it.ResourceId == resource.SecurityResourceId && it.OperationId == operationDto.OperationId);
            if (permission != null) {
                permissionDa.Delete(permission);
            }
            else
            {
                response.Response.AddBusinessException("این دسترسی تعریف نشده است!", BusinessExceptionEnum.Operational);
            }
            return response;
        }
    }
}
