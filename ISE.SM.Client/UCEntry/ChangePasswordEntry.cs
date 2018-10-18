using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;

namespace ISE.SM.Client.UCEntry
{
    public partial class ChangePasswordEntry : IUserControl
    {
        public DialogResult DialogResult { get; set; }
        public string NewPassword { get; set; }
        public string PrevPassword { get; set; }
        public ChangePasswordEntry()
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.None;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewPass.Text) && !string.IsNullOrWhiteSpace(txtNewPassRep.Text) && !string.IsNullOrWhiteSpace(txtPrevPass.Text))
            {
                if (txtNewPass.Text != txtNewPassRep.Text)
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowException("رمز عبور جدید با تکرار آن یکسان نیست!");
                    return;
                }
                NewPassword = txtNewPass.Text;
                PrevPassword = txtPrevPass.Text;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
