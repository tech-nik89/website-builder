namespace WebsiteBuilder.UI.Controls {
    partial class PagesTreeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PagesTreeView));
            this.lvwPages = new System.Windows.Forms.ListView();
            this.clnPathName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnLayout = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.tscLayoutSection = new System.Windows.Forms.ToolStripComboBox();
            this.tsbEditContent = new System.Windows.Forms.ToolStripButton();
            this.cmsDragDrop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDragDropMoveBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDragDropMoveAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDragDropMoveAsChild = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbEditContent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbStartPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain.SuspendLayout();
            this.cmsDragDrop.SuspendLayout();
            this.cmsTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPages
            // 
            this.lvwPages.AllowDrop = true;
            this.lvwPages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnPathName,
            this.clnTitle,
            this.clnLayout});
            this.lvwPages.ContextMenuStrip = this.cmsTree;
            this.lvwPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPages.FullRowSelect = true;
            this.lvwPages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPages.Location = new System.Drawing.Point(0, 25);
            this.lvwPages.MultiSelect = false;
            this.lvwPages.Name = "lvwPages";
            this.lvwPages.Size = new System.Drawing.Size(635, 342);
            this.lvwPages.TabIndex = 0;
            this.lvwPages.UseCompatibleStateImageBehavior = false;
            this.lvwPages.View = System.Windows.Forms.View.Details;
            this.lvwPages.VirtualMode = true;
            this.lvwPages.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwPages_ItemDrag);
            this.lvwPages.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwPages_RetrieveVirtualItem);
            this.lvwPages.SelectedIndexChanged += new System.EventHandler(this.lvwPages_SelectedIndexChanged);
            this.lvwPages.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwPages_DragDrop);
            this.lvwPages.DragOver += new System.Windows.Forms.DragEventHandler(this.lvwPages_DragOver);
            this.lvwPages.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwPages_MouseDoubleClick);
            // 
            // clnPathName
            // 
            this.clnPathName.Text = "[Path name]";
            this.clnPathName.Width = 280;
            // 
            // clnTitle
            // 
            this.clnTitle.Text = "[Title]";
            this.clnTitle.Width = 140;
            // 
            // clnLayout
            // 
            this.clnLayout.Text = "[Layout]";
            this.clnLayout.Width = 140;
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tscLanguage,
            this.tscLayoutSection,
            this.tsbEditContent});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(635, 25);
            this.tsMain.TabIndex = 1;
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(57, 22);
            this.tsbAdd.Text = "[Add]";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // tsbEdit
            // 
            this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(55, 22);
            this.tsbEdit.Text = "[Edit]";
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(68, 22);
            this.tsbDelete.Text = "[Delete]";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tscLanguage
            // 
            this.tscLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscLanguage.Name = "tscLanguage";
            this.tscLanguage.Size = new System.Drawing.Size(121, 25);
            this.tscLanguage.SelectedIndexChanged += new System.EventHandler(this.tscLanguage_SelectedIndexChanged);
            // 
            // tscLayoutSection
            // 
            this.tscLayoutSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscLayoutSection.Name = "tscLayoutSection";
            this.tscLayoutSection.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbEditContent
            // 
            this.tsbEditContent.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditContent.Image")));
            this.tsbEditContent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditContent.Name = "tsbEditContent";
            this.tsbEditContent.Size = new System.Drawing.Size(101, 22);
            this.tsbEditContent.Text = "[Edit Content]";
            this.tsbEditContent.Click += new System.EventHandler(this.tsbEditContent_Click);
            // 
            // cmsDragDrop
            // 
            this.cmsDragDrop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsDragDropMoveBefore,
            this.cmsDragDropMoveAfter,
            this.toolStripSeparator2,
            this.cmsDragDropMoveAsChild});
            this.cmsDragDrop.Name = "contextMenuStrip1";
            this.cmsDragDrop.Size = new System.Drawing.Size(158, 76);
            // 
            // cmsDragDropMoveBefore
            // 
            this.cmsDragDropMoveBefore.Name = "cmsDragDropMoveBefore";
            this.cmsDragDropMoveBefore.Size = new System.Drawing.Size(157, 22);
            this.cmsDragDropMoveBefore.Text = "[Move Before]";
            this.cmsDragDropMoveBefore.Click += new System.EventHandler(this.cmsDragDropMoveBefore_Click);
            // 
            // cmsDragDropMoveAfter
            // 
            this.cmsDragDropMoveAfter.Name = "cmsDragDropMoveAfter";
            this.cmsDragDropMoveAfter.Size = new System.Drawing.Size(157, 22);
            this.cmsDragDropMoveAfter.Text = "[Move After]";
            this.cmsDragDropMoveAfter.Click += new System.EventHandler(this.cmsDragDropMoveAfter_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(154, 6);
            // 
            // cmsDragDropMoveAsChild
            // 
            this.cmsDragDropMoveAsChild.Name = "cmsDragDropMoveAsChild";
            this.cmsDragDropMoveAsChild.Size = new System.Drawing.Size(157, 22);
            this.cmsDragDropMoveAsChild.Text = "[Move as Child]";
            this.cmsDragDropMoveAsChild.Click += new System.EventHandler(this.cmsDragDropMoveAsChild_Click);
            // 
            // cmsTree
            // 
            this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbEdit,
            this.cmbDelete,
            this.toolStripSeparator3,
            this.cmbEditContent,
            this.toolStripSeparator4,
            this.cmbStartPage});
            this.cmsTree.Name = "cmsTree";
            this.cmsTree.Size = new System.Drawing.Size(168, 104);
            // 
            // cmbEdit
            // 
            this.cmbEdit.Name = "cmbEdit";
            this.cmbEdit.Size = new System.Drawing.Size(167, 22);
            this.cmbEdit.Text = "[Edit]";
            this.cmbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            // 
            // cmbDelete
            // 
            this.cmbDelete.Name = "cmbDelete";
            this.cmbDelete.Size = new System.Drawing.Size(167, 22);
            this.cmbDelete.Text = "[Delete]";
            this.cmbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
            // 
            // cmbEditContent
            // 
            this.cmbEditContent.Name = "cmbEditContent";
            this.cmbEditContent.Size = new System.Drawing.Size(167, 22);
            this.cmbEditContent.Text = "[Edit Content]";
            this.cmbEditContent.Click += new System.EventHandler(this.tsbEditContent_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // cmbStartPage
            // 
            this.cmbStartPage.Name = "cmbStartPage";
            this.cmbStartPage.Size = new System.Drawing.Size(167, 22);
            this.cmbStartPage.Text = "[Set As StartPage]";
            this.cmbStartPage.Click += new System.EventHandler(this.tsbStartPage_Click);
            // 
            // PagesTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwPages);
            this.Controls.Add(this.tsMain);
            this.DoubleBuffered = true;
            this.Name = "PagesTreeView";
            this.Size = new System.Drawing.Size(635, 367);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.cmsDragDrop.ResumeLayout(false);
            this.cmsTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPages;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ColumnHeader clnPathName;
        private System.Windows.Forms.ColumnHeader clnLayout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox tscLanguage;
        private System.Windows.Forms.ToolStripComboBox tscLayoutSection;
        private System.Windows.Forms.ColumnHeader clnTitle;
        private System.Windows.Forms.ToolStripButton tsbEditContent;
        private System.Windows.Forms.ContextMenuStrip cmsDragDrop;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveBefore;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveAsChild;
        private System.Windows.Forms.ContextMenuStrip cmsTree;
        private System.Windows.Forms.ToolStripMenuItem cmbEdit;
        private System.Windows.Forms.ToolStripMenuItem cmbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmbEditContent;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmbStartPage;
    }
}
