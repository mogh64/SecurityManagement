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
    public class PermissionBussiness : BussinessBase<Permission, PermissionDto>
    {
        public PermissionBussiness()
        {
            this.dataAccess = new PermissionTDataAccess();
        }
        public Framework.Common.Service.Message.ResponseDto GrantUserPermission(Common.DTO.UserDto user, int permissionId)
        {
            ResponseDto response = new ResponseDto();
            var permission = this.GetSingle(it => it.PermissionId == permissionId);
            if (permission != null)
            {
                PermissionToUserTDataAccess perToUserDa = new PermissionToUserTDataAccess();
                PermissionToUserDto perToUser = new PermissionToUserDto() { 
                    UserId = user.UserId,
                    PermissionId = permissionId
                };
                perToUserDa.Insert(perToUser);
            }
            else
            {

                response.Response.AddBusinessException("چنین دسترسی وجود ندارد", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto RevokeUserPermission(Common.DTO.UserDto user, int permissionId)
        {
            ResponseDto response = new ResponseDto();
            var permission = this.GetSingle(it => it.PermissionId == permissionId);
            if (permission != null)
            {
                PermissionToUserTDataAccess perToUserDa = new PermissionToUserTDataAccess();
                var permissionList = perToUserDa.GetAll(it => it.PermissionId == permissionId && it.UserId == user.UserId).ToList();
                if (permissionList != null && permissionList.Count > 0)
                    perToUserDa.Delete(permissionList);
            }
            else
            {
                response.Response.AddBusinessException("چنین دسترسی وجود ندارد", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto GrantRolePermission(Common.DTO.RoleDto role, int permissionId)
        {
            ResponseDto response = new ResponseDto();
            var permission = this.GetSingle(it => it.PermissionId == permissionId);
            if (permission != null)
            {
                PermissionToRoleTDataAccess pda = new PermissionToRoleTDataAccess();
                var ptorole = pda.GetSingle(it => it.PermissionId == permissionId && it.RoleId == role.RoleId);
                if (ptorole != null && ptorole.PermisssionAccess > 0)
                {
                    response.Response.AddBusinessException("بدلیل وجود محدودیت ایجاد چنین دسترسی غر مجاز می باشد!", BusinessExceptionEnum.Operational);
                    
                }
                else
                {
                    PermissionToRoleTDataAccess perToUserDa = new PermissionToRoleTDataAccess();
                    PermissionToRoleDto perToUser = new PermissionToRoleDto()
                    {
                        RoleId = role.RoleId,
                        PermissionId = permissionId
                    };
                    perToUserDa.Insert(perToUser);
                }                
            }
            else
            {
                response.Response.AddBusinessException("چنین دسترسی وجود ندارد", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Framework.Common.Service.Message.ResponseDto RevokeRolePermission(Common.DTO.RoleDto role, int permissionId)
        {
            ResponseDto response = new ResponseDto();
            var permission = this.GetSingle(it => it.PermissionId == permissionId);
            if (permission != null)
            {
                PermissionToRoleTDataAccess perToUserDa = new PermissionToRoleTDataAccess();
                var permissionList = perToUserDa.GetAll(it => it.PermissionId == permissionId && it.RoleId == role.RoleId).ToList();
                if(permissionList!=null && permissionList.Count>0)
                    perToUserDa.Delete(permissionList);
            }
            else
            {
                response.Response.AddBusinessException("چنین دسترسی وجود ندارد", BusinessExceptionEnum.Operational);
            }
            return response;
        }

        public Common.DTOContainer.PermissionDtoContainer RolePermissions(Common.DTO.RoleDto role)
        {
            var permissionList = ((PermissionTDataAccess)this.dataAccess).GetRolePermissions(role.RoleId);
            PermissionDtoContainer container = new PermissionDtoContainer();
            if (permissionList != null && permissionList.Count > 0)
                container.PermissionDtoList.AddRange(permissionList);
            return container;
        }

        public Common.DTOContainer.PermissionDtoContainer UserPermissions(Common.DTO.UserDto user)
        {
            var permissionList = ((PermissionTDataAccess)this.dataAccess).GetUserPermissions(user.UserId);
            PermissionDtoContainer container = new PermissionDtoContainer();
            if (permissionList != null && permissionList.Count > 0)
                container.PermissionDtoList.AddRange(permissionList);
            return container;
        }
        public override void Insert(PermissionDto entityDto)
        {
            ResourceToOperationTDataAccess rtoDa = new ResourceToOperationTDataAccess();
            var relation =  rtoDa.GetSingle(it => it.ResourceId == entityDto.ResourceId && it.OperationId == entityDto.OperationId);
            if (relation == null)
            {
                base.Insert(entityDto);
            }
            else {
                entityDto.Response.AddBusinessException("ارتباطی بین منبع و عملیات برای تعریف دسارسی موجود نیست!", BusinessExceptionEnum.Validation); 
            }
            
        }
        public override void Insert(System.Collections.Generic.List<ISE.SM.Common.DTO.PermissionDto> entityDtoList)
        {
            System.Collections.Generic.List<ISE.SM.Common.DTO.PermissionDto> allowList = new List<PermissionDto>();
            ResourceToOperationTDataAccess rtoDa = new ResourceToOperationTDataAccess();
            foreach (var entityDto in entityDtoList)
            {
                var relation = rtoDa.GetSingle(it => it.ResourceId == entityDto.ResourceId && it.OperationId == entityDto.OperationId);
                if (relation == null)
                {
                    allowList.Add(entityDto);
                }
                else
                {
                    entityDto.Response.AddBusinessException("ارتباطی بین منبع و عملیات برای تعریف دسترسی موجود نیست!", BusinessExceptionEnum.Validation);
                }
            }
            if (allowList.Count>0)
                base.Insert(allowList);
        }
        public PermissionDtoContainer GetAllUserPermissions(long userId)
        {
            return ((PermissionTDataAccess)this.dataAccess).GetAllUserPermissions(userId);
        }

        public PermissionDtoContainer GetCurrentUserPermissions(long userId)
        {
            return  ((PermissionTDataAccess)this.dataAccess).GetCurrentUserPermissions(userId);
        }
        public PermissionDtoContainer GetGroupPermissions(int groupId)
        {
            return ((PermissionTDataAccess)this.dataAccess).GetGroupPermissionContainer(groupId);
        }
        public PermissionDtoContainer GetRolePermissions(int roleId)
        {
            return ((PermissionTDataAccess)this.dataAccess).GetRolePermissionContainer(roleId);
        }
        public ResponseDtoContainer ChangeUserPermissons(List<PermissionDto> permissions, long userId)
        {
            ResponseDtoContainer container = new ResponseDtoContainer();
            List<PermissionToUserDto> updateList = new List<PermissionToUserDto>();
            PermissionToUserTDataAccess puDa = new PermissionToUserTDataAccess();
            foreach (var item in permissions)
            {
               
                var pu = puDa.GetSingle(it => it.PermissionId == item.PermissionId && it.UserId == userId);
                if (pu != null)
                {
                    if (item.AccessType == Common.Enums.AccessType.None)
                    {
                        puDa.Delete(pu);
                    }
                    else
                    {
                        pu.PermissionAccess = (short)item.AccessType;
                        updateList.Add(pu);
                        
                        
                    }
                    ResponseDto response = new ResponseDto(pu.Response);
                    container.ResponseDtoList.Add(response);
                }
                else if (pu == null && (item.AccessType == Common.Enums.AccessType.Access || item.AccessType == Common.Enums.AccessType.Deny))
                {
                    PermissionToUserDto newPermission = new PermissionToUserDto()
                    {
                        PermissionId = item.PermissionId,
                        UserId= userId,
                        PermissionAccess = (short)item.AccessType                        
                    };
                    puDa.Insert(newPermission);
                    ResponseDto response = new ResponseDto(newPermission.Response);
                    container.ResponseDtoList.Add(response);
                }
                else
                {
                    item.Response.AddBusinessException("موجود نیست", BusinessExceptionEnum.Operational);
                }
            }
            puDa.Update(updateList);
            return container;
        }
        public ResponseDtoContainer ChangeRolePermissons(List<PermissionDto> permissions, int roleId)
        {
            ResponseDtoContainer container = new ResponseDtoContainer();
            List<PermissionToRoleDto> updateList = new List<PermissionToRoleDto>();
            PermissionToRoleTDataAccess puDa = new PermissionToRoleTDataAccess();
            foreach (var item in permissions)
            {

                var pu = puDa.GetSingle(it => it.PermissionId == item.PermissionId && it.RoleId == roleId);
                if (pu != null)
                {
                    if (item.AccessType == Common.Enums.AccessType.None)
                    {
                        puDa.Delete(pu);
                    }
                    else
                    {
                        pu.PermisssionAccess = (short)item.AccessType;
                        updateList.Add(pu);
                       

                    }
                    ResponseDto response = new ResponseDto(pu.Response);
                    container.ResponseDtoList.Add(response);
                }
                else if (pu == null && (item.AccessType == Common.Enums.AccessType.Access || item.AccessType == Common.Enums.AccessType.Deny))
                {
                    PermissionToRoleDto newPermission = new PermissionToRoleDto()
                    {
                        PermissionId = item.PermissionId,
                        RoleId = roleId,
                        PermisssionAccess = (short)item.AccessType
                    };
                    puDa.Insert(newPermission);
                    ResponseDto response = new ResponseDto(newPermission.Response);
                    container.ResponseDtoList.Add(response);
                }
                else
                {
                    item.Response.AddBusinessException("موجود نیست", BusinessExceptionEnum.Operational);
                }
            }
            puDa.Update(updateList);
            return container;
        }
        public PermissionDtoContainer GetCurrentRolePermissions(int roleId)
        {
            return ((PermissionTDataAccess)this.dataAccess).GetCurrentRolePermissions(roleId);
        }
        public PermissionDtoContainer GetAllRolePermissions(int roleId)
        {
            return ((PermissionTDataAccess)this.dataAccess).GetAllRolePermissions(roleId);
        }
   }
}
