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
using ISE.SM.Client.UCEntry;
using ISE.SM.Client.View;
using ISE.ClassLibrary;
using ISE.SM.Common.DTO;
using ISE.SM.Client.Common.Presenter;
using Telerik.WinControls.UI;
using ISE.Framework.Utility.Utils;
using ISE.UILibrary.Lov;

namespace ISE.SM.Client.UC
{
    public partial class UCGroups : IUserControl
    {
        SecurityGroupView view = new SecurityGroupView();
        ResourceView resview = new ResourceView();
        BindingSource groupBs = new BindingSource();
        BindingSource userBs = new BindingSource();
        BindingSource roleBs = new BindingSource();
        public UCGroups()
        {
            InitializeComponent();
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXGroup);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXUser);
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEXRole);
            LoadData();
           // CreateTree();
        }
        private int CurrentGroupId
        {
            get
            {
                var user = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
                if (user != null)
                {
                    return user.SecurityGroupId;
                }
                return 0;
            }
        }
        private void iGridToolBar1_NewRecord(object sender, EventArgs e)
        {
            UCGroupEntry entry = new UCGroupEntry();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "ایجاد گروه", FormBorderStyle.FixedDialog);
            if (entry.DialogResult != DialogResult.OK)
                return;
            if (view.Insert(entry.NewGroup))
                ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
           
        }
        private void CreateTree()
        {
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            var appDomains = resview.LoadApplicationDomains();
            // var resourceTypes = view.LoadResourceTypeList();
            if (appDomains != null)
            {
                var resources = view.LoadResources(CurrentGroupId);
                List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
                if (resources != null)
                {
                    submenus = resources.Where(it => it.ResourceTypeId == 1||it.ResourceTypeId==0).ToList();
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
        private void LoadData()
        {
            groupBs.DataSource = view.LoadGroups();
            this.iGridEXGroup.DataSource = groupBs;
        }

        private void iGridToolBar1_EditRecord(object sender, EventArgs e)
        {
            if (this.iGridEXGroup.CurrentRow != null)
            {
                var grp = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
                if (grp != null)
                {
                    UCGroupEntry entry = new UCGroupEntry(TransMode.EditRecord, grp);
                    ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "ایجاد گروه", FormBorderStyle.FixedDialog);
                    if (entry.DialogResult != DialogResult.OK)
                        return;
                    view.Update(grp);
                }
            }
           
            
        }

        private void iGridToolBar1_DeleteRecord(object sender, EventArgs e)
        {
            if (this.iGridEXGroup.CurrentRow != null)
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowDeleteAlert() != DialogResult.OK)
                    return;
                var grp = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
                view.Remove(grp);
            }
           
        }

        private void iGridToolBar1_RefreshData(object sender, EventArgs e)
        {
            LoadData();
        }

        private void iGridToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void iGridEXGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (this.iGridEXGroup.CurrentRow != null)
            {
                var group = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;

                userBs.DataSource = view.LoadUsers(group);
                roleBs.DataSource = view.LoadRoles(group);
                this.iGridEXUser.DataSource = userBs;
                this.iGridEXRole.DataSource = roleBs;
                ReloadTree();
            }
           
        }

        private void ReloadTree()
        {
            this.radTreeViewResource.Nodes.Clear();
            CreateTree();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (this.iGridEXGroup.CurrentRow != null)
            {
                var group = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
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
                    string message = string.Format("آیا از انتساب گروه {0} به {1} مطمئن هستید؟", group.DisplayName, selectedUser.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignUser(group, selectedUser);
                }
            }
            
        }

        private void btnRemoveUser_Click(object sender, EventArgs e)
        {
            if(this.iGridEXGroup.CurrentRow!=null &&  this.iGridEXUser.CurrentRow!=null)
            {
                var group = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
                var user = (UserDto)this.iGridEXUser.CurrentRow.DataRow;



                if (group != null && user != null)
                {


                    string message = string.Format("آیا از لغو انتساب گروه {0} به {1} مطمئن هستید؟", group.DisplayName, user.FullName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.DeAssignUser(group, user);
                }
            }
            
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (this.iGridEXGroup.CurrentRow != null)
            {
                var group = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
                RolePresenter presenter = new RolePresenter();
                var roles = presenter.GetAll().RoleDtoList;
                var tbl = DataTableHelper.ConvertToDatatable<RoleDto>(roles);
                ILov lovActionOrder;
                LovFields lfActionOrder;
                lfActionOrder = new LovFields();
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((RoleDto m) => m.RoleName), "نام", 100, true);
                lfActionOrder.AddItem(AssemblyReflector.GetMemberName((RoleDto m) => m.AppDomainName), "نام حوزه", 100, true);


                lovActionOrder = new ILov(this.btnAddRole, "ليست نقش ها", tbl, lfActionOrder);
                var row = lovActionOrder.ShowDialog() as DataRow;
                if (row != null)
                {
                    var roleId = row.Field<int>(AssemblyReflector.GetMemberName((RoleDto m) => m.RoleId));
                    var selectedRole = roles.Where(it => it.RoleId == roleId).FirstOrDefault();
                    string message = string.Format("آیا از انتساب گروه {0} به  نفش {1} مطمئن هستید؟", group.DisplayName, selectedRole.RoleName);
                    if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                        return;
                    view.AssignRole(group, selectedRole);
                }
            }
            
        }

        private void btnRemoveRole_Click(object sender, EventArgs e)
        {
            var group = (SecurityGroupDto)this.iGridEXGroup.CurrentRow.DataRow;
            var role = (RoleDto)this.iGridEXRole.CurrentRow.DataRow;



            if (group != null && role != null)
            {


                string message = string.Format("آیا از لغو انتساب گروه {0} به نقش {1} مطمئن هستید؟", group.DisplayName, role.RoleName);
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert(message) != DialogResult.OK)
                    return;
                view.DeAssignRole(group, role);
            }
        }

        private void radTreeViewResource_SelectedNodeChanging(object sender, RadTreeViewCancelEventArgs e)
        {
          
        }

        private void radTreeViewResource_NodeCheckedChanged(object sender, TreeNodeCheckedEventArgs e)
        {

        }

        private void radTreeViewResource_NodeCheckedChanging(object sender, RadTreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
