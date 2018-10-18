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
    public class PermissionTDataAccess : TDataAccess<Permission, PermissionDto, PermissionRepository>
    {
        public PermissionTDataAccess()
            : base(new PermissionRepository())
        {
        }
        public override IList<PermissionDto> GetAll()
        {
            OperationTDataAccess operationDa = new OperationTDataAccess();
            var result=base.GetAll();
            foreach (var item in result)
            {
                var operation = operationDa.GetSingle(it => it.OperationId == item.OperationId);
                if (operation != null)
                {
                    item.OperationDto = operation;
                }
            }
            return result;
        }
        public List<PermissionDto> GetUserPermissions(long userId)
        {
             List<PermissionDto> permissionDtos=new List<PermissionDto>();
            var permissions =  this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId).Select(it=>it.Permission).ToList();
            foreach (var permission in permissions)
        	{
        		 var dto = PermissionRepository.GetDto(permission);
                 permissionDtos.Add(dto);
        	}
            return permissionDtos;
        }
        public List<PermissionDto> GetUserPermissions(long userId,int resourceId)
        {
            List<PermissionDto> permissionDtos = new List<PermissionDto>();
            var permissions = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId && it.Permission.ResourceId==resourceId).Select(it => it.Permission).ToList();
            foreach (var permission in permissions)
            {
                var dto = PermissionRepository.GetDto(permission);
                permissionDtos.Add(dto);
            }
            return permissionDtos;
        }
        public List<PermissionDto> GetRolePermissions(int roleId)
        {
            List<PermissionDto> permissionDtos = new List<PermissionDto>();
            var permissions = this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == roleId).Select(it => it.Permission).ToList();
            foreach (var permission in permissions)
            {
                var dto = PermissionRepository.GetDto(permission);
                permissionDtos.Add(dto);
            }
            return permissionDtos;
        }
        public List<PermissionDto> GetRolePermissions(int roleId,int resourceId)
        {
            List<PermissionDto> permissionDtos = new List<PermissionDto>();
            var permissions = this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == roleId && it.Permission.ResourceId == resourceId).Select(it => it.Permission).ToList();
            foreach (var permission in permissions)
            {
                var dto = PermissionRepository.GetDto(permission);
                permissionDtos.Add(dto);
            }
            return permissionDtos;
        }
        public List<PermissionDto> GetGroupPermissions(int groupId)
        {
            List<PermissionDto> permissionDtos = new List<PermissionDto>();
            GroupTDataAccess groupDa = new GroupTDataAccess();
            var roles = groupDa.GetGroupRoles(groupId);
            foreach (var role in roles)
            {
                var dtoList = GetRolePermissions(role.RoleId);
                if (dtoList != null && dtoList.Count > 0)
                {
                    permissionDtos.AddRange(dtoList);
                }
            }
            return permissionDtos;
        }
        public List<PermissionDto> GetGroupPermissions(int groupId, int resourceId)
        {
            List<PermissionDto> permissionDtos = new List<PermissionDto>();
            GroupTDataAccess groupDa = new GroupTDataAccess();
            var roles = groupDa.GetGroupRoles(groupId);
            foreach (var role in roles)
            {
                var dtoList = GetRolePermissions(role.RoleId,resourceId);
                if (dtoList != null && dtoList.Count > 0)
                {
                    permissionDtos.AddRange(dtoList);
                }
            }
            return permissionDtos;
        }
        public PermissionDtoContainer GetAllUserPermissions(long userId)
        {
            SecurityUserTDataAccess userDa=new SecurityUserTDataAccess();
            PermissionDtoContainer container = new PermissionDtoContainer();
            ResourceTDataAccess rda = new ResourceTDataAccess();
            var resources = rda.GetAll();
            var permissions = this.GetAll();
            container.PermissionDtoList.AddRange(permissions);
            container.SecurityResourceDtoList.AddRange(resources);
            
            var opRes = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId).Select(x => new { permission = x.Permission, operation = x.Permission.Operation, resource = x.Permission.Securityresource,AccessType=x.PermissionAccess }).ToList();
            var opRoles = (from ur in this.Repository.Context.UserToRoles
                          join pu in this.Repository.Context.PermissionToRoles on ur.RoleId equals pu.RoleId
                          where ur.UserId == userId
                          select new { permission = pu.Permission, operation = pu.Permission.Operation, resource = pu.Permission.Securityresource, AccessType = pu.PermisssionAccess,Role = ur.Role}).ToList();
            var userGroups= userDa.GetUserGroupIds(userId);
            var opGroups = (from rg in this.Repository.Context.RoleToGroups                          
                           join pr in this.Repository.Context.PermissionToRoles on rg.RoleId equals pr.RoleId
                           where userGroups.Contains(rg.GroupId.Value)
                            select new { permission = pr.Permission, operation = pr.Permission.Operation, resource = pr.Permission.Securityresource, AccessType = pr.PermisssionAccess,Group = rg.Securitygroup }).ToList();
            foreach (var item in opRes)
            {
                var permission = container.PermissionDtoList.FirstOrDefault(it=>it.PermissionId==item.permission.PermissionId);               
                var resource = item.resource;
                permission.IsToUser = true;       
                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.SecurityResourceDto.Checked = true;
                
                
                if (item.AccessType == 0)
                    permission.AccessType = Common.Enums.AccessType.None;
                if (item.AccessType == -1)
                    permission.AccessType = Common.Enums.AccessType.Deny;
                if (item.AccessType == 1)
                {
                    permission.AccessType = Common.Enums.AccessType.Access;
                    permission.OperationDto.Checked = true;
                    ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);          
                }
                
            }
            foreach (var item in opRoles)
            {
                var permission = container.PermissionDtoList.FirstOrDefault(it => it.PermissionId == item.permission.PermissionId);
                if (permission.SecurityResourceDto == null)
                {
                    var resource = item.resource;

                    permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                    permission.SecurityResourceDto.Checked = true;


                    if (item.AccessType == 0)
                        permission.AccessType = Common.Enums.AccessType.None;
                    if (item.AccessType == -1)
                        permission.AccessType = Common.Enums.AccessType.Deny;
                    if (item.AccessType == 1)
                    {
                        permission.AccessType = Common.Enums.AccessType.Access;
                        permission.OperationDto.Checked = true;
                        ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);
                    }
                }
                permission.RoleDtos.Add(RoleRepository.GetDto(item.Role));
                

            }
            foreach (var item in opGroups)
            {
                var permission = container.PermissionDtoList.FirstOrDefault(it => it.PermissionId == item.permission.PermissionId);
                if (permission.SecurityResourceDto == null)
                {
                    var resource = item.resource;

                    permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                    permission.SecurityResourceDto.Checked = true;


                    if (item.AccessType == 0)
                        permission.AccessType = Common.Enums.AccessType.None;
                    if (item.AccessType == -1)
                        permission.AccessType = Common.Enums.AccessType.Deny;
                    if (item.AccessType == 1)
                    {
                        permission.AccessType = Common.Enums.AccessType.Access;
                        permission.OperationDto.Checked = true;
                        ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);
                    }
                }
                permission.GroupDtos.Add(SecurityGroupRepository.GetDto(item.Group));


            }
            return container;
        }
        public PermissionDtoContainer GetCurrentUserPermissions(long userId)
        {
            PermissionDtoContainer container = new PermissionDtoContainer();
            SecurityUserTDataAccess userDa = new SecurityUserTDataAccess();

            var opRes = this.Repository.Context.PermissionToUsers.Where(it => it.UserId == userId).Select(x => new { permission = x.Permission, operation = x.Permission.Operation, resource = x.Permission.Securityresource, AccessType = x.PermissionAccess }).ToList();

            //TODO Make faster
            var opRoles = (from ur in this.Repository.Context.UserToRoles
                           join pu in this.Repository.Context.PermissionToRoles on ur.RoleId equals pu.RoleId
                           where ur.UserId == userId
                           select new { permission = pu.Permission, operation = pu.Permission.Operation, resource = pu.Permission.Securityresource, AccessType = pu.PermisssionAccess, Role = ur.Role }).ToList();
            var userGroups = userDa.GetUserGroupIds(userId);
            var opGroups = (from rg in this.Repository.Context.RoleToGroups
                            join pr in this.Repository.Context.PermissionToRoles on rg.RoleId equals pr.RoleId
                            where userGroups.Contains(rg.GroupId.Value)
                            select new { permission = pr.Permission, operation = pr.Permission.Operation, resource = pr.Permission.Securityresource, AccessType = pr.PermisssionAccess, Group = rg.Securitygroup }).ToList();


            foreach (var item in opRes)
            {
                var permission = PermissionRepository.GetDto(item.permission);
                var operatoin = item.operation;
                var resource = item.resource;
                permission.OperationDto = OperationRepository.GetDto(operatoin);
                permission.IsToUser = true;
                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.SecurityResourceDto.Checked = true;
                container.PermissionDtoList.Add(permission);
           
                permission.SecurityResourceDto.Checked = true;
                if (item.AccessType == 0)
                    permission.AccessType = Common.Enums.AccessType.None;
                if (item.AccessType == -1)
                    permission.AccessType = Common.Enums.AccessType.Deny;
                if (item.AccessType == 1)
                {
                    permission.AccessType = Common.Enums.AccessType.Access;
                    permission.OperationDto.Checked = true;
                    AddResources(permission.SecurityResourceDto, container.SecurityResourceDtoList);
                }

            }
            foreach (var item in opRoles)
            {
                var permission = PermissionRepository.GetDto(item.permission);
                var operatoin = item.operation;
                var resource = item.resource;
                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.OperationDto = OperationRepository.GetDto(operatoin);
                if (permission != null)
                {
                    if (permission.SecurityResourceDto == null)
                    {
                       

                        permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                        permission.SecurityResourceDto.Checked = true;


                        if (item.AccessType == 0)
                            permission.AccessType = Common.Enums.AccessType.None;
                        if (item.AccessType == -1)
                            permission.AccessType = Common.Enums.AccessType.Deny;
                        if (item.AccessType == 1)
                        {
                            permission.AccessType = Common.Enums.AccessType.Access;
                            permission.OperationDto.Checked = true;
                            ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);
                        }
                    }
                    permission.RoleDtos.Add(RoleRepository.GetDto(item.Role));
                }
                else
                {
                    var permissionDto = PermissionRepository.GetDto(item.permission);
                    permissionDto.RoleDtos.Add(RoleRepository.GetDto(item.Role));
                    container.PermissionDtoList.Add(permissionDto);
                }


            }
            foreach (var item in opGroups)
            {
                var permission = container.PermissionDtoList.FirstOrDefault(it => it.PermissionId == item.permission.PermissionId);
                if (permission != null)
                {
                    if (permission.SecurityResourceDto == null)
                    {
                        var resource = item.resource;

                        permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                        permission.SecurityResourceDto.Checked = true;


                        if (item.AccessType == 0)
                            permission.AccessType = Common.Enums.AccessType.None;
                        if (item.AccessType == -1)
                            permission.AccessType = Common.Enums.AccessType.Deny;
                        if (item.AccessType == 1)
                        {
                            permission.AccessType = Common.Enums.AccessType.Access;
                            permission.OperationDto.Checked = true;
                            ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);
                        }
                    }
                    permission.GroupDtos.Add(SecurityGroupRepository.GetDto(item.Group));
                }
                else
                {
                    var permissionDto = PermissionRepository.GetDto(item.permission);
                    permissionDto.GroupDtos.Add(SecurityGroupRepository.GetDto(item.Group));
                    container.PermissionDtoList.Add(permissionDto);
                }


            }
            return container;
        }
        public PermissionDtoContainer GetAllRolePermissions(int roleId)
        {
            PermissionDtoContainer container = new PermissionDtoContainer();
            ResourceTDataAccess rda = new ResourceTDataAccess();
            var resources = rda.GetAll();
            var permissions = this.GetAll();
            container.PermissionDtoList.AddRange(permissions);
            container.SecurityResourceDtoList.AddRange(resources);
            var opRes = this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == roleId).Select(x => new { permission = x.Permission, operation = x.Permission.Operation, resource = x.Permission.Securityresource, AccessType = x.PermisssionAccess }).ToList();
            foreach (var item in opRes)
            {
                var permission = container.PermissionDtoList.FirstOrDefault(it => it.PermissionId == item.permission.PermissionId);
                var resource = item.resource;

                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.SecurityResourceDto.Checked = true;


                if (item.AccessType == 0)
                    permission.AccessType = Common.Enums.AccessType.None;
                if (item.AccessType == -1)
                    permission.AccessType = Common.Enums.AccessType.Deny;
                if (item.AccessType == 1)
                {
                    permission.AccessType = Common.Enums.AccessType.Access;
                    permission.OperationDto.Checked = true;
                    ChekckAll(container.SecurityResourceDtoList, resource.SecurityResourceId);
                }

            }
            return container;
        }
        private void ChekckAll(List<SecurityResourceDto> resources, long? resourceId)
        {
            if (resourceId != null)
            {
                var res = resources.FirstOrDefault(it => it.SecurityResourceId == resourceId);
                if (!res.Checked)
                {
                    res.Checked = true;
                    ChekckAll(resources, res.ParentId);
                }
            }
            
            return;

        }
         public PermissionDtoContainer GetGroupPermissionContainer(int groupId)
        {
            PermissionDtoContainer container = new PermissionDtoContainer();
            var opRes = (from g in this.Repository.Context.SecurityGroups
                        join rg in this.Repository.Context.RoleToGroups on g.SecurityGroupId equals rg.GroupId
                        join rp in this.Repository.Context.PermissionToRoles on rg.RoleId equals rp.RoleId
                        where g.SecurityGroupId==groupId && rp.PermisssionAccess>0
                        select new {permission=rp.Permission,operation=rp.Permission.Operation,resource=rp.Permission.Securityresource,AccessType=rp.PermisssionAccess}).ToList();
            foreach (var item in opRes)
            {
                var permission = PermissionRepository.GetDto(item.permission);
                var operatoin = item.operation;
                var resource = item.resource;
                permission.OperationDto = OperationRepository.GetDto(operatoin);

                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.SecurityResourceDto.Checked = true;
                container.PermissionDtoList.Add(permission);
                //  container.SecurityResourceDtoList.Add(permission.SecurityResourceDto);
                permission.SecurityResourceDto.Checked = true;
                if (item.AccessType == 0)
                    permission.AccessType = Common.Enums.AccessType.None;
                if (item.AccessType == -1)
                    permission.AccessType = Common.Enums.AccessType.Deny;
                if (item.AccessType == 1)
                {
                    permission.AccessType = Common.Enums.AccessType.Access;
                    permission.OperationDto.Checked = true;
                    AddResources(permission.SecurityResourceDto, container.SecurityResourceDtoList);
                }

            }
            
            return container;
        }

         public PermissionDtoContainer GetRolePermissionContainer(int roleId)
         {
             PermissionDtoContainer container = new PermissionDtoContainer();
             var opRes = (from r in this.Repository.Context.PermissionToRoles
                          where r.RoleId == roleId
                          select new { permission = r.Permission, operation = r.Permission.Operation, resource = r.Permission.Securityresource, AccessType = r.PermisssionAccess }).ToList();
             foreach (var item in opRes)
             {
                 var permission = PermissionRepository.GetDto(item.permission);
                 var operatoin = item.operation;
                 var resource = item.resource;
                 permission.OperationDto = OperationRepository.GetDto(operatoin);

                 permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                 permission.SecurityResourceDto.Checked = true;
                 container.PermissionDtoList.Add(permission);
                 //  container.SecurityResourceDtoList.Add(permission.SecurityResourceDto);
                 permission.SecurityResourceDto.Checked = true;
                 if (item.AccessType == 0)
                     permission.AccessType = Common.Enums.AccessType.None;
                 if (item.AccessType == -1)
                     permission.AccessType = Common.Enums.AccessType.Deny;
                 if (item.AccessType == 1)
                 {
                     permission.AccessType = Common.Enums.AccessType.Access;
                     permission.OperationDto.Checked = true;
                     AddResources(permission.SecurityResourceDto, container.SecurityResourceDtoList);
                 }

             }

             return container;
         }
       
        public PermissionDtoContainer GetCurrentRolePermissions(int roleId)
        {
            PermissionDtoContainer container = new PermissionDtoContainer();
            var opRes = this.Repository.Context.PermissionToRoles.Where(it => it.RoleId == roleId).Select(x => new { permission = x.Permission, operation = x.Permission.Operation, resource = x.Permission.Securityresource, AccessType = x.PermisssionAccess }).ToList();
            foreach (var item in opRes)
            {
                var permission = PermissionRepository.GetDto(item.permission);
                var operatoin = item.operation;
                var resource = item.resource;
                permission.OperationDto = OperationRepository.GetDto(operatoin);

                permission.SecurityResourceDto = SecurityResourceRepository.GetDto(resource);
                permission.SecurityResourceDto.Checked = true;
                container.PermissionDtoList.Add(permission);
                //  container.SecurityResourceDtoList.Add(permission.SecurityResourceDto);
                permission.SecurityResourceDto.Checked = true;
                if (item.AccessType == 0)
                    permission.AccessType = Common.Enums.AccessType.None;
                if (item.AccessType == -1)
                    permission.AccessType = Common.Enums.AccessType.Deny;
                if (item.AccessType == 1)
                {
                    permission.AccessType = Common.Enums.AccessType.Access;
                    permission.OperationDto.Checked = true;
                    AddResources(permission.SecurityResourceDto, container.SecurityResourceDtoList);
                }

            }
            return container;
        }
        public void AddResources(SecurityResourceDto resource, List<SecurityResourceDto> resources)
        {
            
            if(!resources.Exists(it=>it.SecurityResourceId==resource.SecurityResourceId))
            {
                
                resource.Checked = true;
                resources.Add(resource);
                if (resource.ParentId != null)
                {
                    var dbRes = this.Repository.Context.SecurityResources.Where(it => it.SecurityResourceId == resource.ParentId).FirstOrDefault();
                    var dto = SecurityResourceRepository.GetDto(dbRes);
                    AddResources(dto, resources);
                }
                
            }
            
        }
    }
}
