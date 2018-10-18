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
using ISE.SM.Client.UCEntry;
using ISE.SM.Common.DTO;

namespace ISE.SM.Client.UC
{
    public partial class UCOperation : IUserControl
    {
        OperationView view = new OperationView();
        BindingSource operationBs = new BindingSource();
        public UCOperation()
        {
            InitializeComponent();
            ISE.UILibrary.Utils.GridEXUtils.SetingGrid(this.iGridEX1);
            Load();
        }
        private void Load()
        {
            var operations = view.LoadOperations();
            if (operations != null && operations.Count > 0)
            {
                operationBs.DataSource = operations;
                this.iGridEX1.DataSource = operationBs;
            }
            
        }
        private void iGridToolBar1_NewRecord(object sender, EventArgs e)
        {
            UCOperationEntry entry = new UCOperationEntry();
            ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "عملیات", FormBorderStyle.FixedDialog);
            if (entry.DialogResult != DialogResult.OK)
                return;
            if (view.Insert(entry.OperationDto))
                ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Insert);
        }

        private void iGridToolBar1_EditRecord(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                var operation = (OperationDto)this.iGridEX1.CurrentRow.DataRow;
                UCOperationEntry entry = new UCOperationEntry(ClassLibrary.TransMode.EditRecord, operation);
                ISE.UILibrary.Utils.UIUtils.SetFrmTrans(entry, "عملیات", FormBorderStyle.FixedDialog);
                if (entry.DialogResult != DialogResult.OK)
                    return;
                if (view.Update(entry.OperationDto))
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage(ISE.Framework.Client.Win.Viewer.OperationType.Update);
            }
           
        }

        private void iGridToolBar1_DeleteRecord(object sender, EventArgs e)
        {
            if (this.iGridEX1.CurrentRow != null)
            {
                var operation = (OperationDto)this.iGridEX1.CurrentRow.DataRow;
                if (ISE.Framework.Client.Win.Viewer.MessageViewer.ShowDeleteAlert() != DialogResult.OK)
                {
                    return;
                }
                if (view.Remove(operation))
                {
                    ISE.Framework.Client.Win.Viewer.MessageViewer.ShowMessage("حذف رکورد انجام شد!");
                }
            }
          
        }

        private void iGridToolBar1_RefreshData(object sender, EventArgs e)
        {
            Load();
        }

        private void iGridToolBar1_Close(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }
    }
}
