namespace ISE.SM.Client.UCEntry
{
    partial class UCOperationEntry
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
            this.iTransToolBar1 = new ISE.UILibrary.ITransToolBar();
            this.chkIsDefault = new ISE.UILibrary.ICheckBox();
            this.txtDescription = new ISE.UILibrary.IEditBox();
            this.iLabel3 = new ISE.UILibrary.ILabel();
            this.txtDisplayName = new ISE.UILibrary.IEditBox();
            this.iLabel2 = new ISE.UILibrary.ILabel();
            this.txtName = new ISE.UILibrary.IEditBox();
            this.iLabel1 = new ISE.UILibrary.ILabel();
            this.iGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.iTransToolBar1);
            this.iGroupBox1.Controls.Add(this.chkIsDefault);
            this.iGroupBox1.Controls.Add(this.txtDescription);
            this.iGroupBox1.Controls.Add(this.iLabel3);
            this.iGroupBox1.Controls.Add(this.txtDisplayName);
            this.iGroupBox1.Controls.Add(this.iLabel2);
            this.iGroupBox1.Controls.Add(this.txtName);
            this.iGroupBox1.Controls.Add(this.iLabel1);
            this.iGroupBox1.Location = new System.Drawing.Point(3, 0);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(381, 360);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "تعریف عملیات";
            // 
            // iTransToolBar1
            // 
            this.iTransToolBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.iTransToolBar1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.iTransToolBar1.Location = new System.Drawing.Point(68, 283);
            this.iTransToolBar1.Name = "iTransToolBar1";
            this.iTransToolBar1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iTransToolBar1.Size = new System.Drawing.Size(259, 27);
            this.iTransToolBar1.TabIndex = 7;
            this.iTransToolBar1.SaveRecord += new System.EventHandler(this.iTransToolBar1_SaveRecord);
            this.iTransToolBar1.SaveAndNewRecord += new System.EventHandler(this.iTransToolBar1_SaveAndNewRecord);
            this.iTransToolBar1.Close += new System.EventHandler(this.iTransToolBar1_Close);
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Location = new System.Drawing.Point(217, 216);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(110, 17);
            this.chkIsDefault.TabIndex = 6;
            this.chkIsDefault.Text = "عملیات پیش فرض";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(33, 161);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(219, 21);
            this.txtDescription.TabIndex = 5;
            // 
            // iLabel3
            // 
            this.iLabel3.AutoSize = true;
            this.iLabel3.Location = new System.Drawing.Point(280, 169);
            this.iLabel3.Name = "iLabel3";
            this.iLabel3.Size = new System.Drawing.Size(47, 13);
            this.iLabel3.TabIndex = 4;
            this.iLabel3.Text = "توضیحات";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Location = new System.Drawing.Point(33, 117);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(219, 21);
            this.txtDisplayName.TabIndex = 3;
            // 
            // iLabel2
            // 
            this.iLabel2.AutoSize = true;
            this.iLabel2.Location = new System.Drawing.Point(265, 125);
            this.iLabel2.Name = "iLabel2";
            this.iLabel2.Size = new System.Drawing.Size(62, 13);
            this.iLabel2.TabIndex = 2;
            this.iLabel2.Text = "نام نمایشی";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(33, 71);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(219, 21);
            this.txtName.TabIndex = 1;
            // 
            // iLabel1
            // 
            this.iLabel1.AutoSize = true;
            this.iLabel1.Location = new System.Drawing.Point(270, 79);
            this.iLabel1.Name = "iLabel1";
            this.iLabel1.Size = new System.Drawing.Size(57, 13);
            this.iLabel1.TabIndex = 0;
            this.iLabel1.Text = "نام عملیات";
            // 
            // UCOperationEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCOperationEntry";
            this.Size = new System.Drawing.Size(384, 363);
            this.Load += new System.EventHandler(this.UCOperationEntry_Load);
            this.iGroupBox1.ResumeLayout(false);
            this.iGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private UILibrary.ICheckBox chkIsDefault;
        private UILibrary.IEditBox txtDescription;
        private UILibrary.ILabel iLabel3;
        private UILibrary.IEditBox txtDisplayName;
        private UILibrary.ILabel iLabel2;
        private UILibrary.IEditBox txtName;
        private UILibrary.ILabel iLabel1;
        private UILibrary.ITransToolBar iTransToolBar1;
    }
}
