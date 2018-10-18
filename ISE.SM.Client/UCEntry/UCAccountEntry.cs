using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ISE.UILibrary;
using ISE.SM.Common.DTO;
using ISE.ClassLibrary;
using ISE.SM.Client.View;
using Telerik.WinControls.UI;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCAccountEntry : IUserControl
    {
        TransMode tmode;
        ResourceView resView = new ResourceView();
        public UCAccountEntry()
        {
            tmode = TransMode.NewRecord;
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.None;
            var appDomains = resView.LoadApplicationDomains();
            foreach (var item in appDomains)
            {
              
                RadCheckedListDataItem element = new Telerik.WinControls.UI.RadCheckedListDataItem();
                
                element.Value = item;

                element.Text = item.Title;
                radCheckedDropDownListApp.CheckedDropDownListElement.Items.Add(element);
            }
        }
        public UCAccountEntry(TransMode tmode,AccountDto account)
        {
            InitializeComponent();
            DialogResult = System.Windows.Forms.DialogResult.None;
            this.tmode = tmode;
            if (tmode == TransMode.EditRecord || tmode == TransMode.ViewRecord)
            {
                if(account!=null){
                    txtUserName.Text = account.Username;
                    chkEnable.Checked = account.IsEnabled;                   
                }
                txtPassword.Enabled = false;
                Account = account;
                radCheckedDropDownListApp.Enabled = false;
            }
            var appDomains = resView.LoadApplicationDomains();
            foreach (var item in appDomains)
            {
                bool hasAccount = account.ApplicationDomainDtoList.Exists(it => it.ApplicationDomainId == item.ApplicationDomainId);
                RadCheckedListDataItem element = new Telerik.WinControls.UI.RadCheckedListDataItem();
                if(hasAccount)
                    element.Checked = true;
                else
                    element.Checked = false;
                element.Value = item;
               
                element.Text = item.Title;
                radCheckedDropDownListApp.CheckedDropDownListElement.Items.Add(element);
            }
            
        }
        public AccountDto Account { get; set; }
        public DialogResult DialogResult { get; set; }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tmode == TransMode.NewRecord)
            {
                AccountDto account = new AccountDto()
                {
                    Password = txtPassword.Text,
                    Username = txtUserName.Text
                };
                if (chkEnable.Checked)
                    account.Enabled = 1;
                else
                    account.Enabled = 0;
                foreach (var item in radCheckedDropDownListApp.CheckedItems)
                {
                    var app = (ApplicationDomainDto)item.Value;
                    if (app != null)
                    {

                        account.ApplicationDomainDtoList.Add(app);
                       
                    }
                }
                Account = account;
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else if (tmode == TransMode.EditRecord)
            {
                Account.Username = txtUserName.Text;
                if (chkEnable.Checked)
                    Account.Enabled = 1;
                else
                    Account.Enabled = 0;
               
                SetAppDomains();
                DialogResult = System.Windows.Forms.DialogResult.OK;

            }
            
            this.ParentForm.Close();
        }

        private void SetAppDomains()
        {
            if (Account != null)
            {
                foreach (var item in Account.ApplicationDomainDtoList)
	            {
                    item.State = Framework.Common.CommonBase.DtoObjectState.Deleted;
	            }
                foreach (var item in radCheckedDropDownListApp.CheckedItems)
                {
                    var app = (ApplicationDomainDto)item.Value;
                    if (app != null)
                    {
                        var accApp = Account.ApplicationDomainDtoList.FirstOrDefault(it => it.ApplicationDomainId == app.ApplicationDomainId);
                        if (accApp!=null)
                        {
                            accApp.State = Framework.Common.CommonBase.DtoObjectState.Ignore;
                        }
                        else
                        {
                            app.State = Framework.Common.CommonBase.DtoObjectState.Inserted;
                            Account.ApplicationDomainDtoList.Add(app);
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            DialogResult = System.Windows.Forms.DialogResult.None;
            this.ParentForm.Close();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {

        }
    }
}
