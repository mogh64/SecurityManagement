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
    public partial class UCResourceEntry : IUserControl
    {
        public DialogResult DialogResult { get; set; }
        public SecurityResourceDto SecurityResource { get; set; }
        TransMode mode;
       
        public UCResourceEntry()
        {
           
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            InitializeComponent();
            
        }
        public UCResourceEntry(TransMode mode,SecurityResourceDto resource)
        {
            
            this.SecurityResource = resource;
            InitializeComponent();
            
            this.mode = mode;
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (mode == TransMode.ViewRecord || mode == TransMode.EditRecord)
            {
                txtDisplayName.Text = resource.DisplayName;
                txtResourceName.Text = resource.ResourceName;
                txtNameSpace.Text = resource.Namespace;
                txtAssemblyName.Text = resource.AssemblyName;
                txtTooltip.Text = resource.ToolTip;
                txtPrecedence.Text = resource.Precedence.ToString();
                chkHasParam.Checked = resource.HasParam;
                chkEnabled.Checked = resource.IsEnabled;
            }
        }

      
        private void iTransToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
        private int GetResourceType()
        {
            if (rdMenuItem.Checked)
            {
                return (int)ISE.SM.Client.UC.UCResource.MenuType.MenuItem;
            }
            return 0;
        }

        private void iTransToolBar1_SaveRecord_1(object sender, EventArgs e)
        {
            int precedens = 0;
            int.TryParse(txtPrecedence.Text, out precedens);
            short hasParam = 0;
            if (chkHasParam.Checked)
                hasParam = 1;
            if (mode == TransMode.EditRecord || mode == TransMode.ViewRecord)
            {
                if (SecurityResource != null)
                {
                    SecurityResource.DisplayName = txtDisplayName.Text;
                    SecurityResource.ResourceName = txtResourceName.Text;
                    SecurityResource.Namespace = txtNameSpace.Text;
                    SecurityResource.AssemblyName = txtAssemblyName.Text;
                    SecurityResource.ToolTip = txtTooltip.Text;
                    SecurityResource.Precedence = precedens;
                    SecurityResource.HasParam = chkHasParam.Checked;
                    SecurityResource.IsEnabled = chkEnabled.Checked;
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                
            }
            else
            {
                
                SecurityResourceDto rec = new SecurityResourceDto()
                {
                    AssemblyName = txtAssemblyName.Text,
                    DisplayName = txtDisplayName.Text,
                    IsEnabled = chkEnabled.Checked,
                    ResourceName = txtResourceName.Text,
                    Namespace = txtNameSpace.Text,
                    ToolTip = txtTooltip.Text,
                    Precedence = precedens,
                    ResourceTypeId = GetResourceType(),
                    HasParameter=hasParam
                };
                SecurityResource = rec;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            this.ParentForm.Close();
        }

        private void iTransToolBar1_Close_1(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
