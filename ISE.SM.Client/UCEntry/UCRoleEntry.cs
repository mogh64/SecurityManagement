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
using ISE.SM.Client.Common.Presenter;
using ISE.Framework.Utility.Utils;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCRoleEntry : IUserControl
    {
        public UCRoleEntry()
        {
            tmode = TransMode.NewRecord;
            InitializeComponent();
            LoadAppDomains();
        }
        TransMode tmode;
        public RoleDto NewRoleDto { get; set; }
        public DialogResult DialogResult { get; set; }
        public UCRoleEntry(TransMode tmode, RoleDto role)
        {
            this.tmode = tmode;
            InitializeComponent();
            NewRoleDto = role;
            LoadAppDomains();
            if (tmode == TransMode.EditRecord || tmode == TransMode.ViewRecord)
            {
                NewRoleDto = role;
                this.txtDisplayName.Text = role.CondidateRoleName;
                this.txtGroupName.Text = role.RoleName;
                this.chkEnabled.Checked = role.IsEnabled;
                if (role.AppDomainId != null)
                    this.cmbDomain.SelectedValue = role.AppDomainId;
                else
                {
                    this.cmbDomain.SelectedIndex = -1;
                }
                if (tmode == TransMode.ViewRecord)
                {
                    this.txtDisplayName.ReadOnly = true;
                    this.txtGroupName.ReadOnly = true;
                    this.chkEnabled.Enabled = false;
                    this.cmbDomain.Enabled = false;
                }
            }
        }
        public void LoadAppDomains()
        {
            AppDomainPresenter appDomainPresenter = new AppDomainPresenter();
            var lst = appDomainPresenter.GetAppDomainList();
            cmbDomain.DataSource = lst;
            cmbDomain.DisplayMember = AssemblyReflector.GetMemberName((ApplicationDomainDto m) => m.Title);
            cmbDomain.ValueMember = AssemblyReflector.GetMemberName((ApplicationDomainDto m) => m.ApplicationDomainId);
        }
        private void iTransToolBar1_SaveRecord(object sender, EventArgs e)
        {
            short enabled = 0;
            if (chkEnabled.Checked)
            {
                enabled = 1;
            }
            if (tmode == TransMode.NewRecord)
            {

                RoleDto group = new RoleDto()
                {
                    CondidateRoleName = txtDisplayName.Text,
                    Enabled = enabled,
                    RoleName = txtGroupName.Text,
                };
                if (this.cmbDomain.SelectedValue != null)
                {
                    group.AppDomainId = (int)this.cmbDomain.SelectedValue;
                }
                NewRoleDto = group;
            }
            else if (tmode == TransMode.EditRecord)
            {
                if (NewRoleDto != null)
                {
                    if (this.cmbDomain.SelectedValue != null)
                    {
                        NewRoleDto.AppDomainId = (int)this.cmbDomain.SelectedValue;
                    }
                    NewRoleDto.ApplicationDomainDto = (ApplicationDomainDto)cmbDomain.SelectedItem;
                    NewRoleDto.Enabled = enabled;
                    NewRoleDto.RoleName = txtGroupName.Text;
                    NewRoleDto.CondidateRoleName = txtDisplayName.Text;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ParentForm.Close();
        }

        private void iTransToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void iTransToolBar1_SaveAndNewRecord(object sender, EventArgs e)
        {

        }
    }
}
