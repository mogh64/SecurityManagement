using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.SM.Client.Common.Presenter;
using ISE.SM.Client.View;
using ISE.SM.Common.DTO;
using ISE.UILibrary.Lov;
using ISE.Framework.Utility.Utils;
using ISE.SM.Client.UCEntry;
using ISE.Framework.Common.Service.Security;
using Telerik.WinControls.UI;

namespace ISE.SM.Client.UC
{
    public partial class UCUsers : IUserControl
    {
        ResourceView resview = new ResourceView();
        UserView view = new UserView();
        BindingSource userBS = new BindingSource();
        BindingSource roleBS = new BindingSource();
        BindingSource groupBS = new BindingSource();
        BindingSource accBS = new BindingSource();
        List<RadTreeNode> changeList = new List<RadTreeNode>();
        public UCUsers()
        {
            InitializeComponent();
            //time consum
            LoadUsers();

            InitializeContexMenue();
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.gridUsers);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXGrp);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXRole);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXAcc);
         
            
        }

        private void InitializeContexMenue()
        {
            this.radMenuItemCancelDeny.Click += RadMenuItemClicked;
            this.radMenuItemDeny.Click += RadMenuItemClicked;
        }
        private void RadMenuItemClicked(object sender, EventArgs e)
        {
            var name = ((Telerik.WinControls.RadItem)(sender)).AccessibleDescription;
            var node = this.radTreeViewResource.SelectedNode;
           
            if (name == "deny")
            {
                if (node.Tag != SM.Common.Enums.AccessType.Deny.ToString())
                {
                    if (node.Checked)
                        node.Checked = false;
                    node.Tag = SM.Common.Enums.AccessType.Deny.ToString();
                    SetColor(node, SM.Common.Enums.AccessType.Deny);
                   
                }
                
            }
            if (name == "cencelDeny")
            {
                if (node.Tag == SM.Common.Enums.AccessType.Deny.ToString())
                {
                    node.Tag = SM.Common.Enums.AccessType.None.ToString();
                    SetColor(node, SM.Common.Enums.AccessType.None);
                }
                
            }
            if (!changeList.Contains(node))
                changeList.Add(node);
        }
        private void CreateCurrentTree()
        {
           
           if(CurrentUserId>0)
              CreateAllTree(0);
          
            
        }
        private long CurrentUserId
        {
            get
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                if (user != null)
                {
                    return user.UserId;
                }
                return 0;
            }
        }
        private void SetColor(RadTreeNode node,SM.Common.Enums.AccessType type)
        {
            if (type==SM.Common.Enums.AccessType.Deny)
                node.ForeColor = Color.Tomato;
            else
                node.ForeColor = Color.Black;
        }
        private void CreateAllTree(int all=1 )
        {
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            var appDomains = resview.LoadApplicationDomains(CurrentUserId);
            // var resourceTypes = view.LoadResourceTypeList();
            if (appDomains != null)
            {
                var resources = resview.LoadResources(CurrentUserId, all);
                List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
                if (resources != null)
                {
                    submenus = resources.Where(it => it.ResourceTypeId == 1 || it.ResourceTypeId == 0).ToList();
                }
                foreach (var appDomain in appDomains.OrderBy(it => it.Title).ToList())
                {
                    var appNode = CreateApplicationNode(appDomain);
                    appNode.Value = appDomain;
                   
                    var submenuList = submenus.Where(it => it.AppDomainId == appDomain.ApplicationDomainId && it.ParentId == null).ToList();
                    if (submenuList != null)
                    {
                        foreach (var submenu in submenuList)
                        {

                            var submenuNode = CreateSubmenuTree(submenu, resources);
                          
                            if (submenuNode != null)
                            {
                                if (submenu.Checked)
                                {
                                    submenuNode.Checked = true;
                                    appNode.Checked = true;
                                }
                                    
                                submenuNode.Value = submenu;
                                AddContextMenu(submenuNode);
                                appNode.Nodes.Add(submenuNode);
                            }

                        }
                    }
                    nodeList.Add(appNode);
                }
            }
            
            this.radTreeViewResource.Nodes.AddRange(nodeList);
        }
        RadTreeNode CreateApplicationNode(ApplicationDomainDto appDomain)
        {
            var image = ISE.SM.Client.Properties.Resources.application2;
            RadTreeNode node = new RadTreeNode(appDomain.Title);
            node.Image = image;
            return node;
        }
        RadTreeNode CreateSubmenuTree(SecurityResourceDto resource,List<SecurityResourceDto>resources)
        {
            RadTreeNode node = new RadTreeNode(resource.DisplayName);
            if (resource.Checked)
                node.Checked = true;
            var image = GetImage(resource.ResourceTypeId);
            if (image != null)
            {
                node.Image = image;
            }
            
            var subNodes = resources.Where(it => it.ParentId == resource.SecurityResourceId).ToList();
            if (subNodes == null || subNodes.Count == 0)
                return node;
            foreach (var item in subNodes)
            {
                var subNode = CreateSubmenuTree(item,resources);
              
                var subimage = GetImage(item.ResourceTypeId);

                var permissions = resview.LoadPermissions();
                var permissionItems = permissions.Where(it => it.ResourceId == item.SecurityResourceId).ToList();
                if (permissionItems.Count() > 0)
                {
                    foreach (var pitem in permissionItems)
                    {
                        CreateOperationNode(pitem,subNode);
                    }
                }
                if (subNode != null)
                {
                    subNode.Value = item;
                    if (subimage != null)
                    {
                        subNode.Image = subimage;
                    }
                    AddContextMenu(subNode);
                    node.Nodes.Add(subNode);
                }

            }
            return node;
        }
        private string CeateOperationName(PermissionDto permission)
        {
            string user = "_";
            string role = "_";
            string group = "_";
            if (permission.RoleDtos.Count > 0)
            {
                role = "R";
            }
            if (permission.GroupDtos.Count > 0)
            {
                group = "G";
            }
            if (permission.IsToUser)
            {
                user = "U";
            }
            string name = string.Format("{0}:{1}{2}{3}", permission.OperationDto.DisplayName,user,role,group);
            return name;
        }
        private void CreateOperationNode(PermissionDto permission, RadTreeNode node)
        {
            string oName = CeateOperationName(permission);

            if (permission.RoleDtos.Count>0)
            {

            }

            RadTreeNode cnode = new RadTreeNode(oName);
            var image = GetOperationImage();
            //var img = ISE.SM.Client.Properties.Resources.application2;
            //var resImg = ISE.SM.Utility.ImageCombiner.CombineBitmap(new List<Image>() { image,img});
            if (image != null)
            {
                cnode.Image = image;
            }
            if (permission.OperationDto.Checked)
                cnode.Checked = true;
            
            cnode.Value = permission;
            cnode.Tag = permission.AccessType.ToString();
            if (permission.AccessType == SM.Common.Enums.AccessType.Deny)
                SetColor(cnode,SM.Common.Enums.AccessType.Deny);
            AddContextMenu(cnode);
            node.Nodes.Add(cnode);
           

        }
        private void AddContextMenu(RadTreeNode node)
        {
            if(rdAllPermissions.Checked)
               node.ContextMenu = this.radContextMenuAccess;
        }
        private Image GetOperationImage()
        {

            var image = ISE.SM.Client.Properties.Resources.operation;
            return image;


        }
        private Image GetImage(int? resourceType)
        {
            if (resourceType == 1) // sub menu
            {
                var image = ISE.SM.Client.Properties.Resources.menu;
                return image;
            }
            if (resourceType == 2) // menu item
            {
                var image = ISE.SM.Client.Properties.Resources.form;
                return image;
            }
            return null;
        }
        public void LoadUsers()
        {
       
            var result = view.LoadUsers();
            userBS.DataSource = result;
            roleBS.DataSource = view.RoleBindingList;
            groupBS.DataSource = view.GroupBindingList;
            
            this.gridUsers.DataSource = userBS;
            this.iGridEXGrp.DataSource = groupBS;
            this.iGridEXRole.DataSource = roleBS;
             
            
        }
        public void LoadAccounts()
        {
             var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
            if(user!=null){
                accBS.DataSource = view.LoadUserAccounts(user);
                this.iGridEXAcc.DataSource = accBS;
            }
            
        }
        private void gridUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                if (user != null)
                {
                    SecurityUserPresenter presenter = new SecurityUserPresenter();
                    if (user.RoleIdList == null || user.RoleIdList.Count==0)
                        user.RoleIdList = presenter.GetUserRoleIds(user.UserId);
                    if (user.GroupIdList == null || user.GroupIdList.Count == 0)
                        user.GroupIdList = presenter.GetUserGroupIds(user.UserId);
                    groupBS.DataSource = view.BindGroups(user.GroupIdList);
                    roleBS.DataSource = view.BindRoles(user.RoleIdList);
                    this.iGridEXGrp.DataSource = groupBS;
                    this.iGridEXRole.DataSource = roleBS;
                    LoadAccounts();
                    //time consum
                    ReloadTree();
                }

                
            }
           
        }

        private void btnAddGrp_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                SecurityGroupPresenter presenter = new SecurityGroupPresenter();
                var group = presenter.GetAll().SecurityGroupDtoList;
                var tbl = DataTableHelper.ConvertToDatatable<SecurityGroupDto>(group);
                ILov lovActionOrder;
                LovFields lfActionOrder;
                lfActionOrder = new LovFields();
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.DisplayName), "عنوان گروه", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.AppDomainName), "حوزه", 100, true);

                lovActionOrder = new ILov(this.btnAddGrp, "ليست نقش ها", tbl, lfActionOrder);
                var row = lovActionOrder.ShowDialog() as DataRow;
                if (row != null)
                {
                    var groupId = row.Field<int>(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.SecurityGroupId));
                    var selectedGroup = group.Where(it => it.SecurityGroupId == groupId).FirstOrDefault();
                    string message = string.Format("آیا از انتساب گروه {0} به {1} مطمئن هستید؟", selectedGroup.DisplayName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignToGroups(user, selectedGroup);
                }
            }
            
            
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                RolePresenter presenter = new RolePresenter();

                var roleList = presenter.GetAll().RoleDtoList;
                var tbl = DataTableHelper.ConvertToDatatable<RoleDto>(roleList);
                ILov lovActionOrder;
                LovFields lfActionOrder;
                lfActionOrder = new LovFields();
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((RoleDto m) => m.CondidateRoleName), "عنوان نقش", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((RoleDto m) => m.AppDomainName), "حوزه", 100, true);

                lovActionOrder = new ILov(this.btnAddRole, "ليست نقش ها", tbl, lfActionOrder);
                var row = lovActionOrder.ShowDialog() as DataRow;
                if (row != null)
                {
                    var roleId = row.Field<int>(AssemblyReflector.GetMemberName((RoleDto m) => m.RoleId));
                    var selectedRole = roleList.Where(it => it.RoleId == roleId).FirstOrDefault();
                    string message = string.Format("آیا از انتساب نقش {0} به {1} مطمئن هستید؟", selectedRole.CondidateRoleName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignToRoles(user, selectedRole);
                }
            }
           
        }

        private void btnRemoveGrp_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null && this.iGridEXGrp.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                var group = (SecurityGroupDto)this.iGridEXGrp.CurrentRow.DataRow;
                RolePresenter presenter = new RolePresenter();


                if (group != null && user != null)
                {


                    string message = string.Format("آیا از انتساب لغو نقش {0} به {1} مطمئن هستید؟", group.DisplayName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.DeAssignToGroups(user, group);
                }
            }
           
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null && this.gridUsers.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                var role = (RoleDto)this.iGridEXRole.CurrentRow.DataRow;
                RolePresenter presenter = new RolePresenter();


                if (role != null && user != null)
                {


                    string message = string.Format("آیا از انتساب لغو نقش {0} به {1} مطمئن هستید؟", role.CondidateRoleName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.DeAssignToRoles(user, role);
                }
            }
            
        }

        private void iGridToolBar2_DeleteRecord(object sender, EventArgs e)
        {
            if (this.iGridEXAcc.CurrentRow != null)
            {
                var account = (AccountDto)this.iGridEXAcc.CurrentRow.DataRow;
                if (view.DeleteAccount(account))
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Delete);
                }
            }
           
        }

        private void iGridToolBar2_EditRecord(object sender, EventArgs e)
        {
            if (this.iGridEXAcc.CurrentRow != null)
            {
                var account = (AccountDto)this.iGridEXAcc.CurrentRow.DataRow;
                if (account != null)
                {
                    UCAccountEntry entry = new UCAccountEntry(ClassLibrary.TransMode.EditRecord, account);
                    ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "تغییر حساب", FormBorderStyle.FixedDialog);
                    if (entry.DialogResult != DialogResult.OK)
                        return;
                    if (view.UpdateAccount(entry.Account))
                        ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
                }
            }
           
        }

        private void iGridToolBar2_NewRecord(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                if (user != null)
                {
                    UCAccountEntry entry = new UCAccountEntry();
                    ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "ایجاد حساب", FormBorderStyle.FixedDialog);
                    if (entry.DialogResult != DialogResult.OK)
                        return;
                    if (view.AddAccount(entry.Account, user))
                        ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
                }
            }
            
            
        }

        private void iGridToolBar2_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void iGridToolBar2_RefreshData(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null && this.iGridEXAcc.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                var account = (AccountDto)this.iGridEXAcc.CurrentRow.DataRow;
                if (user != null && account != null)
                {
                    string text = string.Format("آیا از بازگردانی رمز عبور {0} , {1} مطمئن هستید؟", account.Description, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(text) != null)
                        return;
                    AccountPresenter accPresenter = new AccountPresenter();
                    accPresenter.ResetPassword(account.Username, user.UserId);
                }   
            }
                    
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null && this.iGridEXAcc.CurrentRow != null)
            {
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                var account = (AccountDto)this.iGridEXAcc.CurrentRow.DataRow;
                if (user != null && account != null)
                {
                    string text = string.Format("آیا از تغییر رمز عبور {0} , {1} مطمئن هستید؟", account.Description, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(text) != DialogResult.OK)
                        return;
                    ChangePasswordEntry entry = new ChangePasswordEntry();
                    ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "تغییر رمز عبور", FormBorderStyle.FixedDialog);
                    if (entry.DialogResult != DialogResult.OK)
                        return;

                    if (view.ChangePassword(account.Username, entry.NewPassword, entry.PrevPassword, account))
                    {
                        ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage("رمز عبور با موفقیت تغییر پیدا کرد.");
                    }
                }
            }
            
        }

        private void iGridToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void iGridToolBar1_NewRecord(object sender, EventArgs e)
        {
            UCUserEntry entry = new UCUserEntry(view);
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "تعریف کاربر", FormBorderStyle.FixedDialog);
        }

        private void iGridToolBar1_RefreshData(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void iGridToolBar1_EditRecord(object sender, EventArgs e)
        {
            var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
            if (user != null)
            {
                UCUserEntry entry = new UCUserEntry(view, ClassLibrary.TransMode.EditRecord, user);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "اطلاعات کاربر", FormBorderStyle.FixedDialog);
            }
        }

        private void iGridToolBar1_DeleteRecord(object sender, EventArgs e)
        {
            if (this.gridUsers.CurrentRow != null)
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert("آیا از حذف کاربر مطمئن هستید؟") != DialogResult.OK)
                    return;
                var user = (UserDto)this.gridUsers.CurrentRow.DataRow;
                if (view.DeleteUser(user))
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage("حذف شد.");
                }
            }
        }

        private void rdCurrentPermission_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdCurrentPermission.Checked)
            //{

            //    this.radTreeViewResource.Nodes.Clear();
            //    CreateCurrentTree();
            //}
        }

        private void rdAllPermissions_CheckedChanged(object sender, EventArgs e)
        {
            if (rdAllPermissions.Checked)
            {
                this.radTreeViewResource.Nodes.Clear();
                CreateAllTree();
            }
            if (rdCurrentPermission.Checked)
            {

                this.radTreeViewResource.Nodes.Clear();
                CreateCurrentTree();
            }
        }
        private void ReloadTree()
        {
            if (rdCurrentPermission.Checked)
            {

                this.radTreeViewResource.Nodes.Clear();
                CreateCurrentTree();
            }
            if (rdAllPermissions.Checked)
            {
                this.radTreeViewResource.Nodes.Clear();
                CreateAllTree();
            }
        }

        private void radTreeViewResource_NodeCheckedChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            if(rdCurrentPermission.Checked)
                e.Cancel = true;
          

        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            List<PermissionDto> updateList = new List<PermissionDto>();
            if (rdAllPermissions.Checked)
            {
                if (changeList.Count > 0)
                {
                    foreach (var item in changeList)
                    {
                        var permission = (PermissionDto)item.Value;
                        if (item.Tag == SM.Common.Enums.AccessType.Access.ToString())
                        {
                            permission.AccessType = SM.Common.Enums.AccessType.Access;
                        }
                        else if (item.Tag == SM.Common.Enums.AccessType.None.ToString())
                        {
                            permission.AccessType = SM.Common.Enums.AccessType.None;
                        }
                        else if (item.Tag == SM.Common.Enums.AccessType.Deny.ToString())
                        {
                            permission.AccessType = SM.Common.Enums.AccessType.Deny;
                        }
                        updateList.Add(permission);
                    }
                    if (view.UpdateUserPermissions(updateList, CurrentUserId))
                    {
                        ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage("ثبت اطلاعات انجام شد");

                    }
                }
            }
        }

        private void btnCancelChange_Click(object sender, EventArgs e)
        {
            if (rdAllPermissions.Checked)
            {
                if (changeList.Count > 0)
                {

                }
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadTree();
        }

   
        private void radTreeViewResource_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
        {
            var node = ((Telerik.WinControls.UI.RadTreeViewElement)(sender)).SelectedNode;
            if (node.Value is PermissionDto)
            {
               var permission = ((PermissionDto)node.Value);
               if (permission.OperationDto.Checked != node.Checked)
               {
                   if (node.Checked)
                   {
                       node.Tag = SM.Common.Enums.AccessType.Access.ToString();
                       SetColor(node, SM.Common.Enums.AccessType.Access);
                   }
                   else
                   {
                       node.Tag = SM.Common.Enums.AccessType.None.ToString();
                       SetColor(node, SM.Common.Enums.AccessType.None);
                   }
                   if (!changeList.Contains(node))
                       changeList.Add(node);
               }
               if (permission.OperationDto.Checked == node.Checked)
                {
                    if (changeList.Contains(node))
                    {
                        changeList.Remove(node);
                    }
                }
            }
        }

        private void UCUsers_Load(object sender, EventArgs e)
        {

        }

      
       
    }
}
