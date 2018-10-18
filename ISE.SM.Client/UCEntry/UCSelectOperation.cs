using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.SM.Client.View;
using ISE.SM.Common.DTO;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCSelectOperation : IUserControl
    {
        OperationView view = new OperationView();
        BindingSource operationBs = new BindingSource();
        public DialogResult DialogResult { get; set; }
        public List<OperationDto> SelectedOperations { get; set; }
        public UCSelectOperation()
        {
            InitializeComponent();
            LoadOperations();
            SelectedOperations = new List<OperationDto>();
            DialogResult = System.Windows.Forms.DialogResult.None;
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEX1);
        }

        private void LoadOperations()
        {
           
          operationBs.DataSource = view.LoadOperations(false);
          this.iGridEX1.DataSource = operationBs;
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.iGridEX1.HasCheckedRows)
            {
                foreach (var item in this.iGridEX1.GetCheckedRows())
                {
                    SelectedOperations.Add((OperationDto)item.DataRow);
                }
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
             
            this.ParentForm.Close();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            UCOperationEntry entry = new UCOperationEntry();
            entry.NoDefault = true;
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "عملیات", FormBorderStyle.FixedDialog);
            if (entry.DialogResult != DialogResult.OK)
                return;
            if (view.Insert(entry.OperationDto))
                ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
        }
    }
}
