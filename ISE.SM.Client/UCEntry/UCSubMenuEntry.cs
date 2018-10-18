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

namespace ISE.SM.Client.UCEntry
{
    public partial class UCSubMenuEntry : IUserControl
    {
        TransMode mode;
        public SecurityResourceDto SecurityResource { get; set; }
        public DialogResult DialogResult { get; set; }
        public UCSubMenuEntry()
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.None;
        }
        public UCSubMenuEntry(TransMode mode,SecurityResourceDto resource)
        {
            this.mode = mode;
            this.SecurityResource = resource;
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.None;
            if (mode == TransMode.EditRecord || mode == TransMode.ViewRecord)
            {
                txtTitle.Text = resource.ResourceName;
                chkEnabled.Checked = resource.IsEnabled;
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (mode == TransMode.EditRecord)
            {
                if (SecurityResource != null)
                {
                    SecurityResource.ResourceName = txtTitle.Text;
                    SecurityResource.IsEnabled = chkEnabled.Checked;
                    SecurityResource.ResourceTypeId = (int)ISE.SM.Client.UC.UCResource.MenuType.SubMenu;
                    SecurityResource.DisplayName = txtTitle.Text;
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (mode == TransMode.NewRecord)
            {
                SecurityResource = new SecurityResourceDto()
                {
                    ResourceName = txtTitle.Text,
                    DisplayName = txtTitle.Text,
                    IsEnabled = chkEnabled.Checked,
                    ResourceTypeId = (int)ISE.SM.Client.UC.UCResource.MenuType.SubMenu
                };
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.ParentForm.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
