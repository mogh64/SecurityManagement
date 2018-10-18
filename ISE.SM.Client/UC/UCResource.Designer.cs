namespace ISE.SM.Client.UC
{
    partial class UCResource
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
            Janus.Windows.Common.JanusColorScheme janusColorScheme2 = new Janus.Windows.Common.JanusColorScheme();
            this.visualStyleManager1 = new Janus.Windows.Common.VisualStyleManager(this.components);
            this.iGroupBox1 = new ISE.UILibrary.IGroupBox();
            this.btnExit = new Janus.Windows.EditControls.UIButton();
            this.radTreeViewResource = new Telerik.WinControls.UI.RadTreeView();
            this.appDomainRadContextMenu1 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuItemAddAppDomain = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemEdit = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemDelete = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemAddSubMenu = new Telerik.WinControls.UI.RadMenuItem();
            this.subMenuRadContextMenu2 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuItemAddSubMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemEditMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemDeleteMenuItem = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemAddResourceItem = new Telerik.WinControls.UI.RadMenuItem();
            this.meuItemRadContextMenu3 = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuItemEditResource = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemDeleteResource = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItemAddOperation = new Telerik.WinControls.UI.RadMenuItem();
            this.radContextMenuOperations = new Telerik.WinControls.UI.RadContextMenu(this.components);
            this.radMenuItemDeleteOperation = new Telerik.WinControls.UI.RadMenuItem();
            this.btnRefresh = new Janus.Windows.EditControls.UIButton();
            this.iGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewResource)).BeginInit();
            this.SuspendLayout();
            // 
            // visualStyleManager1
            // 
            janusColorScheme2.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            janusColorScheme2.Name = "Scheme0";
            janusColorScheme2.Office2007CustomColor = System.Drawing.Color.Empty;
            janusColorScheme2.VisualStyle = Janus.Windows.Common.VisualStyle.Office2007;
            this.visualStyleManager1.ColorSchemes.Add(janusColorScheme2);
            // 
            // iGroupBox1
            // 
            this.iGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iGroupBox1.Controls.Add(this.btnRefresh);
            this.iGroupBox1.Controls.Add(this.btnExit);
            this.iGroupBox1.Controls.Add(this.radTreeViewResource);
            this.iGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.iGroupBox1.Name = "iGroupBox1";
            this.iGroupBox1.Size = new System.Drawing.Size(770, 726);
            this.iGroupBox1.TabIndex = 0;
            this.iGroupBox1.TabStop = false;
            this.iGroupBox1.Text = "منابع و عملیات";
            this.iGroupBox1.Enter += new System.EventHandler(this.iGroupBox1_Enter);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.Location = new System.Drawing.Point(6, 682);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 30);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "خروج";
            this.btnExit.VisualStyleManager = this.visualStyleManager1;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // radTreeViewResource
            // 
            this.radTreeViewResource.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTreeViewResource.Location = new System.Drawing.Point(6, 20);
            this.radTreeViewResource.Name = "radTreeViewResource";
            this.radTreeViewResource.Size = new System.Drawing.Size(758, 656);
            this.radTreeViewResource.SpacingBetweenNodes = -1;
            this.radTreeViewResource.TabIndex = 0;
            this.radTreeViewResource.Text = "radTreeView1";
            // 
            // appDomainRadContextMenu1
            // 
            this.appDomainRadContextMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemAddAppDomain,
            this.radMenuItemEdit,
            this.radMenuItemDelete,
            this.radMenuItemAddSubMenu});
            // 
            // radMenuItemAddAppDomain
            // 
            this.radMenuItemAddAppDomain.AccessibleDescription = "AddAppDomain";
            this.radMenuItemAddAppDomain.AccessibleName = "افزودن دامنه";
            this.radMenuItemAddAppDomain.Name = "radMenuItemAddAppDomain";
            this.radMenuItemAddAppDomain.Text = "افزودن دامنه";
            // 
            // radMenuItemEdit
            // 
            this.radMenuItemEdit.AccessibleDescription = "EditApp";
            this.radMenuItemEdit.AccessibleName = "ویرایش دامنه";
            this.radMenuItemEdit.Name = "radMenuItemEdit";
            this.radMenuItemEdit.Text = "ویرایش دامنه";
            // 
            // radMenuItemDelete
            // 
            this.radMenuItemDelete.AccessibleDescription = "DeleteApp";
            this.radMenuItemDelete.AccessibleName = "حذف دامنه";
            this.radMenuItemDelete.Name = "radMenuItemDelete";
            this.radMenuItemDelete.Text = "حذف دامنه";
            // 
            // radMenuItemAddSubMenu
            // 
            this.radMenuItemAddSubMenu.AccessibleDescription = "CreateSubmenu";
            this.radMenuItemAddSubMenu.AccessibleName = "افزودن زیر منو";
            this.radMenuItemAddSubMenu.Name = "radMenuItemAddSubMenu";
            this.radMenuItemAddSubMenu.Text = "افزودن زیر منو";
            // 
            // subMenuRadContextMenu2
            // 
            this.subMenuRadContextMenu2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemAddSubMenuItem,
            this.radMenuItemEditMenuItem,
            this.radMenuItemDeleteMenuItem,
            this.radMenuItemAddResourceItem});
            // 
            // radMenuItemAddSubMenuItem
            // 
            this.radMenuItemAddSubMenuItem.AccessibleDescription = "CreateSubmenu";
            this.radMenuItemAddSubMenuItem.AccessibleName = "افزودن زیرمنو";
            this.radMenuItemAddSubMenuItem.Name = "radMenuItemAddSubMenuItem";
            this.radMenuItemAddSubMenuItem.Text = "افزودن زیرمنو";
            // 
            // radMenuItemEditMenuItem
            // 
            this.radMenuItemEditMenuItem.AccessibleDescription = "EditSubmenu";
            this.radMenuItemEditMenuItem.AccessibleName = "ویرایش";
            this.radMenuItemEditMenuItem.Name = "radMenuItemEditMenuItem";
            this.radMenuItemEditMenuItem.Text = "ویرایش";
            // 
            // radMenuItemDeleteMenuItem
            // 
            this.radMenuItemDeleteMenuItem.AccessibleDescription = "DeleteSubmenu";
            this.radMenuItemDeleteMenuItem.AccessibleName = "حذف";
            this.radMenuItemDeleteMenuItem.Name = "radMenuItemDeleteMenuItem";
            this.radMenuItemDeleteMenuItem.Text = "حذف";
            // 
            // radMenuItemAddResourceItem
            // 
            this.radMenuItemAddResourceItem.AccessibleDescription = "CreateResource";
            this.radMenuItemAddResourceItem.AccessibleName = "افزودن منبع";
            this.radMenuItemAddResourceItem.Name = "radMenuItemAddResourceItem";
            this.radMenuItemAddResourceItem.Text = "افزودن منبع";
            // 
            // meuItemRadContextMenu3
            // 
            this.meuItemRadContextMenu3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemEditResource,
            this.radMenuItemDeleteResource,
            this.radMenuItemAddOperation});
            // 
            // radMenuItemEditResource
            // 
            this.radMenuItemEditResource.AccessibleDescription = "EditResource";
            this.radMenuItemEditResource.AccessibleName = "ویرایش منبع";
            this.radMenuItemEditResource.Name = "radMenuItemEditResource";
            this.radMenuItemEditResource.Text = "ویرایش منبع";
            // 
            // radMenuItemDeleteResource
            // 
            this.radMenuItemDeleteResource.AccessibleDescription = "DeleteResource";
            this.radMenuItemDeleteResource.AccessibleName = "حذف منبع";
            this.radMenuItemDeleteResource.Name = "radMenuItemDeleteResource";
            this.radMenuItemDeleteResource.Text = "حذف منبع";
            // 
            // radMenuItemAddOperation
            // 
            this.radMenuItemAddOperation.AccessibleDescription = "AddOperation";
            this.radMenuItemAddOperation.AccessibleName = "افزودن عملیات";
            this.radMenuItemAddOperation.Name = "radMenuItemAddOperation";
            this.radMenuItemAddOperation.Text = "افزودن عملیات";
            // 
            // radContextMenuOperations
            // 
            this.radContextMenuOperations.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItemDeleteOperation});
            // 
            // radMenuItemDeleteOperation
            // 
            this.radMenuItemDeleteOperation.AccessibleDescription = "deleteOperation";
            this.radMenuItemDeleteOperation.AccessibleName = "حذف عملیات";
            this.radMenuItemDeleteOperation.Name = "radMenuItemDeleteOperation";
            this.radMenuItemDeleteOperation.Text = "حذف عملیات";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(672, 682);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(92, 30);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "بازخوانی";
            this.btnRefresh.VisualStyleManager = this.visualStyleManager1;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UCResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.iGroupBox1);
            this.Name = "UCResource";
            this.Size = new System.Drawing.Size(773, 729);
            this.iGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewResource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Janus.Windows.Common.VisualStyleManager visualStyleManager1;
        private UILibrary.IGroupBox iGroupBox1;
        private Telerik.WinControls.UI.RadTreeView radTreeViewResource;
        private Janus.Windows.EditControls.UIButton btnExit;
        private Telerik.WinControls.UI.RadContextMenu appDomainRadContextMenu1;
        private Telerik.WinControls.UI.RadContextMenu subMenuRadContextMenu2;
        private Telerik.WinControls.UI.RadContextMenu meuItemRadContextMenu3;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemDelete;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemEdit;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAddSubMenu;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemEditMenuItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemDeleteMenuItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAddSubMenuItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAddResourceItem;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemEditResource;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemDeleteResource;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAddAppDomain;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemAddOperation;
        private Telerik.WinControls.UI.RadContextMenu radContextMenuOperations;
        private Telerik.WinControls.UI.RadMenuItem radMenuItemDeleteOperation;
        private Janus.Windows.EditControls.UIButton btnRefresh;
    }
}
