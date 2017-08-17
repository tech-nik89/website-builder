namespace WebsiteStudio.UI.Controls {
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
			this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmbEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.cmbDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cmbStartPage = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.cmbBuildPage = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsDragDrop = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsDragDropMoveBefore = new System.Windows.Forms.ToolStripMenuItem();
			this.cmsDragDropMoveAfter = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmsDragDropMoveAsChild = new System.Windows.Forms.ToolStripMenuItem();
			this.lvwPages = new System.Windows.Forms.ListView();
			this.clnPathName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmsTree.SuspendLayout();
			this.cmsDragDrop.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmsTree
			// 
			this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbEdit,
            this.cmbDelete,
            this.toolStripSeparator3,
            this.cmbStartPage,
            this.toolStripSeparator4,
            this.cmbBuildPage});
			this.cmsTree.Name = "cmsTree";
			this.cmsTree.Size = new System.Drawing.Size(168, 104);
			// 
			// cmbEdit
			// 
			this.cmbEdit.Name = "cmbEdit";
			this.cmbEdit.Size = new System.Drawing.Size(167, 22);
			this.cmbEdit.Text = "[Edit]";
			this.cmbEdit.Click += new System.EventHandler(this.cmbEdit_Click);
			// 
			// cmbDelete
			// 
			this.cmbDelete.Name = "cmbDelete";
			this.cmbDelete.Size = new System.Drawing.Size(167, 22);
			this.cmbDelete.Text = "[Delete]";
			this.cmbDelete.Click += new System.EventHandler(this.cmbDelete_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(164, 6);
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
			// lvwPages
			// 
			this.lvwPages.AllowDrop = true;
			this.lvwPages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnPathName});
			this.lvwPages.ContextMenuStrip = this.cmsTree;
			this.lvwPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwPages.FullRowSelect = true;
			this.lvwPages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwPages.HideSelection = false;
			this.lvwPages.Location = new System.Drawing.Point(0, 0);
			this.lvwPages.MultiSelect = false;
			this.lvwPages.Name = "lvwPages";
			this.lvwPages.Size = new System.Drawing.Size(785, 358);
			this.lvwPages.TabIndex = 3;
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
			// PagesTreeView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(785, 358);
			this.Controls.Add(this.lvwPages);
			this.DoubleBuffered = true;
			this.Name = "PagesTreeView";
			this.cmsTree.ResumeLayout(false);
			this.cmsDragDrop.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip cmsDragDrop;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveBefore;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveAfter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmsDragDropMoveAsChild;
        private System.Windows.Forms.ContextMenuStrip cmsTree;
        private System.Windows.Forms.ToolStripMenuItem cmbEdit;
        private System.Windows.Forms.ToolStripMenuItem cmbDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmbStartPage;
        private System.Windows.Forms.ToolStripMenuItem cmbBuildPage;
		private System.Windows.Forms.ListView lvwPages;
		private System.Windows.Forms.ColumnHeader clnPathName;
	}
}
