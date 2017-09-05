namespace WebsiteStudio.UI.Forms {
    partial class GetLinkForm {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
			this.tabCtrl = new System.Windows.Forms.TabControl();
			this.tabPage = new System.Windows.Forms.TabPage();
			this.tvwPages = new System.Windows.Forms.TreeView();
			this.tabMedia = new System.Windows.Forms.TabPage();
			this.lvwMedia = new System.Windows.Forms.ListView();
			this.clnFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblSearch = new System.Windows.Forms.Label();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.tabCtrl.SuspendLayout();
			this.tabPage.SuspendLayout();
			this.tabMedia.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabCtrl
			// 
			this.tabCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabCtrl.Controls.Add(this.tabPage);
			this.tabCtrl.Controls.Add(this.tabMedia);
			this.tabCtrl.Location = new System.Drawing.Point(12, 38);
			this.tabCtrl.Name = "tabCtrl";
			this.tabCtrl.SelectedIndex = 0;
			this.tabCtrl.Size = new System.Drawing.Size(468, 220);
			this.tabCtrl.TabIndex = 0;
			this.tabCtrl.SelectedIndexChanged += new System.EventHandler(this.txtSearch_KeyUp);
			// 
			// tabPage
			// 
			this.tabPage.Controls.Add(this.tvwPages);
			this.tabPage.Location = new System.Drawing.Point(4, 22);
			this.tabPage.Name = "tabPage";
			this.tabPage.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage.Size = new System.Drawing.Size(460, 194);
			this.tabPage.TabIndex = 0;
			this.tabPage.Text = "[Page]";
			this.tabPage.UseVisualStyleBackColor = true;
			// 
			// tvwPages
			// 
			this.tvwPages.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvwPages.FullRowSelect = true;
			this.tvwPages.Location = new System.Drawing.Point(3, 3);
			this.tvwPages.Name = "tvwPages";
			this.tvwPages.Size = new System.Drawing.Size(454, 188);
			this.tvwPages.TabIndex = 0;
			// 
			// tabMedia
			// 
			this.tabMedia.Controls.Add(this.lvwMedia);
			this.tabMedia.Location = new System.Drawing.Point(4, 22);
			this.tabMedia.Name = "tabMedia";
			this.tabMedia.Padding = new System.Windows.Forms.Padding(3);
			this.tabMedia.Size = new System.Drawing.Size(460, 194);
			this.tabMedia.TabIndex = 1;
			this.tabMedia.Text = "[Media]";
			this.tabMedia.UseVisualStyleBackColor = true;
			// 
			// lvwMedia
			// 
			this.lvwMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnFile,
            this.clnType});
			this.lvwMedia.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwMedia.FullRowSelect = true;
			this.lvwMedia.Location = new System.Drawing.Point(3, 3);
			this.lvwMedia.MultiSelect = false;
			this.lvwMedia.Name = "lvwMedia";
			this.lvwMedia.Size = new System.Drawing.Size(454, 188);
			this.lvwMedia.TabIndex = 0;
			this.lvwMedia.UseCompatibleStateImageBehavior = false;
			this.lvwMedia.View = System.Windows.Forms.View.Details;
			this.lvwMedia.VirtualMode = true;
			this.lvwMedia.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwMedia_RetrieveVirtualItem);
			// 
			// clnFile
			// 
			this.clnFile.Text = "[Name]";
			this.clnFile.Width = 240;
			// 
			// clnType
			// 
			this.clnType.Text = "[Type]";
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(270, 264);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 1;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(376, 264);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(16, 15);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(50, 13);
			this.lblSearch.TabIndex = 3;
			this.lblSearch.Text = "[Search:]";
			// 
			// txtSearch
			// 
			this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearch.Location = new System.Drawing.Point(103, 12);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(377, 20);
			this.txtSearch.TabIndex = 4;
			this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
			// 
			// GetLinkForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 301);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.tabCtrl);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(380, 270);
			this.Name = "GetLinkForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[GetLink]";
			this.tabCtrl.ResumeLayout(false);
			this.tabPage.ResumeLayout(false);
			this.tabMedia.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabCtrl;
        private System.Windows.Forms.TabPage tabPage;
        private System.Windows.Forms.TabPage tabMedia;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView tvwPages;
        private System.Windows.Forms.ListView lvwMedia;
        private System.Windows.Forms.ColumnHeader clnFile;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.ColumnHeader clnType;
	}
}