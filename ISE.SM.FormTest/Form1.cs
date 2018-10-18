using ISE.Framework.Client.Common.Environment;
using ISE.Framework.Client.Win.Viewer;
using ISE.Framework.Common.Service.Security;
using ISE.SM.Client.CurrentContext;
using ISE.SM.Client.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISE.SM.FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            SetEnvironment();
            InitializeComponent();
            ContextHelper.SetCurrentUser();
        }
        private void SetEnvironment()
        {
            EnvironmentVariables.CurrentEnvironment = EnvironmentType.Win;
            EnvironmentVariables.RegisterViewer(new IseWinBussinessExceptionViewer(), EnvironmentVariables.CurrentEnvironment);
            ISE.Framework.Common.Service.Security.LoginContext.ServiceLogin = new ServiceLogin() { UserName = "92000711:IseSec", Password = "4285705761" };
        }
        private void btnUsers_Click(object sender, EventArgs e)
        {
            UCUsers users = new UCUsers();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(users, "کاربران", FormBorderStyle.Sizable);
        }

        private void btnGroup_Click(object sender, EventArgs e)
        {
            UCGroups grps = new UCGroups();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(grps, "گروه ها", FormBorderStyle.Sizable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UCRoles grps = new UCRoles();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(grps, "نقش ها", FormBorderStyle.Sizable);
        }

        private void btnResource_Click(object sender, EventArgs e)
        {

            UCResource resource = new UCResource();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(resource, "منابع ", FormBorderStyle.Sizable);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UCOperation ucop = new UCOperation();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(ucop, "منابع", FormBorderStyle.Sizable);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login loginFrm = new login();
            loginFrm.Show();
            
        }
    }
}
