namespace ISE.SM.Client.UCEntry
{
    partial class ChangePasswordEntry
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
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnOk = new Janus.Windows.EditControls.UIButton();
            this.txtNewPassRep = new ISE.UILibrary.ITextBox();
            this.iLabel3 = new ISE.UILibrary.ILabel();
            this.txtNewPass = new ISE.UILibrary.ITextBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.txtPrevPass = new ISE.UILibrary.ITextBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
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
            this.iGroupBox1.Controls.Add(this.txtNewPassRep);
            this.iGroupBox1.Controls.Add(this.iLabel3);
            this.iGroupBox1.Controls.Add(this.txtNewPass);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.txtPrevPass);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(0, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(352, 276);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "تغییر رمز عبور";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(157, 193);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "انصراف";
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
            this.btnOk.Location = new System.Drawing.Point(251, 193);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "تایید";
            this.btnOk.VisualStyleManager = this.visualStyleManager1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtNewPassRep
            // 
            this.txtNewPassRep.Location = new System.Drawing.Point(48, 141);
            this.txtNewPassRep.Name = "txtNewPassRep";
            this.txtNewPassRep.Size = new System.Drawing.Size(184, 21);
            this.txtNewPassRep.TabIndex = 5;
            // 
            // iLabel3
            // 
            this.iLabel3.AutoSize = true;
            this.iLabel3.Location = new System.Drawing.Point(238, 144);
            this.iLabel3.Name = "iLabel3";
            this.iLabel3.Size = new System.Drawing.Size(91, 13);
            this.iLabel3.TabIndex = 4;
            this.iLabel3.Text = "تکرار رمزعبور جدید";
            // 
            // txtNewPass
            // 
            this.txtNewPass.Location = new System.Drawing.Point(48, 85);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(184, 21);
            this.txtNewPass.TabIndex = 3;
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(262, 88);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(67, 13);
            this.iLabel2.TabIndex = 2;
            this.iLabel2.Text = "رمزعبور جدید";
            // 
            // txtPrevPass
            // 
            this.txtPrevPass.Location = new System.Drawing.Point(48, 38);
            this.txtPrevPass.Name = "txtPrevPass";
            this.txtPrevPass.Size = new System.Drawing.Size(184, 21);
            this.txtPrevPass.TabIndex = 1;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(260, 46);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(69, 13);
            this.iLabel1.TabIndex = 0;
            this.iLabel1.Text = "رمزعبور قبلی";
            // 
            // ChangePasswordEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "ChangePasswordEntry";
            this.Size = new System.Drawing.Size(352, 282);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.ITextBox txtNewPassRep;
        private UILibrary.ILabel iLabel3;
        private UILibrary.ITextBox txtNewPass;
        private UILibrary.ILabel iLabel2;
        private UILibrary.ITextBox txtPrevPass;
        private UILibrary.ILabel iLabel1;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnOk;
    }
}
