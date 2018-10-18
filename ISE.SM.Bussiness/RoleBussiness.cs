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
   
    public class RoleBussiness : BussinessBase<Role, RoleDto>
    {
        public RoleBussiness()
        {
            this.dataAccess = new RoleTDataAccess();
        }
        public override IList<RoleDto> GetAll()
        {
            AppDomainTDataAccess appDomainrep = new AppDomainTDataAccess();
            var result = base.GetAll();
            foreach (var item in result)
            {
                 var app = appDomainrep.GetSingle(it => it.ApplicationDomainId == item.AppDomainId);
                 if (app != null)
                 {
                     item.ApplicationDomainDto = app;
                 }
            }
            return result;
        }
         public Framework.Common.Service.Message.ResponseDto ActivateRole(Common.DTO.RoleDto role)
         {
             ResponseDto response = new ResponseDto();             
             var dbRole = this.GetSingle(it=>it.RoleId==role.RoleId);
             if (dbRole != null)
             {
                 dbRole.Enabled = 1;
                 this.Update(dbRole);
             }
             else {
                 response.Response.AddBusinessException("این نقش موجود نیست!", BusinessExceptionEnum.Operational);
             }
             return response;
         }

         public Framework.Common.Service.Message.ResponseDto DeActivateRole(Common.DTO.RoleDto role)
         {
             ResponseDto response = new ResponseDto();
             var dbRole = this.GetSingle(it => it.RoleId == role.RoleId);
             if (dbRole != null)
             {
                 dbRole.Enabled = 0;
                 this.Update(dbRole);
             }
             else
             {
                 response.Response.AddBusinessException("این نقش موجود نیست!", BusinessExceptionEnum.Operational);
             }
             return response;
         }
        
         public Common.DTOContainer.UserDtoContainer AssignedUsers(Common.DTO.RoleDto role)
         {
             var result = ((RoleTDataAccess)this.dataAccess).AssignedUsers(role);
             return result;
         }

         public Framework.Common.Service.Message.ResponseDto AddInheritance(int parentRoleId, int childRoleId)
         {
             ResponseDto response = new ResponseDto();
             RoleToRoleConstraintTDataAccess roleToRoleCo = new RoleToRoleConstraintTDataAccess();
             var constraint = roleToRoleCo.GetSingle(it => it.SourceRoleId == parentRoleId && it.DestRoleId == childRoleId);
             if (constraint == null && constraint.Enable > 0)
             {
                 var dbParentRole = this.GetSingle(it => it.RoleId == parentRoleId);
                 var dbChildRole = this.GetSingle(it => it.RoleId == childRoleId);
                 if (dbParentRole == null)
                 {
                     response.Response.AddBusinessException("نقش پدر موجود نیست!", BusinessExceptionEnum.Operational);
                     return response;
                 }
                 if (dbChildRole == null)
                 {
                     response.Response.AddBusinessException("نقش فرزند موجود نیست!", BusinessExceptionEnum.Operational);
                     return response;
                 }
                 dbChildRole.ParentRoleId = dbParentRole.RoleId;
                 Update(dbChildRole);
             }
             else
             {
                 response.Response.AddBusinessException("بدلیل تعریف محدودیت رابطه غیر قابل ایجاد است!", BusinessExceptionEnum.Validation);
             }
             return response;
         }

         public Framework.Common.Service.Message.ResponseDto DeleteInheritance(int parentRoleId, int childRoleId)
         {
             ResponseDto response = new ResponseDto();
             var dbParentRole = this.GetSingle(it => it.RoleId == parentRoleId);
             var dbChildRole = this.GetSingle(it => it.RoleId == childRoleId);
             if (dbParentRole == null)
             {
                 response.Response.AddBusinessException("نقش پدر موجود نیست!", BusinessExceptionEnum.Operational);
                 return response;
             }
             if (dbChildRole == null)
             {
                 response.Response.AddBusinessException("نقش فرزند موجود نیست!", BusinessExceptionEnum.Operational);
                 return response;
             }
             dbChildRole.ParentRoleId = null;
             Update(dbChildRole);
             return response;
         }

         public Framework.Common.Service.Message.ResponseDto AddAscendant(Common.DTO.RoleDto parentRoleId, int childRoleId)
         {
             ResponseDto response = new ResponseDto();
             RoleToRoleConstraintTDataAccess roleToRoleCo = new RoleToRoleConstraintTDataAccess();
             var constraint = roleToRoleCo.GetSingle(it => it.SourceRoleId == childRoleId && it.DestRoleId == parentRoleId.RoleId);
             if (constraint == null && constraint.Enable > 0)
             {
                 var dbChildRole = this.GetSingle(it => it.RoleId == childRoleId);

                 if (dbChildRole == null)
                 {
                     response.Response.AddBusinessException("نقش فرزند موجود نیست!", BusinessExceptionEnum.Operational);
                     return response;
                 }
                 Insert(parentRoleId);
                 dbChildRole.ParentRoleId = parentRoleId.RoleId;
                 Update(dbChildRole);
             }
             else
             {
                 response.Response.AddBusinessException("بدلیل تعریف محدودیت رابطه غیر قابل ایجاد است!", BusinessExceptionEnum.Validation);
             }
             return response;
         }
         public Framework.Common.Service.Message.ResponseDto AddDescendant(RoleDto child, int parentRoleId)
         {
             ResponseDto response = new ResponseDto();
             RoleToRoleConstraintTDataAccess roleToRoleCo = new RoleToRoleConstraintTDataAccess();
             var constraint = roleToRoleCo.GetSingle(it => it.SourceRoleId == child.RoleId && it.DestRoleId == parentRoleId);
             if (constraint == null && constraint.Enable > 0)
             {
                 var dbParentRole = this.GetSingle(it => it.RoleId == parentRoleId);

                 if (dbParentRole == null)
                 {
                     response.Response.AddBusinessException("نقش پدر موجود نیست!", BusinessExceptionEnum.Operational);
                     return response;
                 }
                 child.ParentRoleId = parentRoleId;
                 Insert(child);
             }
             else
             {
                 response.Response.AddBusinessException("بدلیل تعریف محدودیت رابطه غیر قابل ایجاد است!", BusinessExceptionEnum.Validation);
             }
            
             return response;
         }


         public RoleToRoleConstraintDto AddRoleToRoleConstraint(Common.DTO.RoleToRoleConstraintDto constraint)
         {
            
             RoleToRoleConstraintTDataAccess roleToRoleConstraintDa = new RoleToRoleConstraintTDataAccess();
             roleToRoleConstraintDa.Insert(constraint);

             return constraint;
         }

         public UserToRoleConstraintDto AddUserToRoleConstraint(Common.DTO.UserToRoleConstraintDto constraint)
         {
             
             UserToRoleConstraintTDataAccess roleToRoleConstraintDa = new UserToRoleConstraintTDataAccess();
             roleToRoleConstraintDa.Insert(constraint);

             return constraint;
         }

        
         public SecurityGroupDtoContainer RoleGroups(RoleDto role)
         {
             SecurityGroupDtoContainer container = new SecurityGroupDtoContainer();
             RoleToGroupTDataAccess roleToGroupDa = new RoleToGroupTDataAccess();
             var groupList = roleToGroupDa.GetRoleGroups(role);
             container.SecurityGroupDtoList.AddRange(groupList);
             return container;
         }
    }
}
