namespace ISE.SM.Client.UCEntry
{
    partial class UCSubMenuEntry
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
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.txtTitle = new ISE.UILibrary.IEditBox();
            this.chkEnabled = new ISE.UILibrary.ICheckBox();
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
            this.iGroupBox1.Controls.Add(this.chkEnabled);
            this.iGroupBox1.Controls.Add(this.txtTitle);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(356, 236);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "زیر منو";
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(281, 62);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(33, 13);
            this.iLabel1.TabIndex = 0;
            this.iLabel1.Text = "عنوان";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(53, 54);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(195, 21);
            this.txtTitle.TabIndex = 1;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(238, 111);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(73, 17);
            this.chkEnabled.TabIndex = 2;
            this.chkEnabled.Text = "فعال باشد";
            this.chkEnabled.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(142, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "بستن";
            this.btnCancel.VisualStyleManager = this.visualStyleManager1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(236, 170);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "ذخیره";
            this.btnOk.VisualStyleManager = this.visualStyleManager1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // UCSubMenuEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCSubMenuEntry";
            this.Size = new System.Drawing.Size(356, 239);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.ICheckBox chkEnabled;
        private UILibrary.IEditBox txtTitle;
        private UILibrary.ILabel iLabel1;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnOk;
    }
}
