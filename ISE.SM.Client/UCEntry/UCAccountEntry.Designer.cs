namespace ISE.SM.Client.UCEntry
{
    partial class UCAccountEntry
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
            this.radCheckedDropDownListApp = new Telerik.WinControls.UI.RadCheckedDropDownList();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnOk = new Janus.Windows.EditControls.UIButton();
            this.chkEnable = new ISE.UILibrary.ICheckBox();
            this.txtPassword = new ISE.UILibrary.ITextBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.txtUserName = new ISE.UILibrary.ITextBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.iGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownListApp)).BeginInit();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.radCheckedDropDownListApp);
            this.iGroupBox1.Controls.Add(this.btnCancel);
            this.iGroupBox1.Controls.Add(this.btnOk);
            this.iGroupBox1.Controls.Add(this.chkEnable);
            this.iGroupBox1.Controls.Add(this.txtPassword);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.txtUserName);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(399, 306);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "حساب کاربری";
            // 
            // radCheckedDropDownListApp
            // 
            this.radCheckedDropDownListApp.Location = new System.Drawing.Point(51, 191);
            this.radCheckedDropDownListApp.Name = "radCheckedDropDownListApp";
            this.radCheckedDropDownListApp.Size = new System.Drawing.Size(306, 20);
            this.radCheckedDropDownListApp.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(187, 261);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "لغو";
            this.btnCancel.VisualStyleManager = this.visualStyleManager1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // visualStyleManager1
            // 
            janusColorScheme1.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme1.Name = "Scheme0";
            janusColorScheme1.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme1.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme1);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(282, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "تایید";
            this.btnOk.VisualStyleManager = this.visualStyleManager1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(284, 136);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(73, 17);
            this.chkEnable.TabIndex = 11;
            this.chkEnable.Text = "فعال باشد";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(51, 78);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(211, 21);
            this.txtPassword.TabIndex = 10;
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(312, 81);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(45, 13);
            this.iLabel2.TabIndex = 9;
            this.iLabel2.Text = "رمز عبور";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(51, 28);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(211, 21);
            this.txtUserName.TabIndex = 8;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(304, 31);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(53, 13);
            this.iLabel1.TabIndex = 7;
            this.iLabel1.Text = "نام کاربری";
            // 
            // UCAccountEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCAccountEntry";
            this.Size = new System.Drawing.Size(402, 316);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckedDropDownListApp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnOk;
        private UILibrary.ICheckBox chkEnable;
        private UILibrary.ITextBox txtPassword;
        private UILibrary.ILabel iLabel2;
        private UILibrary.ITextBox txtUserName;
        private UILibrary.ILabel iLabel1;
        private Telerik.WinControls.UI.RadCheckedDropDownList radCheckedDropDownListApp;
    }
}
