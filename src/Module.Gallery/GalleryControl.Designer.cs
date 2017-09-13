namespace WebsiteStudio.Modules.Gallery {
    partial class GalleryControl {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GalleryControl));
			this.lvwImages = new System.Windows.Forms.ListView();
			this.clnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbAdd = new System.Windows.Forms.ToolStripButton();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbView = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsbViewLargeIcon = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbViewList = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbViewDetails = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbSettings = new System.Windows.Forms.ToolStripButton();
			this.ofdImages = new System.Windows.Forms.OpenFileDialog();
			this.lblLoading = new System.Windows.Forms.Label();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwImages
			// 
			this.lvwImages.AllowDrop = true;
			this.lvwImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnFile,
            this.clnSize});
			this.lvwImages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwImages.FullRowSelect = true;
			this.lvwImages.GridLines = true;
			this.lvwImages.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwImages.HideSelection = false;
			this.lvwImages.Location = new System.Drawing.Point(0, 25);
			this.lvwImages.Name = "lvwImages";
			this.lvwImages.Size = new System.Drawing.Size(424, 281);
			this.lvwImages.TabIndex = 0;
			this.lvwImages.UseCompatibleStateImageBehavior = false;
			this.lvwImages.View = System.Windows.Forms.View.Details;
			this.lvwImages.VirtualMode = true;
			this.lvwImages.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwImages_RetrieveVirtualItem);
			this.lvwImages.SelectedIndexChanged += new System.EventHandler(this.lvwImages_SelectedIndexChanged);
			this.lvwImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwImages_DragDrop);
			this.lvwImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwImages_DragEnter);
			this.lvwImages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvwImages_KeyUp);
			// 
			// clnFile
			// 
			this.clnFile.Text = "[File]";
			this.clnFile.Width = 240;
			// 
			// clnSize
			// 
			this.clnSize.Text = "[Size]";
			this.clnSize.Width = 120;
			// 
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbView,
            this.toolStripSeparator2,
            this.tsbSettings});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(424, 25);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
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
			// tsbDelete
			// 
			this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(78, 22);
			this.tsbDelete.Text = "[Remove]";
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbView
			// 
			this.tsbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbViewLargeIcon,
            this.tsbViewList,
            this.tsbViewDetails});
			this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
			this.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbView.Name = "tsbView";
			this.tsbView.Size = new System.Drawing.Size(29, 22);
			this.tsbView.Text = "toolStripDropDownButton1";
			// 
			// tsbViewLargeIcon
			// 
			this.tsbViewLargeIcon.Name = "tsbViewLargeIcon";
			this.tsbViewLargeIcon.Size = new System.Drawing.Size(134, 22);
			this.tsbViewLargeIcon.Text = "[LargeIcon]";
			this.tsbViewLargeIcon.Click += new System.EventHandler(this.tsbViewLargeIcon_Click);
			// 
			// tsbViewList
			// 
			this.tsbViewList.Name = "tsbViewList";
			this.tsbViewList.Size = new System.Drawing.Size(134, 22);
			this.tsbViewList.Text = "[List]";
			this.tsbViewList.Click += new System.EventHandler(this.tsbViewList_Click);
			// 
			// tsbViewDetails
			// 
			this.tsbViewDetails.Name = "tsbViewDetails";
			this.tsbViewDetails.Size = new System.Drawing.Size(134, 22);
			this.tsbViewDetails.Text = "[Detail]";
			this.tsbViewDetails.Click += new System.EventHandler(this.tsbViewDetails_Click);
			// 
			// tsbSettings
			// 
			this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
			this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSettings.Name = "tsbSettings";
			this.tsbSettings.Size = new System.Drawing.Size(77, 22);
			this.tsbSettings.Text = "[Settings]";
			this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
			// 
			// ofdImages
			// 
			this.ofdImages.Multiselect = true;
			// 
			// lblLoading
			// 
			this.lblLoading.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLoading.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLoading.Location = new System.Drawing.Point(3, 147);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(418, 43);
			this.lblLoading.TabIndex = 2;
			this.lblLoading.Text = "[Loading]";
			this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// GalleryControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lblLoading);
			this.Controls.Add(this.lvwImages);
			this.Controls.Add(this.tsMain);
			this.Name = "GalleryControl";
			this.Size = new System.Drawing.Size(424, 306);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwImages;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbAdd;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.OpenFileDialog ofdImages;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSettings;
		private System.Windows.Forms.Label lblLoading;
		private System.Windows.Forms.ToolStripDropDownButton tsbView;
		private System.Windows.Forms.ToolStripMenuItem tsbViewLargeIcon;
		private System.Windows.Forms.ToolStripMenuItem tsbViewList;
		private System.Windows.Forms.ToolStripMenuItem tsbViewDetails;
		private System.Windows.Forms.ColumnHeader clnFile;
		private System.Windows.Forms.ColumnHeader clnSize;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
