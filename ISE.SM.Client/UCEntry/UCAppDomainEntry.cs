using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.ClassLibrary;
using ISE.SM.Common.DTO;
using ISE.SM.Client.View;
using ISE.Framework.Utility.Utils;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCAppDomainEntry : IUserControl
    {
        TransMode mode;
        public ApplicationDomainDto ApplicationDomain { get; set; }
        public DialogResult DialogResult { get; set; }
        ResourceView view;
        public UCAppDomainEntry(ResourceView view)
        {
            this.view = view;
            DialogResult = System.Windows.Forms.DialogResult.None;
            InitializeComponent();
            var loginTypes = view.GetLoginTypes();
            cmbLoginType.DataSource = loginTypes;
            cmbLoginType.DisplayMember = AssemblyReflector.GetMemberName((LoginTypeDto m) => m.Title);
            cmbLoginType.ValueMember = AssemblyReflector.GetMemberName((LoginTypeDto m) => m.LoginTypeId);
        }
        public UCAppDomainEntry(TransMode mode,ApplicationDomainDto appDomain,ResourceView view)
        {
            DialogResult = System.Windows.Forms.DialogResult.None;
            this.view = view;
            InitializeComponent();
            this.mode = mode;
            this.ApplicationDomain = appDomain;
            var loginTypes = view.GetLoginTypes();
            cmbLoginType.DataSource = loginTypes;
            cmbLoginType.DisplayMember = AssemblyReflector.GetMemberName((LoginTypeDto m) => m.Title);
            cmbLoginType.ValueMember = AssemblyReflector.GetMemberName((LoginTypeDto m) => m.LoginTypeId);
            if (mode == TransMode.EditRecord || mode == TransMode.ViewRecord)
            {
                txtTitle.Text = appDomain.Title;
                chkEnable.Checked = appDomain.IsEnabled;
                chkLock.Checked = appDomain.IsLocked;
                if (appDomain.LoginTypeId!=null)
                   cmbLoginType.SelectedValue = appDomain.LoginTypeId;
            }            
        }

        private void iTransToolBar1_SaveRecord(object sender, EventArgs e)
        {
            
        }

        private void iTransToolBar1_SaveAndNewRecord(object sender, EventArgs e)
        {

        }

        private void iTransToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mode==TransMode.EditRecord && ApplicationDomain != null)
            {
                ApplicationDomain.Title = txtTitle.Text;
                ApplicationDomain.IsLocked = chkLock.Checked;
                ApplicationDomain.IsEnabled = chkEnable.Checked;
                ApplicationDomain.LoginTypeId = (short)cmbLoginType.SelectedValue;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.ParentForm.Close();
            }
            if (mode == TransMode.NewRecord)
            {
                ApplicationDomainDto newDto = new ApplicationDomainDto() { 
                    Title = txtTitle.Text,
                    IsLocked= chkLock.Checked,
                    IsEnabled=chkEnable.Checked,
                    LoginTypeId = (short) cmbLoginType.SelectedValue
                };
                ApplicationDomain = newDto;
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.ParentForm.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
