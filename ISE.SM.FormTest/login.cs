using ISE.SM.Client.Common.Presenter;
using ISE.SM.Client.Common.User;
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
    public partial class login : Form
    {
        AuthorizationPresenter presnter;
        public login()
        {
            presnter = new AuthorizationPresenter();
            InitializeComponent();
        }

        private void btnLogn_Click(object sender, EventArgs e)
        {
          
            var authResult = presnter.Authenticate(txtUserName.Text, txtPass.Text, "1");
            if(authResult.IdentityToken!=null){
                UserContext.SetToken(authResult.IdentityToken);
                txtToken.Text = authResult.IdentityToken.ToString();
                lblMessage.Text =string.Empty;
               
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
              
            else
            {
                lblMessage.Text = authResult.ErrorMessage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mainFrm frm = new mainFrm();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           MessageBox.Show(presnter.ValidateIdentityToken(UserContext.CurrentToken).ToString());
        }
    }
}
