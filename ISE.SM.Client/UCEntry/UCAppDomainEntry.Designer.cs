namespace ISE.SM.Client.UCEntry
{
    partial class UCAppDomainEntry
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
            Janus.Windows.Common.JanusColorScheme janusColorScheme3 = new Janus.Windows.Common.JanusColorScheme();
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.cmbLoginType = new ISE.UILibrary.IComboBox();
            this.chkEnable = new ISE.UILibrary.ICheckBox();
            this.chkLock = new ISE.UILibrary.ICheckBox();
            this.txtTitle = new ISE.UILibrary.IEditBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.btnOk = new Janus.Windows.EditControls.UIButton();
            this.iGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.btnCancel);
            this.iGroupBox1.Controls.Add(this.btnOk);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.cmbLoginType);
            this.iGroupBox1.Controls.Add(this.chkEnable);
            this.iGroupBox1.Controls.Add(this.chkLock);
            this.iGroupBox1.Controls.Add(this.txtTitle);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(0, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(366, 311);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "حوزه دامنه";
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(279, 103);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(49, 13);
            this.iLabel2.TabIndex = 5;
            this.iLabel2.Text = "نوع لاگین";
            // 
            // cmbLoginType
            // 
            this.cmbLoginType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoginType.FormattingEnabled = true;
            this.cmbLoginType.Location = new System.Drawing.Point(55, 95);
            this.cmbLoginType.Name = "cmbLoginType";
            this.cmbLoginType.Size = new System.Drawing.Size(222, 21);
            this.cmbLoginType.TabIndex = 4;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(240, 182);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(88, 17);
            this.chkEnable.TabIndex = 3;
            this.chkEnable.Text = "غیرفعال کردن";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkLock
            // 
            this.chkLock.AutoSize = true;
            this.chkLock.Location = new System.Drawing.Point(258, 148);
            this.chkLock.Name = "chkLock";
            this.chkLock.Size = new System.Drawing.Size(70, 17);
            this.chkLock.TabIndex = 2;
            this.chkLock.Text = "قفل کردن";
            this.chkLock.UseVisualStyleBackColor = true;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(55, 53);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(222, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(295, 57);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(33, 13);
            this.iLabel1.TabIndex = 0;
            this.iLabel1.Text = "عنوان";
            // 
            // visualStyleManager1
            // 
            janusColorScheme3.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme3.Name = "Scheme0";
            janusColorScheme3.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme3.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme3);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(155, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "بستن";
            this.btnCancel.VisualStyleManager = this.visualStyleManager1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(250, 251);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 14;
            this.btnOk.Text = "ذخیره";
            this.btnOk.VisualStyleManager = this.visualStyleManager1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UCAppDomainEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCAppDomainEntry";
            this.Size = new System.Drawing.Size(366, 317);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.IEditBox txtTitle;
        private UILibrary.ILabel iLabel1;
        private UILibrary.ILabel iLabel2;
        private UILibrary.IComboBox cmbLoginType;
        private UILibrary.ICheckBox chkEnable;
        private UILibrary.ICheckBox chkLock;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnOk;
    }
}
