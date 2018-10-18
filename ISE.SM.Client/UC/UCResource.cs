using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.SM.Client.View;
using ISE.Framework.Utility.Utils;
using ISE.SM.Common.DTO;
using Telerik.WinControls.UI;
using ISE.SM.Client.UCEntry;
using ISE.ClassLibrary;
using ISE.SM.Client.Common.Presenter;

namespace ISE.SM.Client.UC
{
    public partial class UCResource : IUserControl
    {
        ResourceView view = new ResourceView();
        
        public UCResource()
        {
            InitializeComponent();
            InitializeRadMenuItemEvents();
            Reload();
           
        }
        private void Reload()
        {
            this.radTreeViewResource.Nodes.Clear();
            CreateTree();
        }
        private void InitializeRadMenuItemEvents()
        {
            this.radMenuItemAddResourceItem.Click += RadMenuItemClicked;
            this.radMenuItemAddSubMenu.Click += RadMenuItemClicked;
            this.radMenuItemAddSubMenuItem.Click += RadMenuItemClicked;
            this.radMenuItemDelete.Click += RadMenuItemClicked;
            this.radMenuItemDeleteMenuItem.Click += RadMenuItemClicked;
            this.radMenuItemDeleteResource.Click += RadMenuItemClicked;
            this.radMenuItemEdit.Click += RadMenuItemClicked;
            this.radMenuItemEditMenuItem.Click += RadMenuItemClicked;
            this.radMenuItemEditResource.Click += RadMenuItemClicked;
            this.radMenuItemAddAppDomain.Click += RadMenuItemClicked;
            this.radMenuItemAddOperation.Click += RadMenuItemClicked;
            this.radMenuItemDeleteOperation.Click += RadMenuItemClicked;
        }
        

        private void btnShow_Click(object sender, EventArgs e)
        {
           
        }

        private void iGridToolBar1_EditRecord(object sender, EventArgs e)
        {

        }

        private void iGridToolBar1_Close(object sender, EventArgs e)
        {

        }

        private void iGridToolBar1_NewRecord(object sender, EventArgs e)
        {

        }

        private void iGridToolBar1_RefreshData(object sender, EventArgs e)
        {

        }

        private void iGridToolBar1_DeleteRecord(object sender, EventArgs e)
        {

        }

        private void iGridEXResc_SelectionChanged(object sender, EventArgs e)
        {
          

        }
        private void CreateTree()
        {
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            var appDomains = view.LoadApplicationDomains();
           // var resourceTypes = view.LoadResourceTypeList();
            if (appDomains != null)
            {
                var resources = view.LoadResources(0);

                List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
                if (resources != null)
                {
                    submenus =  resources.Where(it => it.ResourceTypeId == 1 || it.ResourceTypeId==0).ToList();
                }
                foreach (var appDomain in appDomains.OrderBy(it=>it.Title).ToList())
                {
                    var appNode = CreateApplicationNode(appDomain);
                    appNode.Value = appDomain;
                    addContextMenu(appNode, MenuType.AppDomain);
                    var submenuList = submenus.Where(it => it.AppDomainId == appDomain.ApplicationDomainId && it.ParentId==null).ToList();
                    if (submenuList != null)
                    {
                        foreach (var submenu in submenuList)
                        {

                            var submenuNode = CreateSubmenuTree(submenu, submenus);
                            addContextMenu(submenuNode, (MenuType)submenu.ResourceTypeId);
                            if (submenuNode != null)
                            {
                                submenuNode.Value = submenu;
                                appNode.Nodes.Add(submenuNode);
                            }
                            
                            
                        }
                    }
                    nodeList.Add(appNode);
                }
            }
            //var submenu = resourceTypes.Where(it => it.Title == "submenu").FirstOrDefault();
            //if (submenu != null)
            //{

            //}
            this.radTreeViewResource.Nodes.AddRange(nodeList);
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
            var image = GetResourceImage(resource.ResourceTypeId);
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
                addContextMenu(subNode, (MenuType)item.ResourceTypeId);
                var subimage = GetResourceImage(item.ResourceTypeId);
                var permissions = view.LoadPermissions();
                var permissionItems = permissions.Where(it => it.ResourceId == item.SecurityResourceId).ToList();
                if (permissionItems.Count() > 0)
                {
                    foreach (var pitem in permissionItems)
                    {
                        CreateOperationNode(pitem.OperationDto, subNode);
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
        private void CreateOperationNode(OperationDto operation, RadTreeNode node)
        {
            RadTreeNode cnode = new RadTreeNode(operation.DisplayName);
            var image = GetOperationImage();
            if (image != null)
            {
                cnode.Image = image;
            }
            cnode.Value = operation;
            node.Nodes.Add(cnode);
            addContextMenu(cnode, MenuType.Operation);

        }
        private void RadMenuItemClicked(object sender, EventArgs e)
        {
            var name = ((Telerik.WinControls.RadItem)(sender)).AccessibleDescription;
            if (name == "DeleteApp")
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert("آیا از حذف دامنه مطمئن هستی؟") != DialogResult.OK)
                    return;
                var node = this.radTreeViewResource.SelectedNode;
                ApplicationDomainDto app = (ApplicationDomainDto)node.Value;
                if (node.Nodes.Count == 0)
                {
                    if (view.RemoveAppDomain(app))
                    {
                        this.radTreeViewResource.Nodes.Remove(node);
                    }
                }
                else
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowException("غیر قابل حذف می باشد!");
                }                
            }
            else if (name == "EditApp")
            {
                var node = this.radTreeViewResource.SelectedNode;
                ApplicationDomainDto app = (ApplicationDomainDto)node.Value;
                UCAppDomainEntry entry = new UCAppDomainEntry(TransMode.EditRecord,app,view);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "دامنه", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if( view.UpdateAppDomain(app))
                {
                    node.Text = app.Title;
                }
            }
            else if (name == "AddAppDomain")
            {
                UCAppDomainEntry entry = new UCAppDomainEntry(view);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "دامنه", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if(view.InsertAppDomain(entry.ApplicationDomain))
                {
                    var appNode = CreateApplicationNode(entry.ApplicationDomain);
                    appNode.Value = entry.ApplicationDomain;
                    addContextMenu(appNode, MenuType.AppDomain);
                    this.radTreeViewResource.Nodes.Add(appNode);
                }
            }
            else if (name == "CreateSubmenu")
            {
                var node = this.radTreeViewResource.SelectedNode;
                UCSubMenuEntry entry = new UCSubMenuEntry();
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "زیر منو", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if (node.Value is ApplicationDomainDto)
                {
                    var val = (ApplicationDomainDto)node.Value;
                    entry.SecurityResource.AppDomainId = val.ApplicationDomainId;
                }
                else if (node.Value is SecurityResourceDto)
                {
                    var val = (SecurityResourceDto)node.Value;
                    entry.SecurityResource.AppDomainId = val.AppDomainId;
                    entry.SecurityResource.ParentId = val.SecurityResourceId;
                }
                if(view.Insert(entry.SecurityResource))
                {

                    var resources = view.LoadResources(0);
                    var submenuNode = CreateSubmenuTree(entry.SecurityResource, resources);
                    addContextMenu(submenuNode, (MenuType)entry.SecurityResource.ResourceTypeId);
                    if (submenuNode != null)
                    {
                        submenuNode.Value = entry.SecurityResource;
                        
                        node.Nodes.Add(submenuNode);
                        node.Expand();
                    }
                }
            }
            else if (name == "EditSubmenu")
            {
                var node = this.radTreeViewResource.SelectedNode;
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                UCSubMenuEntry entry = new UCSubMenuEntry(TransMode.EditRecord, subMenu);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "زیر منو", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if(view.Update(subMenu))
                {
                    node.Text = subMenu.DisplayName;
                }
            }
            else if (name == "DeleteSubmenu")
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert("آیا از حذف زیر منو مطمئن هستید؟") != DialogResult.OK)
                    return;
                var node = this.radTreeViewResource.SelectedNode;
                var parent = node.Parent;
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                if (node.Nodes.Count == 0)
                {
                    if (view.Remove(subMenu))
                    {
                        parent.Nodes.Remove(node);
                    }
                }
                else
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowException("غیر قابل حذف می باشد!");
                }
               
            }           
            else if (name == "CreateResource")
            {
                UCResourceEntry entry = new UCResourceEntry();
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "زیر منو", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                var node = this.radTreeViewResource.SelectedNode;
                
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                entry.SecurityResource.AppDomainId = subMenu.AppDomainId;
                entry.SecurityResource.ParentId = subMenu.SecurityResourceId;
                if (view.Insert(entry.SecurityResource))
                {
                    var resources = view.LoadResources(0);
                    var newNode = CreateSubmenuTree(entry.SecurityResource, resources);
                    node.Nodes.Add(newNode);
                }
            }
            else if (name == "EditResource")
            {
                 var node = this.radTreeViewResource.SelectedNode;
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                UCResourceEntry entry = new UCResourceEntry(TransMode.EditRecord, subMenu);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "زیر منو", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if (view.Update(entry.SecurityResource))
                {
                    node.Text = subMenu.DisplayName;
                }
            }
            else if (name == "DeleteResource")
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert("آیا از حذف منبع مطمئن هستید؟") != DialogResult.OK)
                    return;
                var node = this.radTreeViewResource.SelectedNode;
                var parent = node.Parent;
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                if (node.Nodes.Count == 0)
                {
                    if (view.Remove(subMenu))
                    {
                        parent.Nodes.Remove(node);
                    }
                }
                else
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowException("غیر قابل حذف می باشد!");
                }
            }
            else if (name == "AddOperation")
            {
                var node = this.radTreeViewResource.SelectedNode;
                SecurityResourceDto subMenu = (SecurityResourceDto)node.Value;
                UCSelectOperation entry = new UCSelectOperation();
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "افزودن عملیات", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                ResourcePresenter presenter = new ResourcePresenter();
                var container =presenter.AddOperatins(subMenu, entry.SelectedOperations);
                if(container!=null)
                {
                    foreach (var item in container.PermissionDtoList)
                    {
                        var operation = entry.SelectedOperations.FirstOrDefault(it => it.OperationId == item.OperationId);
                        CreateOperationNode(operation, node);
                    }
                }
            }
            else if (name == "deleteOperation")
            {
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowAlert("آیا از حذف عملیات مطمئن هستید؟") != DialogResult.OK)
                    return;
                ResourcePresenter presenter = new ResourcePresenter();
                var node = this.radTreeViewResource.SelectedNode;
                var parent = node.Parent;
                SecurityResourceDto resource = (SecurityResourceDto)parent.Value;
                OperationDto operation = (OperationDto)node.Value;

                if (presenter.RemoveOperatin(resource, operation) != null)
                {
                    parent.Nodes.Remove(node);
                }
                else
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowException("غیر قابل حذف می باشد!");
                }
            }
        }
        private void iGroupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void addContextMenu(RadTreeNode node, MenuType menuType)
        {
            switch (menuType)
            {
                case MenuType.AppDomain:
                    {
                        node.ContextMenu = this.appDomainRadContextMenu1;
                    }
                    break;
                case MenuType.MenuItem:
                    {
                        node.ContextMenu = this.meuItemRadContextMenu3;
                    }
                    break;
                case MenuType.SubMenu:
                    {
                        node.ContextMenu = this.subMenuRadContextMenu2;
                    }
                    break;
                case MenuType.Operation:
                    {
                        node.ContextMenu = this.radContextMenuOperations;
                    }
                    break;
            }
        }
        private Image GetResourceImage(int? resourceType)
        {
            if (resourceType == 1) // sub menu
            {
                var image = ISE.SM.Client.Properties.Resources.menu;
                return image;
            }
            else if (resourceType == 2) // menu item
            {
                var image = ISE.SM.Client.Properties.Resources.form;
                return image;
            }
            
            return null;
        }
        private Image GetOperationImage()
        {
            
                var image = ISE.SM.Client.Properties.Resources.operation;
                return image;
            
            
        }
       public enum MenuType{
            AppDomain=0,
            SubMenu=1,
            MenuItem=2,
           Operation=3
        }

       private void btnExit_Click(object sender, EventArgs e)
       {
           this.ParentForm.Close();
       }

       private void btnRefresh_Click(object sender, EventArgs e)
       {
           Reload();
       }
    }
}
