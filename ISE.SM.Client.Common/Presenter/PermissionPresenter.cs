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

namespace ISE.SM.Client.Common.Presenter
{
    public class PermissionPresenter
    {
         private ServiceAdapter<IPermissionService> PermissionServiceAdapter;
       public PermissionPresenter()
       {
           IseBussinessExceptionManager exceptionManager = new IseBussinessExceptionManager();
           PermissionServiceAdapter = new ServiceAdapter<IPermissionService>(exceptionManager);
       }
       public PermissionDtoContainer GetAll()
       {
           var result = (PermissionDtoContainer)PermissionServiceAdapter.Execute(s => s.GetAll());
           return result;
       }
       public PermissionDto Insert(PermissionDto Permission)
       {

           PermissionDto result = (PermissionDto)PermissionServiceAdapter.Execute(s => s.Insert(Permission));
           if (result.Response.HasException)
           {
               return null;
           }
           Permission.PermissionId = result.PermissionId;
           return Permission;
       }
       public bool Update(PermissionDto Permission)
       {

           ResponseDto response = PermissionServiceAdapter.Execute(s => s.Update(Permission));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
       public bool Remove(PermissionDto Permission)
       {

           ResponseDto response = PermissionServiceAdapter.Execute(s => s.Delete(Permission));
           if (response.Response.HasException)
           {
               return false;
           }
           return true;
       }
       public PermissionDtoContainer GetAllCurrentUserPermissios(long userId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetCurrentUserPermissions(userId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;           
       }
       public PermissionDtoContainer GetAllCurrentRolePermissios(int roleId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetCurrentRolePermissions(roleId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;
       }
       public PermissionDtoContainer GetGroupPermissios(int groupId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetGroupPermissions(groupId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;
       }
       public PermissionDtoContainer GetRolePermissios(int roleId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetGroupPermissions(roleId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;
       }
       public PermissionDtoContainer GetAllUserPermissios(long userId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetAllUserPermissions(userId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;
       }
       public PermissionDtoContainer GetAllRolePermissios(int roleId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.GetAllRolePermissions(roleId));
           if (container.Response.HasException)
           {
               return null;
           }
           return container;
       }
       public bool UpdateUserPermissions(List<PermissionDto> userPermissions, long userId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.ChangeUserPermissons(userPermissions, userId));
           if (container.Response.HasException)
           {
               foreach (var item in container.ResponseDtoList)
               {
                   if (item.Response.HasException)
                   {
                       var p = userPermissions.Find(it => it.PermissionId == (int)item.Id);
                       p.SetResponse(item.Response);
                   }
               }
               return false;
           }
           return true;
       }
       public bool UpdateRolePermissions(List<PermissionDto> userPermissions, int roleId)
       {
           var container = PermissionServiceAdapter.Execute(s => s.ChangeRolePermissons(userPermissions, roleId));
           if (container.Response.HasException)
           {
               foreach (var item in container.ResponseDtoList)
               {
                   if (item.Response.HasException)
                   {
                       var p = userPermissions.Find(it => it.PermissionId == (int)item.Id);
                       p.SetResponse(item.Response);
                   }
               }
               return false;
           }
           return true;
       }
    }
}
