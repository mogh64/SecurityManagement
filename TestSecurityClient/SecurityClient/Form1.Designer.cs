namespace SecurityClient
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadMenu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelOp = new System.Windows.Forms.FlowLayoutPanel();
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdUInfo = new System.Windows.Forms.RadioButton();
            this.rdAccessToken = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(269, 145);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 33);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(299, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "user name";
            // 
            // txtUname
            // 
            this.txtUname.Location = new System.Drawing.Point(51, 36);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(189, 20);
            this.txtUname.TabIndex = 2;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(51, 82);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(189, 20);
            this.txtPass.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "password";
            // 
            // btnLoadMenu
            // 
            this.btnLoadMenu.Enabled = false;
            this.btnLoadMenu.Location = new System.Drawing.Point(154, 145);
            this.btnLoadMenu.Name = "btnLoadMenu";
            this.btnLoadMenu.Size = new System.Drawing.Size(73, 33);
            this.btnLoadMenu.TabIndex = 5;
            this.btnLoadMenu.Text = "Load Menu";
            this.btnLoadMenu.UseVisualStyleBackColor = true;
            this.btnLoadMenu.Click += new System.EventHandler(this.btnLoadMenu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.btnLoadMenu);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUname);
            this.groupBox1.Location = new System.Drawing.Point(452, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 199);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanelOp
            // 
            this.flowLayoutPanelOp.Location = new System.Drawing.Point(452, 228);
            this.flowLayoutPanelOp.Name = "flowLayoutPanelOp";
            this.flowLayoutPanelOp.Size = new System.Drawing.Size(378, 173);
            this.flowLayoutPanelOp.TabIndex = 8;
            // 
            // radTreeView1
            // 
            this.radTreeView1.Location = new System.Drawing.Point(34, 157);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(378, 397);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 9;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.NodeMouseDoubleClick += new Telerik.WinControls.UI.RadTreeView.TreeViewEventHandler(this.radTreeView1_NodeMouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtFname);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtLname);
            this.groupBox2.Location = new System.Drawing.Point(34, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(378, 67);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "person info";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "last name";
            // 
            // txtLname
            // 
            this.txtLname.Location = new System.Drawing.Point(60, 41);
            this.txtLname.Name = "txtLname";
            this.txtLname.ReadOnly = true;
            this.txtLname.Size = new System.Drawing.Size(189, 20);
            this.txtLname.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "first name";
            // 
            // txtFname
            // 
            this.txtFname.Location = new System.Drawing.Point(60, 15);
            this.txtFname.Name = "txtFname";
            this.txtFname.ReadOnly = true;
            this.txtFname.Size = new System.Drawing.Size(189, 20);
            this.txtFname.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdAccessToken);
            this.groupBox3.Controls.Add(this.rdUInfo);
            this.groupBox3.Location = new System.Drawing.Point(34, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(378, 37);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            // 
            // rdUInfo
            // 
            this.rdUInfo.AutoSize = true;
            this.rdUInfo.Checked = true;
            this.rdUInfo.Location = new System.Drawing.Point(261, 14);
            this.rdUInfo.Name = "rdUInfo";
            this.rdUInfo.Size = new System.Drawing.Size(117, 17);
            this.rdUInfo.TabIndex = 0;
            this.rdUInfo.TabStop = true;
            this.rdUInfo.Text = "By User Information";
            this.rdUInfo.UseVisualStyleBackColor = true;
            // 
            // rdAccessToken
            // 
            this.rdAccessToken.AutoSize = true;
            this.rdAccessToken.Location = new System.Drawing.Point(109, 14);
            this.rdAccessToken.Name = "rdAccessToken";
            this.rdAccessToken.Size = new System.Drawing.Size(109, 17);
            this.rdAccessToken.TabIndex = 1;
            this.rdAccessToken.Text = "By Access Token";
            this.rdAccessToken.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 566);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radTreeView1);
            this.Controls.Add(this.flowLayoutPanelOp);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "login form";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadMenu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelOp;
        private Telerik.WinControls.UI.RadTreeView radTreeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdAccessToken;
        private System.Windows.Forms.RadioButton rdUInfo;
    }
}

