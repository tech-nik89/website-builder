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
            this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmbEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbEditContent = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbStartPage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbBuildPage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.cmsDragDrop = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsDragDropMoveBefore = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDragDropMoveAfter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsDragDropMoveAsChild = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lvwContent = new System.Windows.Forms.ListView();
            this.clnContentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnContentEditor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbContentAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbContentEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbContentDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbContentUp = new System.Windows.Forms.ToolStripButton();
            this.tsbContentDown = new System.Windows.Forms.ToolStripButton();
            this.cmsTree.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.cmsDragDrop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPages
            // 
            this.lvwPages.AllowDrop = true;
            this.lvwPages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnPathName});
            this.lvwPages.ContextMenuStrip = this.cmsTree;
            this.lvwPages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwPages.FullRowSelect = true;
            this.lvwPages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwPages.Location = new System.Drawing.Point(0, 25);
            this.lvwPages.MultiSelect = false;
            this.lvwPages.Name = "lvwPages";
            this.lvwPages.Size = new System.Drawing.Size(267, 371);
            this.lvwPages.TabIndex = 0;
            this.lvwPages.UseCompatibleStateImageBehavior = false;
            this.lvwPages.View = System.Windows.Forms.View.Details;
            this.lvwPages.VirtualMode = true;
            this.lvwPages.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwPages_ItemDrag);
            this.lvwPages.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwPages_RetrieveVirtualItem);
            this.lvwPages.SelectedIndexChanged += new System.EventHandler(this.lvwPages_SelectedIndexChanged);
            this.lvwPages.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwPages_DragDrop);
            this.lvwPages.DragOver += new System.Windows.Forms.DragEventHandler(this.lvwPages_DragOver);
            this.lvwPages.DoubleClick += new System.EventHandler(this.lvwPages_DoubleClick);
            // 
            // clnPathName
            // 
            this.clnPathName.Text = "[Path name]";
            this.clnPathName.Width = 180;
            // 
            // cmsTree
            // 
            this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbEdit,
            this.cmbDelete,
            this.toolStripSeparator3,
            this.cmbEditContent,
            this.cmbStartPage,
            this.toolStripSeparator4,
            this.cmbBuildPage});
            this.cmsTree.Name = "cmsTree";
            this.cmsTree.Size = new System.Drawing.Size(168, 126);
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
            // 
            // cmbStartPage
            // 
            this.cmbStartPage.Name = "cmbStartPage";
            this.cmbStartPage.Size = new System.Drawing.Size(167, 22);
            this.cmbStartPage.Text = "[Set As StartPage]";
            this.cmbStartPage.Click += new System.EventHandler(this.tsbStartPage_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(164, 6);
            // 
            // cmbBuildPage
            // 
            this.cmbBuildPage.Name = "cmbBuildPage";
            this.cmbBuildPage.Size = new System.Drawing.Size(167, 22);
            this.cmbBuildPage.Text = "[Build this page]";
            this.cmbBuildPage.Click += new System.EventHandler(this.cmbBuildPage_Click);
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(267, 25);
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwPages);
            this.splitContainer1.Panel1.Controls.Add(this.tsMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwContent);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(801, 396);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 2;
            // 
            // lvwContent
            // 
            this.lvwContent.AllowDrop = true;
            this.lvwContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnContentType,
            this.clnContentEditor});
            this.lvwContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwContent.FullRowSelect = true;
            this.lvwContent.Location = new System.Drawing.Point(0, 25);
            this.lvwContent.MultiSelect = false;
            this.lvwContent.Name = "lvwContent";
            this.lvwContent.Size = new System.Drawing.Size(530, 371);
            this.lvwContent.TabIndex = 1;
            this.lvwContent.UseCompatibleStateImageBehavior = false;
            this.lvwContent.View = System.Windows.Forms.View.Details;
            this.lvwContent.VirtualMode = true;
            this.lvwContent.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwContent_RetrieveVirtualItem);
            this.lvwContent.SelectedIndexChanged += new System.EventHandler(this.lvwContent_SelectedIndexChanged);
            this.lvwContent.DoubleClick += new System.EventHandler(this.lvwContent_DoubleClick);
            // 
            // clnContentType
            // 
            this.clnContentType.Text = "[Type]";
            this.clnContentType.Width = 180;
            // 
            // clnContentEditor
            // 
            this.clnContentEditor.Text = "[Editor]";
            this.clnContentEditor.Width = 180;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbContentAdd,
            this.tsbContentEdit,
            this.tsbContentDelete,
            this.toolStripSeparator1,
            this.tsbContentUp,
            this.tsbContentDown});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(530, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbContentAdd
            // 
            this.tsbContentAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentAdd.Image")));
            this.tsbContentAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentAdd.Name = "tsbContentAdd";
            this.tsbContentAdd.Size = new System.Drawing.Size(57, 22);
            this.tsbContentAdd.Text = "[Add]";
            this.tsbContentAdd.Click += new System.EventHandler(this.tsbContentAdd_Click);
            // 
            // tsbContentEdit
            // 
            this.tsbContentEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentEdit.Image")));
            this.tsbContentEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentEdit.Name = "tsbContentEdit";
            this.tsbContentEdit.Size = new System.Drawing.Size(55, 22);
            this.tsbContentEdit.Text = "[Edit]";
            this.tsbContentEdit.Click += new System.EventHandler(this.tsbContentEdit_Click);
            // 
            // tsbContentDelete
            // 
            this.tsbContentDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentDelete.Image")));
            this.tsbContentDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentDelete.Name = "tsbContentDelete";
            this.tsbContentDelete.Size = new System.Drawing.Size(68, 22);
            this.tsbContentDelete.Text = "[Delete]";
            this.tsbContentDelete.Click += new System.EventHandler(this.tsbContentDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbContentUp
            // 
            this.tsbContentUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentUp.Image")));
            this.tsbContentUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentUp.Name = "tsbContentUp";
            this.tsbContentUp.Size = new System.Drawing.Size(50, 22);
            this.tsbContentUp.Text = "[Up]";
            this.tsbContentUp.Click += new System.EventHandler(this.tsbContentUp_Click);
            // 
            // tsbContentDown
            // 
            this.tsbContentDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbContentDown.Image")));
            this.tsbContentDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContentDown.Name = "tsbContentDown";
            this.tsbContentDown.Size = new System.Drawing.Size(66, 22);
            this.tsbContentDown.Text = "[Down]";
            this.tsbContentDown.Click += new System.EventHandler(this.tsbContentDown_Click);
            // 
            // PagesTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.DoubleBuffered = true;
            this.Name = "PagesTreeView";
            this.Size = new System.Drawing.Size(801, 396);
            this.cmsTree.ResumeLayout(false);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.cmsDragDrop.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPages;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbEdit;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ColumnHeader clnPathName;
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
        private System.Windows.Forms.ToolStripMenuItem cmbBuildPage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbContentAdd;
        private System.Windows.Forms.ToolStripButton tsbContentEdit;
        private System.Windows.Forms.ToolStripButton tsbContentDelete;
        private System.Windows.Forms.ListView lvwContent;
        private System.Windows.Forms.ColumnHeader clnContentType;
        private System.Windows.Forms.ColumnHeader clnContentEditor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbContentUp;
        private System.Windows.Forms.ToolStripButton tsbContentDown;
    }
}
