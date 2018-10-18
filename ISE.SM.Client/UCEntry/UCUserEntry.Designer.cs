namespace ISE.SM.Client.UCEntry
{
    partial class UCUserEntry
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Janus.Windows.Common.JanusColorScheme janusColorScheme1 = new Janus.Windows.Common.JanusColorScheme();
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.txtCompany = new ISE.UILibrary.IEditBox();
            this.btnCompany = new Janus.Windows.EditControls.UIButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.iTransToolBar1 = new ISE.UILibrary.ITransToolBar();
            this.chkEnabled = new ISE.UILibrary.ICheckBox();
            this.txtPersonelCode = new ISE.UILibrary.IEditBox();
            this.iLabel4 = new ISE.UILibrary.ILabel();
            this.txtNationalCode = new ISE.UILibrary.IEditBox();
            this.iLabel3 = new ISE.UILibrary.ILabel();
            this.txtLName = new ISE.UILibrary.IEditBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.txtFName = new ISE.UILibrary.IEditBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.chkIsReal = new ISE.UILibrary.ICheckBox();
            this.iGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.chkIsReal);
            this.iGroupBox1.Controls.Add(this.txtCompany);
            this.iGroupBox1.Controls.Add(this.btnCompany);
            this.iGroupBox1.Controls.Add(this.iTransToolBar1);
            this.iGroupBox1.Controls.Add(this.chkEnabled);
            this.iGroupBox1.Controls.Add(this.txtPersonelCode);
            this.iGroupBox1.Controls.Add(this.iLabel4);
            this.iGroupBox1.Controls.Add(this.txtNationalCode);
            this.iGroupBox1.Controls.Add(this.iLabel3);
            this.iGroupBox1.Controls.Add(this.txtLName);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.txtFName);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(0, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(482, 419);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "کاربران";
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(100, 48);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(249, 21);
            this.txtCompany.TabIndex = 22;
            // 
            // btnCompany
            // 
            this.btnCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompany.Location = new System.Drawing.Point(361, 42);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Size = new System.Drawing.Size(103, 28);
            this.btnCompany.TabIndex = 21;
            this.btnCompany.Text = "انتخاب شرکت ...";
            this.btnCompany.VisualStyleManager = this.visualStyleManager1;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // iTransToolBar1
            // 
            this.iTransToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.iTransToolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.iTransToolBar1.Location = new System.Drawing.Point(90, 347);
            this.iTransToolBar1.Name = "iTransToolBar1";
            this.iTransToolBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iTransToolBar1.Size = new System.Drawing.Size(259, 27);
            this.iTransToolBar1.TabIndex = 20;
            this.iTransToolBar1.SaveRecord += new System.EventHandler(this.iTransToolBar1_SaveRecord);
            this.iTransToolBar1.SaveAndNewRecord += new System.EventHandler(this.iTransToolBar1_SaveAndNewRecord);
            this.iTransToolBar1.Close += new System.EventHandler(this.iTransToolBar1_Close);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(278, 288);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(71, 17);
            this.chkEnabled.TabIndex = 18;
            this.chkEnabled.Text = "قفل باشد";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtPersonelCode
            // 
            this.txtPersonelCode.Location = new System.Drawing.Point(100, 222);
            this.txtPersonelCode.Name = "txtPersonelCode";
            this.txtPersonelCode.Size = new System.Drawing.Size(249, 21);
            this.txtPersonelCode.TabIndex = 17;
            // 
            // iLabel4
            // 
            this.iLabel4.AutoSize = true;
            this.iLabel4.Location = new System.Drawing.Point(386, 226);
            this.iLabel4.Name = "iLabel4";
            this.iLabel4.Size = new System.Drawing.Size(78, 13);
            this.iLabel4.TabIndex = 16;
            this.iLabel4.Text = "شماره پرسنلی";
            // 
            // txtNationalCode
            // 
            this.txtNationalCode.Location = new System.Drawing.Point(100, 177);
            this.txtNationalCode.Name = "txtNationalCode";
            this.txtNationalCode.Size = new System.Drawing.Size(249, 21);
            this.txtNationalCode.TabIndex = 15;
            // 
            // iLabel3
            // 
            this.iLabel3.AutoSize = true;
            this.iLabel3.Location = new System.Drawing.Point(422, 181);
            this.iLabel3.Name = "iLabel3";
            this.iLabel3.Size = new System.Drawing.Size(42, 13);
            this.iLabel3.TabIndex = 14;
            this.iLabel3.Text = "کد ملی";
            // 
            // txtLName
            // 
            this.txtLName.Location = new System.Drawing.Point(100, 138);
            this.txtLName.Name = "txtLName";
            this.txtLName.Size = new System.Drawing.Size(249, 21);
            this.txtLName.TabIndex = 13;
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(399, 142);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(65, 13);
            this.iLabel2.TabIndex = 12;
            this.iLabel2.Text = "نام خانوادگی";
            // 
            // txtFName
            // 
            this.txtFName.Location = new System.Drawing.Point(100, 99);
            this.txtFName.Name = "txtFName";
            this.txtFName.Size = new System.Drawing.Size(249, 21);
            this.txtFName.TabIndex = 11;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(447, 103);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(20, 13);
            this.iLabel1.TabIndex = 10;
            this.iLabel1.Text = "نام";
            // 
            // chkIsReal
            // 
            this.chkIsReal.AutoSize = true;
            this.chkIsReal.Checked = true;
            this.chkIsReal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsReal.Location = new System.Drawing.Point(255, 311);
            this.chkIsReal.Name = "chkIsReal";
            this.chkIsReal.Size = new System.Drawing.Size(94, 17);
            this.chkIsReal.TabIndex = 23;
            this.chkIsReal.Text = "شخص حقیقی";
            this.chkIsReal.UseVisualStyleBackColor = true;
            // 
            // UCUserEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCUserEntry";
            this.Size = new System.Drawing.Size(485, 425);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.ICheckBox chkEnabled;
        private UILibrary.IEditBox txtPersonelCode;
        private UILibrary.ILabel iLabel4;
        private UILibrary.IEditBox txtNationalCode;
        private UILibrary.ILabel iLabel3;
        private UILibrary.IEditBox txtLName;
        private UILibrary.ILabel iLabel2;
        private UILibrary.IEditBox txtFName;
        private UILibrary.ILabel iLabel1;
        private UILibrary.ITransToolBar iTransToolBar1;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private UILibrary.IEditBox txtCompany;
        private Janus.Windows.EditControls.UIButton btnCompany;
        private UILibrary.ICheckBox chkIsReal;
    }
}
