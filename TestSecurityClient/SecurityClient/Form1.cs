using ISE.SM.Client.Common.Presenter;
using ISE.SM.Common.DTO;
using ISE.SM.Common.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace SecurityClient
{
    public partial class Form1 : Form
    {
        AuthorizationPresenter presenter = new AuthorizationPresenter();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUname.Text;
            string password = txtPass.Text;
            var token =  presenter.Authenticate(userName, password, "1");
            if(token!=null){
                TokenContainer.SetToken(token);
                this.btnLoadMenu.Enabled = true;
                txtFname.Text= token.ClaimValue(ClaimTypes.Name);
                txtLname.Text = token.ClaimValue(ClaimTypes.FamilyName);
            }
               
            else
            {
                MessageBox.Show("No Token Exist");
            }
        }

        private void btnLoadMenu_Click(object sender, EventArgs e)
        {           
            var list=  presenter.GetMenuList(TokenContainer.CurrentToken, 1);

            LoadTree(list);

        }
        private void LoadTree(List<SecurityResourceDto> resources)
        {
            radTreeView1.Nodes.Clear();
            List<RadTreeNode> nodeList = new List<RadTreeNode>();
            
            List<SecurityResourceDto> submenus = new List<SecurityResourceDto>();
            if (resources != null)
            {
                submenus = resources.Where(it => it.ResourceTypeId == 1).ToList();
            }

            RadTreeNode appNode = new RadTreeNode("domain");


            var submenuList = submenus.Where(it => it.ParentId == null).ToList();
            if (submenuList != null)
            {
                foreach (var submenu in submenuList)
                {

                    var submenuNode = CreateSubmenuTree(submenu, resources);

                    if (submenuNode != null)
                    {


                        submenuNode.Value = submenu;

                        appNode.Nodes.Add(submenuNode);
                    }

                }
            }
            nodeList.Add(appNode);
            radTreeView1.Nodes.AddRange(nodeList);
        }
        RadTreeNode CreateSubmenuTree(SecurityResourceDto resource,List<SecurityResourceDto> lst)
        {
            RadTreeNode node = new RadTreeNode(resource.DisplayName);
           

            var resources = lst;
            var subNodes = resources.Where(it => it.ParentId == resource.SecurityResourceId).ToList();
            if (subNodes == null || subNodes.Count == 0)
                return node;
            foreach (var item in subNodes)
            {
                var subNode = CreateSubmenuTree(item,lst);
               
              
                if (subNode != null)
                {
                    subNode.Value = item;                   
                    node.Nodes.Add(subNode);
                }

            }
            return node;
        }
 

        private void radTreeView1_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            flowLayoutPanelOp.Controls.Clear();
            RadTreeViewElement element = (RadTreeViewElement)sender;
            SecurityResourceDto resource = (SecurityResourceDto)element.SelectedNode.Value;
            if (resource != null)
            {
                if (resource.ResourceTypeId == 1)// is submenu
                {
                    return;
                }
                var access = presenter.CheckAccess(resource, TokenContainer.CurrentToken);
                if (rdUInfo.Checked)
                {
                    var userInfo = UserInfoGenerator.GenerateUserInfo(access, TokenContainer.CurrentToken);
                    FrmUserInfo frmUserInfo = new FrmUserInfo(userInfo);
                    frmUserInfo.Show();
                }
                else
                {
                    FrmAccessToken frmAtoken = new FrmAccessToken(access);
                    frmAtoken.Show();
                }
                if (access != null)
                {
                    foreach (var item in access.Operations)
                    {
                        Button opbtn = new Button()
                        {
                            Name = item.OperationId.ToString(),
                            Text = item.OperationName,
                            Tag = item,
                        };
                        flowLayoutPanelOp.Controls.Add(opbtn);
                    }
                }
               
            }
           
        }
    }
}
