using ISE.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityClient
{
    public partial class FrmUserInfo : Form
    {
        public FrmUserInfo()
        {
            InitializeComponent();
        }
        public FrmUserInfo(UserInformation userInfo)
        {
            InitializeComponent();
            txtUId.Text = userInfo.UserId.ToString();
            txtUName.Text = userInfo.UserName;
            txtFName.Text = userInfo.FirstName;
            txtLName.Text = userInfo.LastName;
            txtPerId.Text = userInfo.PerId.ToString();
            txtActionId.Text = userInfo.ActionId.ToString();
            txtNoUpdate.Text = userInfo.NoUpdate.ToString();
        }
    }
}
