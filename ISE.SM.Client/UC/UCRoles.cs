using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.SM.Common.DTO;
using ISE.SM.Client.View;
using ISE.SM.Client.UCEntry;
using ISE.ClassLibrary;
using Telerik.WinControls.UI;
using ISE.SM.Client.Common.Presenter;
using ISE.Framework.Utility.Utils;
using ISE.UILibrary.Lov;

namespace ISE.SM.Client.UC
{
    public partial class UCRoles : IUserControl
    {
        RoleView view = new RoleView();
        ResourceView resview = new ResourceView();
        BindingSource roleBs = new BindingSource();
        BindingSource userBs = new BindingSource();
        BindingSource groupBs = new BindingSource();
        List<RadTreeNode> changeList = new List<RadTreeNode>();
        public UCRoles()
        {
            InitializeComponent();
            InitializeContexMenue();
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEX1);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXUser);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXGroups);
            LoadData();
            //CreateTree();
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
        private void LoadData()
        {
            roleBs.DataSource = view.LoadRoles();
            this.iGridEX1.DataSource = roleBs;
        }
        private void CreateTree()
        {
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            var appDomains = resview.LoadApplicationDomains();
            // var resourceTypes = view.LoadResourceTypeList();
            if (appDomains != null)
            {
                var resources = view.LoadResources(CurrentRoleId);
                List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
                if (resources != null)
                {
                    submenus = resources.Where(it => it.ResourceTypeId == 1 || it.ResourceTypeId==0).ToList();
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

                            var submenuNode = CreateSubmenuTree(submenu, submenus);

                            if (submenuNode != null)
                            {
                                if (submenu.Checked)
                                {
                                    submenuNode.Checked = true;
                                    appNode.Checked = true;
                                }
                                submenuNode.Value = submenu;
                                appNode.Nodes.Add(submenuNode);
                            }

                        }
                    }
                    nodeList.Add(appNode);
                }
            }

            this.radTreeViewResource.Nodes.AddRange(nodeList);
        }
        private int CurrentRoleId
        {
            get
            {
                var user = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                if (user != null)
                {
                    return user.RoleId;
                }
                return 0;
            }
        }
        RadTreeNode CreateApplicationNode(ApplicationDomainDto appDomain)
        {
            var image = ISE.SM.Client.Properties.Resources.application2;
            RadTreeNode node = new RadTreeNode(appDomain.Title);
            node.Image = image;
            return node;
        }
        RadTreeNode CreateSubmenuTree(SecurityResourceDto resource,List<SecurityResourceDto> resources)
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
                var subNode = CreateSubmenuTree(item, resources);

                var subimage = GetImage(item.ResourceTypeId);
               
                var permissions = view.LoadPermissions();
                var permissionItems = permissions.Where(it => it.ResourceId == item.SecurityResourceId).ToList();
                if (permissionItems.Count() > 0)
                {
                    foreach (var pitem in permissionItems)
                    {
                        CreateOperationNode(pitem, subNode);
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
        private void CreateOperationNode(PermissionDto permission, RadTreeNode node)
        {
            RadTreeNode cnode = new RadTreeNode(permission.OperationDto.DisplayName);
            var image = GetOperationImage();
            if (image != null)
            {
                cnode.Image = image;
            }
            if (permission.OperationDto.Checked)
                cnode.Checked = true;
            if (permission.AccessType == SM.Common.Enums.AccessType.Deny)
                SetColor(cnode, SM.Common.Enums.AccessType.Deny);
            AddContextMenu(cnode);
            cnode.Value = permission;
            node.Nodes.Add(cnode);


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
        private void iGridToolBar1_EditRecord(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                var role = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                if (role != null)
                {
                    UCRoleEntry entry = new UCRoleEntry(TransMode.EditRecord, role);
                    ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "ایجاد گروه", FormBorderStyle.FixedDialog);
                    if (entry.DialogResult != DialogResult.OK)
                        return;
                    view.Update(role);
                }
            }
          
        }

        private void iGridToolBar1_DeleteRecord(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowDeleteAlert() != DialogResult.OK)
                    return;
                var grp = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                view.Remove(grp);
            }
            
        }

        private void iGridToolBar1_NewRecord(object sender, EventArgs e)
        {
            UCRoleEntry entry = new UCRoleEntry();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "ایجاد نقش", FormBorderStyle.FixedDialog);
            if (entry.DialogResult != DialogResult.OK)
                return;
            if (view.Insert(entry.NewRoleDto))
                ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
        }

        private void iGridToolBar1_RefreshData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void iGridToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void iGridEX1_SelectionChanged(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {

                ReloadTree();
                var role = this.iGridEX1.CurrentRow.DataRow as RoleDto;

                userBs.DataSource = view.LoadUsers(role);
                groupBs.DataSource = view.LoadGroups(role);
                this.iGridEXUser.DataSource = userBs;
                this.iGridEXGroups.DataSource = groupBs;
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

        private void CreateCurrentTree()
        {
            if (CurrentRoleId > 0)
                CreateAllTree(0);
        }
        private void AddContextMenu(RadTreeNode node)
        {
            if (rdAllPermissions.Checked)
                node.ContextMenu = this.radContextMenuAccess;
        }
        private void CreateAllTree(int all = 1)
        {
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            var appDomains = resview.LoadApplicationDomains();
            // var resourceTypes = view.LoadResourceTypeList();
            if (appDomains != null)
            {
                var resources = view.LoadResources(CurrentRoleId, all);
                List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
                if (resources != null)
                {
                    submenus = resources.Where(it => it.ResourceTypeId == 1 || it.ResourceTypeId==0).ToList();
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

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                var role = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                SecurityUserPresenter presenter = new SecurityUserPresenter();
                var users = presenter.GetAll().UserDtoList;
                var tbl = DataTableHelper.ConvertToDatatable<UserDto>(users);
                ILov lovActionOrder;
                LovFields lfActionOrder;
                lfActionOrder = new LovFields();
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((UserDto m) => m.FirstName), "نام", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((UserDto m) => m.LastName), "نام خانوادگی", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((UserDto m) => m.PersonelCode), "کد پرسنلی", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((UserDto m) => m.NationalNo), "کد ملی", 100, true);

                lovActionOrder = new ILov(this.btnAddUser, "ليست کاربران", tbl, lfActionOrder);
                var row = lovActionOrder.ShowDialog() as DataRow;
                if (row != null)
                {
                    var userId = row.Field<long>(AssemblyReflector.GetMemberName((UserDto m) => m.UserId));
                    var selectedUser = users.Where(it => it.UserId == userId).FirstOrDefault();
                    string message = string.Format("آیا از انتساب نقش {0} به {1} مطمئن هستید؟", role.RoleName, selectedUser.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignUser(role, selectedUser);
                }
            }
           
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null && this.iGridEXUser.CurrentRow != null)
            {
                var role = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                var user = (UserDto)this.iGridEXUser.CurrentRow.DataRow;



                if (role != null && user != null)
                {


                    string message = string.Format("آیا از لغو انتساب نقش {0} به {1} مطمئن هستید؟", role.RoleName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.DeAssignUser(role, user);
                }
            }
           
        }

        private void btnAddGrp_Click(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                var role = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                SecurityGroupPresenter presenter = new SecurityGroupPresenter();
                var groups = presenter.GetAll().SecurityGroupDtoList;
                var tbl = DataTableHelper.ConvertToDatatable<SecurityGroupDto>(groups);
                ILov lovActionOrder;
                LovFields lfActionOrder;
                lfActionOrder = new LovFields();
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.GroupName), "نام", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.AppDomainName), "نام خانوادگی", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.DisplayName), "نام نمایشی", 100, true);


                lovActionOrder = new ILov(this.btnAddGrp, "ليست گروه ها", tbl, lfActionOrder);
                var row = lovActionOrder.ShowDialog() as DataRow;
                if (row != null)
                {
                    var grpId = row.Field<int>(AssemblyReflector.GetMemberName((SecurityGroupDto m) => m.SecurityGroupId));
                    var selectedGroup = groups.Where(it => it.SecurityGroupId == grpId).FirstOrDefault();
                    string message = string.Format("آیا از عضویت نقش {0} در {1} مطمئن هستید؟", role.RoleName, selectedGroup.DisplayName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignToGroup(role, selectedGroup);
                }
            }
           
        }

        private void btnRemoveGrp_Click(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null && this.iGridEXGroups.CurrentRow != null)
            {
                var role = (RoleDto)this.iGridEX1.CurrentRow.DataRow;
                var group = (SecurityGroupDto)this.iGridEXGroups.CurrentRow.DataRow;



                if (role != null && group != null)
                {


                    string message = string.Format("آیا از لغو انتساب نقش {0} به {1} مطمئن هستید؟", role.RoleName, group.DisplayName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.DeAssignFromGroup(role, group);
                }
            }
           
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            List<PermissionDto> updateList = new List<PermissionDto>();
           
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
                    if (view.UpdateRolePermissions(updateList, CurrentRoleId))
                    {
                        ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage("ثبت اطلاعات انجام شد");

                    }
                }
           
        }
        private void SetColor(RadTreeNode node, SM.Common.Enums.AccessType type)
        {
            if (type == SM.Common.Enums.AccessType.Deny)
                node.ForeColor = Color.Tomato;
            else
                node.ForeColor = Color.Black;
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

        private void rdCurrentPermission_CheckedChanged(object sender, EventArgs e)
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

        private void radTreeViewResource_SelectedNodeChanging(object sender, RadTreeViewCancelEventArgs e)
        {

        }

        private void radTreeViewResource_NodeCheckedChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            if (rdCurrentPermission.Checked)
            {
                e.Cancel = true;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ReloadTree();
        }
    }
}
