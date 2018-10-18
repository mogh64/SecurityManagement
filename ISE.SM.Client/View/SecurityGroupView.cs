using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Client.View
{
    public class SecurityGroupView
    {
        SecurityGroupPresenter presenter = new SecurityGroupPresenter();
        public SecurityGroupView() {
            SecurityGroupBindingList = new BindingList<SecurityGroupDto>();
        }
        List<SecurityResourceDto> ResourceList = new List<SecurityResourceDto>();
        List<PermissionDto> PermissionDtolist = new List<PermissionDto>();
        public BindingList<SecurityGroupDto> SecurityGroupBindingList { get; set; }
        public BindingList<UserDto> SecurityUserBindingList { get; set; }
        public BindingList<RoleDto> RoleBindingList { get; set; }
        public List<SecurityResourceDto> LoadResources(int groupId, bool reload = false)
        {

            
                PermissionDtolist.Clear();
                PermissionPresenter ppresenter = new PermissionPresenter();
                var container = ppresenter.GetGroupPermissios(groupId);
                ResourceList = container.SecurityResourceDtoList;
                PermissionDtolist = container.PermissionDtoList;
            
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
        public BindingList<SecurityGroupDto> LoadGroups()
        {
            var container = presenter.GetAll();
            SecurityGroupBindingList = new BindingList<SecurityGroupDto>(container.SecurityGroupDtoList);
            SecurityGroupBindingList.AllowNew = true;
            SecurityGroupBindingList.AllowEdit = true;
            SecurityGroupBindingList.AllowRemove = true;
            SecurityGroupBindingList.RaiseListChangedEvents = true;
            return SecurityGroupBindingList;
        }
        public BindingList<UserDto> LoadUsers(SecurityGroupDto group)
        {
            var container = presenter.GetGroupUsers(group);
            SecurityUserBindingList = new BindingList<UserDto>(container);
            SecurityUserBindingList.AllowNew = true;
            SecurityUserBindingList.AllowEdit = true;
            SecurityUserBindingList.AllowRemove = true;
            SecurityUserBindingList.RaiseListChangedEvents = true;
            return SecurityUserBindingList;
        }
        public BindingList<RoleDto> LoadRoles(SecurityGroupDto grp)
        {
            var container = presenter.GetGroupRole(grp);
            RoleBindingList = new BindingList<RoleDto>(container);
            RoleBindingList.AllowNew = true;
            RoleBindingList.AllowEdit = true;
            RoleBindingList.AllowRemove = true;
            RoleBindingList.RaiseListChangedEvents = true;
            return RoleBindingList;
        }
        public bool Insert(SecurityGroupDto group)
        {
            if (presenter.Insert(group) != null)
            {
                SecurityGroupBindingList.Add(group);
                return true;
            }
            return false;
        }
        public void Update(SecurityGroupDto group)
        {
            if (presenter.Update(group))
            {
               
                SecurityGroupBindingList.ResetBindings();
            }
        }
        public void Remove(SecurityGroupDto group)
        {
            if (presenter.Remove(group))
            {
                SecurityGroupBindingList.Remove(group);          
            }
        }
        public void AssignUser(SecurityGroupDto group, UserDto user)
        {

            if (presenter.AssignUsers(new List<UserDto>() { user }, group.SecurityGroupId))
            {
                SecurityUserBindingList.Add(user);
            }
        }
        public void DeAssignUser(SecurityGroupDto group, UserDto user)
        {

            if (presenter.DeAssignUsers(new List<UserDto>() { user }, group.SecurityGroupId))
            {
                SecurityUserBindingList.Remove(user);
            }
        }
        public void AssignRole(SecurityGroupDto group, RoleDto role)
        {
           
            if (presenter.AssignRoles(new List<RoleDto>() { role }, group.SecurityGroupId))
            {
                RoleBindingList.Add(role);
            }
        }
        public void DeAssignRole(SecurityGroupDto group, RoleDto role)
        {
            SecurityGroupPresenter groupPresenter = new SecurityGroupPresenter();
            if (groupPresenter.DeAssignRoles(new List<RoleDto>() { role }, group.SecurityGroupId))
            {
                RoleBindingList.Remove(role);
            }
        }
    }
}
