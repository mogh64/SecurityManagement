namespace ISE.SM.Client.UCEntry
{
    partial class UCGroupEntry
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
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.chkEnabled = new ISE.UILibrary.ICheckBox();
            this.iTransToolBar1 = new ISE.UILibrary.ITransToolBar();
            this.iLabel3 = new ISE.UILibrary.ILabel();
            this.cmbDomain = new ISE.UILibrary.IComboBox();
            this.txtDisplayName = new ISE.UILibrary.ITextBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.txtGroupName = new ISE.UILibrary.ITextBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.iGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.chkEnabled);
            this.iGroupBox1.Controls.Add(this.iTransToolBar1);
            this.iGroupBox1.Controls.Add(this.iLabel3);
            this.iGroupBox1.Controls.Add(this.cmbDomain);
            this.iGroupBox1.Controls.Add(this.txtDisplayName);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.txtGroupName);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(0, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(398, 351);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "گروه";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(289, 214);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(84, 17);
            this.chkEnabled.TabIndex = 7;
            this.chkEnabled.Text = "وضعیت فعال";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // iTransToolBar1
            // 
            this.iTransToolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iTransToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.iTransToolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.iTransToolBar1.Location = new System.Drawing.Point(118, 260);
            this.iTransToolBar1.Name = "iTransToolBar1";
            this.iTransToolBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iTransToolBar1.Size = new System.Drawing.Size(259, 27);
            this.iTransToolBar1.TabIndex = 6;
            this.iTransToolBar1.SaveRecord += new System.EventHandler(this.iTransToolBar1_SaveRecord);
            this.iTransToolBar1.Close += new System.EventHandler(this.iTransToolBar1_Close);
            // 
            // iLabel3
            // 
            this.iLabel3.AutoSize = true;
            this.iLabel3.Location = new System.Drawing.Point(329, 160);
            this.iLabel3.Name = "iLabel3";
            this.iLabel3.Size = new System.Drawing.Size(47, 13);
            this.iLabel3.TabIndex = 5;
            this.iLabel3.Text = "نام دامنه";
            // 
            // cmbDomain
            // 
            this.cmbDomain.FormattingEnabled = true;
            this.cmbDomain.Location = new System.Drawing.Point(79, 152);
            this.cmbDomain.Name = "cmbDomain";
            this.cmbDomain.Size = new System.Drawing.Size(210, 21);
            this.cmbDomain.TabIndex = 4;
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(79, 104);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(210, 21);
            this.txtDisplayName.TabIndex = 3;
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(295, 107);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(85, 13);
            this.iLabel2.TabIndex = 2;
            this.iLabel2.Text = "نام نمایشی گروه";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(79, 62);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(210, 21);
            this.txtGroupName.TabIndex = 1;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(333, 62);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(43, 13);
            this.iLabel1.TabIndex = 0;
            this.iLabel1.Text = "نام گروه";
            // 
            // UCGroupEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCGroupEntry";
            this.Size = new System.Drawing.Size(398, 357);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.ITextBox txtDisplayName;
        private UILibrary.ILabel iLabel2;
        private UILibrary.ITextBox txtGroupName;
        private UILibrary.ILabel iLabel1;
        private UILibrary.ILabel iLabel3;
        private UILibrary.IComboBox cmbDomain;
        private UILibrary.ITransToolBar iTransToolBar1;
        private UILibrary.ICheckBox chkEnabled;
    }
}
