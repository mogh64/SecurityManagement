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
using ISE.SM.Client.View;
using ISE.ClassLibrary;
using ISE.UILibrary.Lov;
using ISE.Framework.Utility.Utils;

namespace ISE.SM.Client.UCEntry
{
    public partial class UCUserEntry : IUserControl
    {
        UserView view;
        TransMode mode;
        UserDto user;
        public UCUserEntry(UserView view)
        {
            mode = TransMode.NewRecord;
            this.view = view;
            InitializeComponent();
            var result = view.LoadCompanies();
            var iseIkco = result.Where(it => it.CompanyId == 1).FirstOrDefault();
            if (iseIkco != null)
            {
                txtCompany.Text = iseIkco.Name;
                txtCompany.Tag = iseIkco;
            }
           
        }
        public UCUserEntry(UserView view, TransMode mode,UserDto user)
        {
            this.mode = mode;
            this.view = view;
            this.user = user;
            InitializeComponent();
            if (mode == TransMode.EditRecord || mode == TransMode.ViewRecord)
            {
                txtFName.Text = user.FirstName;
                txtLName.Text = user.LastName;
                txtNationalCode.Text = user.NationalNo;
                txtPersonelCode.Text = user.PersonelCode;
                chkEnabled.Checked = user.IsLocked;
                chkIsReal.Checked = user.IsReal;
                var result = view.LoadCompanies();
                var company = result.Where(it => it.NationalNo == user.NationalNo).FirstOrDefault();
                if (company != null)
                {
                    txtCompany.Text = company.Name;
                    txtCompany.Tag = company;
                }
            }
        }
        private void iTransToolBar1_SaveRecord(object sender, EventArgs e)
        {
            Save();
            this.ParentForm.Close();
        }
        private void Save()
        {
            if (mode == TransMode.NewRecord)
            {
                CompanyDto company = (CompanyDto) txtCompany.Tag;
                UserDto newUser = new UserDto() {
                    FirstName = txtFName.Text,
                    LastName = txtLName.Text,
                    NationalNo = txtNationalCode.Text,
                    PersonelCode = txtPersonelCode.Text,
                    IsLocked = chkEnabled.Checked,
                    IsReal= chkIsReal.Checked
                };
                if (company != null)
                {
                    newUser.NationalNo = company.NationalNo;
                }
                view.AddUser(newUser);
            }
            else if (mode == TransMode.EditRecord)
            {
                if (user != null)
                {
                    user.FirstName = txtFName.Text;
                    user.LastName = txtLName.Text;
                    user.NationalNo = txtNationalCode.Text;
                    user.PersonelCode = txtPersonelCode.Text;
                    user.IsLocked = chkEnabled.Checked;
                    user.IsReal = chkIsReal.Checked;
                    CompanyDto company = (CompanyDto)txtCompany.Tag;
                    if (company != null && company.NationalNo != user.NationalNo)
                    {
                        user.NationalNo = company.NationalNo;
                    }
                    view.UpdateUser(user);
                }
            }
        }
        private void iTransToolBar1_SaveAndNewRecord(object sender, EventArgs e)
        {
            Save();
            MakeEmptyForm();
        }

        private void iTransToolBar1_Close(object sender, EventArgs e)
        {

            this.ParentForm.Close();
        }
        private void MakeEmptyForm()
        {
            txtFName.Text = string.Empty;
            txtLName.Text = string.Empty;
            txtNationalCode.Text = string.Empty;
            txtPersonelCode.Text = string.Empty;
            chkEnabled.Checked = true;
            chkIsReal.Checked = true;
            mode = TransMode.NewRecord;
        }

        private void btnCompany_Click(object sender, EventArgs e)
        {
            var result = view.LoadCompanies();
            var tbl = DataTableHelper.ConvertToDatatable<CompanyDto>(result);
            ILov lovActionOrder;
            LovFields lfActionOrder;
            lfActionOrder = new LovFields();
            lfActionOrder.AddItem(AssemblyReflector.GetMemberName((CompanyDto m) => m.Name), "نام شرکت", 200, true);
            lfActionOrder.AddItem(AssemblyReflector.GetMemberName((CompanyDto m) => m.NationalNo), "کد شناسایی ملی", 100, true);

            lovActionOrder = new ILov(this.btnCompany, "ليست شرکت ها", tbl, lfActionOrder);
            var row = lovActionOrder.ShowDialog() as DataRow;
            if (row != null)
            {
                var companId = row.Field<int>(AssemblyReflector.GetMemberName((CompanyDto m) => m.CompanyId));
                var selectedCompany = result.Where(it => it.CompanyId == companId).FirstOrDefault();
                if(selectedCompany!=null){
                    txtCompany.Text = selectedCompany.Name;
                    txtCompany.Tag = selectedCompany;
                }
               
               
            }
        }
    }
}
