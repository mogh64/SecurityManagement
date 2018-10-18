using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ISE.SM.Client.View
{
    public class RoleView
    {
         RolePresenter presenter = new RolePresenter();
         public RoleView()
         {
            SecurityRoleBindingList = new BindingList<RoleDto>();
         }
         List<SecurityResourceDto> ResourceList = new List<SecurityResourceDto>();
         List<PermissionDto> PermissionDtolist = new List<PermissionDto>();
         public BindingList<RoleDto> SecurityRoleBindingList { get; set; }
         public BindingList<UserDto> SecurityUserBindingList { get; set; }
         public BindingList<SecurityGroupDto> SecurityGroupBindingList { get; set; }
         public List<SecurityResourceDto> LoadResources(int roleId,int all=1, bool reload = false)
         {


             if (all > 0)
             {
                 //var list = presenter.GetAll();
                 //ResourceList = list.SecurityResourceDtoList;
                 PermissionDtolist.Clear();
                 PermissionPresenter ppresenter = new PermissionPresenter();
                 var container = ppresenter.GetAllRolePermissios(roleId);
                 ResourceList = container.SecurityResourceDtoList;
                 PermissionDtolist = container.PermissionDtoList;
             }
             else
             {
                 PermissionPresenter ppresenter = new PermissionPresenter();
                 var container = ppresenter.GetAllCurrentRolePermissios(roleId);
                 ResourceList = container.SecurityResourceDtoList;
                 PermissionDtolist = container.PermissionDtoList;

             }

             return ResourceList;
         }
         public List<SecurityResourceDto> LoadCatchResources()
         {
             return ResourceList;
         }
         public List<PermissionDto> LoadPermissions()
         {

             if (PermissionDtolist.Count > 0)
             {
                 return PermissionDtolist;
             }
             PermissionPresenter permissionPresenter = new PermissionPresenter();
             var list = permissionPresenter.GetAll().PermissionDtoList;
             if (list != null)
             {
                 PermissionDtolist.AddRange(list);
             }
             return PermissionDtolist;
         }
         public BindingList<RoleDto> LoadRoles()
        {
            var container = presenter.GetAll();
            SecurityRoleBindingList = new BindingList<RoleDto>(container.RoleDtoList);
            SecurityRoleBindingList.AllowNew = true;
            SecurityRoleBindingList.AllowEdit = true;
            SecurityRoleBindingList.AllowRemove = true;
            SecurityRoleBindingList.RaiseListChangedEvents = true;
            return SecurityRoleBindingList;
        }
         public BindingList<UserDto> LoadUsers(RoleDto role)
         {
             var userList = presenter.GetRoleUsers(role);
             SecurityUserBindingList = new BindingList<UserDto>(userList);
             SecurityUserBindingList.AllowNew = true;
             SecurityUserBindingList.AllowEdit = true;
             SecurityUserBindingList.AllowRemove = true;
             SecurityUserBindingList.RaiseListChangedEvents = true;
             return SecurityUserBindingList;
         }
         public BindingList<SecurityGroupDto> LoadGroups(RoleDto role)
         {
             var userList = presenter.GetRoleGroups(role);
             SecurityGroupBindingList = new BindingList<SecurityGroupDto>(userList);
             SecurityGroupBindingList.AllowNew = true;
             SecurityGroupBindingList.AllowEdit = true;
             SecurityGroupBindingList.AllowRemove = true;
             SecurityGroupBindingList.RaiseListChangedEvents = true;
             return SecurityGroupBindingList;
         }
         public bool Insert(RoleDto role)
        {
            if (presenter.Insert(role) != null)
            {
                SecurityRoleBindingList.Add(role);
                return true;
            }
            return false;
        }
         public void Update(RoleDto role)
        {
            if (presenter.Update(role))
            {
               
                SecurityRoleBindingList.ResetBindings();
            }
        }
         public void Remove(RoleDto role)
        {
            if (presenter.Remove(role))
            {
                SecurityRoleBindingList.Remove(role);          
            }
        }
         public void AssignUser(RoleDto role, UserDto user)
         {
             SecurityUserPresenter userPresenter = new SecurityUserPresenter();
             if (userPresenter.AssignUserToRole(user, role.RoleId))
             {
                 SecurityUserBindingList.Add(user);
             }
         }
         public void DeAssignUser(RoleDto role, UserDto user)
         {
             SecurityUserPresenter userPresenter = new SecurityUserPresenter();
             if (userPresenter.DeAssignUserToRole(user, role.RoleId))
             {
                 SecurityUserBindingList.Remove(user);
             }
         }
         public void AssignToGroup(RoleDto role, SecurityGroupDto group)
         {
             SecurityGroupPresenter groupPresenter = new SecurityGroupPresenter();
             if (groupPresenter.AssignRoles(new List<RoleDto>() { role}, group.SecurityGroupId))
             {
                 SecurityGroupBindingList.Add(group);
             }
         }
         public void DeAssignFromGroup(RoleDto role, SecurityGroupDto group)
         {
             SecurityGroupPresenter groupPresenter = new SecurityGroupPresenter();
             if (groupPresenter.DeAssignRoles(new List<RoleDto>() { role }, group.SecurityGroupId))
             {
                 SecurityGroupBindingList.Remove(group);
             }
         }
         public bool UpdateRolePermissions(List<PermissionDto> permissions, int roleId)
         {
             PermissionPresenter ppresenter = new PermissionPresenter();
             return ppresenter.UpdateRolePermissions(permissions, roleId);
         }
    }
}
