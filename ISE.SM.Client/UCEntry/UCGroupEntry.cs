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
using ISE.SM.Client.Common.Presenter;
using ISE.Framework.Utility.Utils;
using ISE.SM.Common.DTO;
using ISE.ClassLibrary;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCGroupEntry : IUserControl
    {
        
        TransMode tmode;
        public SecurityGroupDto NewGroup { get; set; }
        public DialogResult DialogResult { get; set; }
        public UCGroupEntry(TransMode tmode,SecurityGroupDto group)
        {
            this.tmode = tmode;
            DialogResult = System.Windows.Forms.DialogResult.None;
            InitializeComponent();
            LoadAppDomains();
            if (tmode == TransMode.EditRecord || tmode == TransMode.ViewRecord)
            {
                NewGroup = group;
                this.txtDisplayName.Text = group.DisplayName;
                this.txtGroupName.Text = group.GroupName;
                this.chkEnabled.Checked = group.IsEnabled;
                if(group.AppDomainId!=null)
                   this.cmbDomain.SelectedValue = group.AppDomainId;
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
         public UCGroupEntry()
        {

            this.tmode = TransMode.NewRecord;
            DialogResult = System.Windows.Forms.DialogResult.None;
            InitializeComponent();
            LoadAppDomains();
           
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
               
                SecurityGroupDto group = new SecurityGroupDto()
                {
                    DisplayName = txtDisplayName.Text,
                    Enabled = enabled,
                    GroupName = txtGroupName.Text,
                };
                if (this.cmbDomain.SelectedValue != null)
                {
                    group.AppDomainId = (int)this.cmbDomain.SelectedValue;
                }
                NewGroup = group;
            }
            else if (tmode == TransMode.EditRecord)
            {
                if (NewGroup != null)
                {
                    if (this.cmbDomain.SelectedValue != null)
                    {
                        NewGroup.AppDomainId = (int)this.cmbDomain.SelectedValue;
                    }
                    NewGroup.ApplicationDomainDto = (ApplicationDomainDto) cmbDomain.SelectedItem;
                    NewGroup.Enabled = enabled;
                    NewGroup.GroupName = txtGroupName.Text;
                    NewGroup.DisplayName = txtDisplayName.Text;
                }
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ParentForm.Close();
        }

        private void iTransToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
