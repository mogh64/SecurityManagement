namespace ISE.SM.Client.UCEntry
{
    partial class UCSelectOperation
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
            Janus.Windows.GridEX.GridEXLayout iGridEX1_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCSelectOperation));
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.iGridEX1 = new ISE.UILibrary.IGridEX();
            this.btnCancel = new Janus.Windows.EditControls.UIButton();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.btnOk = new Janus.Windows.EditControls.UIButton();
            this.uiButton1 = new Janus.Windows.EditControls.UIButton();
            this.iGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iGridEX1)).BeginInit();
            this.SuspendLayout();
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.uiButton1);
            this.iGroupBox1.Controls.Add(this.iGridEX1);
            this.iGroupBox1.Controls.Add(this.btnCancel);
            this.iGroupBox1.Controls.Add(this.btnOk);
            this.iGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(621, 534);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "انتخاب عملیات";
            // 
            // iGridEX1
            // 
            this.iGridEX1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            iGridEX1_DesignTimeLayout.LayoutString = resources.GetString("iGridEX1_DesignTimeLayout.LayoutString");
            this.iGridEX1.DesignTimeLayout = iGridEX1_DesignTimeLayout;
            this.iGridEX1.Location = new System.Drawing.Point(6, 45);
            this.iGridEX1.Name = "iGridEX1";
            this.iGridEX1.Size = new System.Drawing.Size(615, 457);
            this.iGridEX1.TabIndex = 18;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(442, 505);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "بستن";
            this.btnCancel.VisualStyleManager = this.visualStyleManager1;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // visualStyleManager1
            // 
            janusColorScheme2.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme2.Name = "Scheme0";
            janusColorScheme2.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme2.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme2);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(537, 505);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 26);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "تایید انتخاب";
            this.btnOk.VisualStyleManager = this.visualStyleManager1;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // uiButton1
            // 
            this.uiButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.uiButton1.Location = new System.Drawing.Point(512, 17);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(109, 26);
            this.uiButton1.TabIndex = 19;
            this.uiButton1.Text = "تعریف عملیات جدید";
            this.uiButton1.VisualStyleManager = this.visualStyleManager1;
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // UCSelectOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCSelectOperation";
            this.Size = new System.Drawing.Size(627, 540);
            this.iGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iGridEX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.IGroupBox iGroupBox1;
        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private Janus.Windows.EditControls.UIButton btnCancel;
        private Janus.Windows.EditControls.UIButton btnOk;
        private UILibrary.IGridEX iGridEX1;
        private Janus.Windows.EditControls.UIButton uiButton1;
    }
}
