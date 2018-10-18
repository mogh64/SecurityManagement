using ISE.Framework.Server.Core.DataAccessBase;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using ISE.SM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.DataAccess
{
    public class ResourceTDataAccess : TDataAccess<SecurityResource, SecurityResourceDto, SecurityResourceRepository>
    {
        public ResourceTDataAccess()
            : base(new SecurityResourceRepository())
        {
        }
        public List<OperationDto> RoleOperations(Common.DTO.RoleDto role, Common.DTO.SecurityResourceDto resource)
        {
            List<OperationDto> lst = new List<OperationDto>();
            var operations =  this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == role.RoleId && it.Permission.ResourceId == resource.SecurityResourceId).Select(it=>it.Permission.Operation).ToList();
            foreach (var operation in operations)
            {
                var dto = OperationRepository.GetDto(operation);
                lst.Add(dto);
            }

            return lst;
        }

        public List<OperationDto> UserOperations(Common.DTO.UserDto user, Common.DTO.SecurityResourceDto resource)
        {
            List<OperationDto> lst = new List<OperationDto>();
            var operations = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == user.UserId && it.Permission.ResourceId == resource.SecurityResourceId).Select(it => it.Permission.Operation).ToList();
            foreach (var operation in operations)
            {
                var dto = OperationRepository.GetDto(operation);
                lst.Add(dto);
            }

            return lst;
        }
        public List<OperationDto> GroupOperations(Common.DTO.SecurityGroupDto group, Common.DTO.SecurityResourceDto resource)
        {

            List<OperationDto> lst = new List<OperationDto>();
            var roles = this.Repository.Context.RoleToGroups.Where(it => it.GroupId == group.SecurityGroupId).Select(it=>it.Role).ToList();
            foreach (var role in roles)
            {
                var operations = this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == role.RoleId && it.Permission.ResourceId == resource.SecurityResourceId).Select(it => it.Permission.Operation);
                var operationDtos = OperationRepository.GetDtos(operations);
                lst.AddRange(operationDtos);
            }                      

            return lst;
        }
        public List<SecurityResourceDto> GetResourceAccessList(int resourceTypeId, int appDomainId, long userId)
        {
            List<SecurityResourceDto> list=new List<SecurityResourceDto>();
            var resources = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId && it.Permission.Securityresource.AppDomainId==appDomainId && it.Permission.Securityresource.ResourceTypeId==resourceTypeId).Select(it => it.Permission.Securityresource).Distinct();
            var dtos = SecurityResourceRepository.GetDtos(resources);
            list.AddRange(dtos);
            return list;
        }
        public List<SecurityResourceDto> GetMenuAccessList( int appDomainId, long userId)
        {
            List<SecurityResourceDto> list = new List<SecurityResourceDto>();
            var resources = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId && it.Permission.Securityresource.AppDomainId == appDomainId && (it.Permission.Securityresource.ResourceTypeId == 0 || it.Permission.Securityresource.ResourceTypeId == 1)).Select(it => it.Permission.Securityresource).Distinct();
            var dtos = SecurityResourceRepository.GetDtos(resources);
            list.AddRange(dtos);
            return list;
        }
    }
}
