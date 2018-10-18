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
    public partial class UCOperationEntry : IUserControl
    {
        public UCOperationEntry()
        {
            NoDefault = false;
            mode = TransMode.NewRecord;
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
           
        }
        public bool NoDefault { get; set; }
        TransMode mode;
        public OperationDto OperationDto { get; set; }
        public DialogResult DialogResult { get; set; }
        public UCOperationEntry(TransMode mode,OperationDto operation)
        {
            this.mode = mode;
            this.OperationDto = operation;
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.None;
            if (mode == TransMode.EditRecord || mode == TransMode.ViewRecord)
            {
                txtDescription.Text = operation.Description;
                txtDisplayName.Text = operation.DisplayName;
                txtName.Text = operation.OperationName;
                chkIsDefault.Checked = operation.IsDefaultBool;
            }
        }
        private void iTransToolBar1_SaveRecord(object sender, EventArgs e)
        {
            if (mode == TransMode.EditRecord)
            {
                OperationDto.Description = txtDescription.Text;
                OperationDto.DisplayName = txtDisplayName.Text;
                OperationDto.OperationName = txtName.Text;
                OperationDto.IsDefaultBool = chkIsDefault.Checked;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (mode == TransMode.NewRecord)
            {
                this.OperationDto = new OperationDto()
                {
                    Description = txtDescription.Text,
                    DisplayName = txtDisplayName.Text,
                    OperationName = txtName.Text,
                    IsDefaultBool = chkIsDefault.Checked
                };
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            txtName.ParentForm.Close();
        }           

        private void iTransToolBar1_SaveAndNewRecord(object sender, EventArgs e)
        {

        }

        private void iTransToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void UCOperationEntry_Load(object sender, EventArgs e)
        {
            if (NoDefault)
            {
                chkIsDefault.Checked = false;
                chkIsDefault.Enabled = false;
            }
        }
    }
}
