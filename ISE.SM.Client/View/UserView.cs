using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using ISE.SM.Common.DTOContainer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE.SM.Client.View
{
    public class UserView
    {
        SecurityUserPresenter userPresenter = new SecurityUserPresenter();
        public UserView()
        {

        }
        UserDtoContainer container = new UserDtoContainer();
        public BindingList<UserDto> SecurityUserBindingList { get; set; }
        public BindingList<RoleDto> RoleBindingList { get; set; }
        public BindingList<SecurityGroupDto> GroupBindingList { get; set; }
        public BindingList<AccountDto> AccountBindingList { get; set; }
        public List<CompanyDto> SecurityCompanyBindingList { get; set; }
        public BindingList<UserDto> LoadUsers()
        {
            container = userPresenter.GetAll();
            SecurityUserBindingList = new BindingList<UserDto>(container.UserDtoList);
            SecurityUserBindingList.AllowNew = true;
            SecurityUserBindingList.AllowEdit = true;
            SecurityUserBindingList.AllowRemove = true;
            SecurityUserBindingList.RaiseListChangedEvents = true;
            
            return SecurityUserBindingList;
        }
        public List<CompanyDto> LoadCompanies()
        {
            SecurityCompanyPresenter spresenter = new SecurityCompanyPresenter();
            if (SecurityCompanyBindingList == null)
            {
                var container = spresenter.GetAll();
                SecurityCompanyBindingList = new List<CompanyDto>(container.CompanyDtoList);
            }

            return SecurityCompanyBindingList;
        }
        public BindingList<RoleDto> BindRoles(List<int> roleIdss) 
        {
            var roles = container.RoleDtoList.Where(it => roleIdss.Exists(e => e == it.RoleId)).ToList();
            RoleBindingList = new BindingList<RoleDto>(roles);
            RoleBindingList.AllowNew = true;
            RoleBindingList.AllowEdit = true;
            RoleBindingList.AllowRemove = true;
            RoleBindingList.RaiseListChangedEvents = true;
            return RoleBindingList;
        }
        public BindingList<SecurityGroupDto> BindGroups(List<int> groupIds)
        {
            var groups = container.GroupDtoList.Where(it => groupIds.Exists(e => e == it.SecurityGroupId)).ToList();
            GroupBindingList = new BindingList<SecurityGroupDto>(groups);
            GroupBindingList.AllowNew = true;
            GroupBindingList.AllowEdit = true;
            GroupBindingList.AllowRemove = true;
            GroupBindingList.RaiseListChangedEvents = true;
            return GroupBindingList;
        }
        public BindingList<AccountDto> LoadUserAccounts(UserDto user)
        {
            var accounts = userPresenter.GetUserAccounts(user);
            AccountBindingList = new BindingList<AccountDto>(accounts);
            AccountBindingList.AllowNew = true;
            AccountBindingList.AllowEdit = true;
            AccountBindingList.AllowRemove = true;
            AccountBindingList.RaiseListChangedEvents = true;
            return AccountBindingList;
        }
        public void AssignToRoles(UserDto user, RoleDto role)
        {
            if (user != null && role != null)
            {
                if (userPresenter.AssignUserToRole(user, role.RoleId))
                {
                    RoleBindingList.Add(role);

                }
            }

        }
        public void DeAssignToRoles(UserDto user, RoleDto role)
        {
            if (user != null && role != null) {
               if( userPresenter.DeAssignUserToRole(user, role.RoleId))
               {
                   RoleBindingList.Remove(role);
                   
               }
            }
            
        }
        public void AssignToGroups(UserDto user, SecurityGroupDto group)
        {
            SecurityGroupPresenter gPresenter = new SecurityGroupPresenter();
            if (user != null && group != null)
            {
                List<UserDto>users=new List<UserDto>(){user};
                if (gPresenter.AssignUsers(users,group.SecurityGroupId))
                {
                    GroupBindingList.Add(group);

                }
            }

        }
        public void DeAssignToGroups(UserDto user, SecurityGroupDto group)
        {
            SecurityGroupPresenter gPresenter = new SecurityGroupPresenter();
            if (user != null && group != null)
            {
                List<UserDto> users = new List<UserDto>() { user };
                if (gPresenter.DeAssignUsers(users, group.SecurityGroupId))
                {
                    GroupBindingList.Remove(group);

                }
            }

        }
        public bool AddAccount(AccountDto acc,UserDto user)
        {
            AccountPresenter accPresenter = new AccountPresenter();
            if (accPresenter.CreateAccount(acc, user) != null)
            {
                AccountBindingList.Add(acc);
                return true;
            }
            return false;
        }
        public bool DeleteAccount(AccountDto acc)
        {
            AccountPresenter accPresenter = new AccountPresenter();
            if (accPresenter.DeleteAccount(acc) != null)
            {
                AccountBindingList.Remove(acc);
                return true;
            }
            return false;
        }
        public bool UpdateAccount(AccountDto acc)
        {
            AccountPresenter accPresenter = new AccountPresenter();
            if (accPresenter.UpdateAccount(acc) != null)
            {
                AccountBindingList.ResetBindings();
                
                acc.ApplicationDomainDtoList.RemoveAll(it => it.State == Framework.Common.CommonBase.DtoObjectState.Deleted);
                return true;
            }
            return false;
        }
        public bool AddUser(UserDto user)
        {

            if (userPresenter.Insert(user) != null)
            {
                SecurityUserBindingList.Add(user);
                return true;
            }
            return false;
        }
        public bool DeleteUser(UserDto user)
        {

            if (userPresenter.Remove(user) != null)
            {
                SecurityUserBindingList.Remove(user);
                return true;
            }
            return false;
        }
        public bool UpdateUser(UserDto user)
        {

            if (userPresenter.Update(user) != null)
            {
                SecurityUserBindingList.ResetBindings();
                return true;
            }
            return false;
        }
        public bool ChangePassword(string prevPass, string newPass, string userName,AccountDto currentAccount)
        {
            AccountPresenter accPresenter = new AccountPresenter();
            var result =accPresenter.ChangePassword(userName, newPass, prevPass);
            if (result != null)
            {
                 currentAccount.PassChangeDate = result.PassChangeDate;
                 AccountBindingList.ResetBindings();
                 return true;
            }
            return false;
        }
        public bool UpdateUserPermissions(List<PermissionDto> permissions, long userId)
        {
            PermissionPresenter ppresenter = new PermissionPresenter();
            return  ppresenter.UpdateUserPermissions(permissions, userId);
        }
    }
}
