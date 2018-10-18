using ISE.SM.Client.Common.Presenter;
using ISE.SM.Client.Common.User;
using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ISE.SM.FormTest
{
    public partial class mainFrm : Form
    {
        AuthorizationPresenter presenter = new AuthorizationPresenter();
        public mainFrm()
        {
            InitializeComponent();
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            
            if (UserContext.CurrentToken != null)
            {
                

                var menuList = presenter.GetMenuList(UserContext.CurrentToken, 1);
                var parents = menuList.Where(it => it.ParentId == null).ToList();
                foreach (var item in parents)
                {
                    var node = CreateNode(item, menuList);
                    treeView1.Nodes.Add(node);
                }
               
            }                        
        }
        private TreeNode CreateNode(SecurityResourceDto resource, List<SecurityResourceDto> lst)
        {
            TreeNode node = new TreeNode(resource.DisplayName);
            node.Tag = resource;
            var childs = lst.Where(it => it.ParentId == resource.SecurityResourceId).ToList();
            if (childs == null || childs.Count == 0)
                return node;
            else
            {
                foreach (var item in childs)
                {
                    var ccnode = CreateNode(item, lst);
                    node.Nodes.Add(ccnode);
                }
            }
            return node;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            var resource = (SecurityResourceDto)((TreeView)sender).SelectedNode.Tag;
            if (resource != null)
            {
                if (UserContext.CurrentToken != null){
                    var authResult = presenter.CheckAccess(resource, UserContext.CurrentToken);
                    var userInfo = UserInfoGenerator.GenerateUserInfo(authResult.AccessToken, UserContext.CurrentToken);
                    if(authResult.AccessToken[1])
                    {
                        MessageBox.Show("has 1 access");
                    }
                    else
                    {
                        MessageBox.Show("has not 1 access");
                    }
                    if (authResult.AccessToken["Insert"] )
                    {
                        MessageBox.Show("has insert access");
                    }
                }
                
            }
        }
    }
}
