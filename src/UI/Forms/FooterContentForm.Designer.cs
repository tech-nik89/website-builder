namespace WebsiteStudio.UI.Forms {
    partial class FooterContentForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FooterContentForm));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbSectionAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbSectionDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tscLanguage = new System.Windows.Forms.ToolStripComboBox();
            this.lvwSections = new System.Windows.Forms.ListView();
            this.clnSectionTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbxLinks = new System.Windows.Forms.GroupBox();
            this.btnLinkDelete = new System.Windows.Forms.Button();
            this.btnLinkEdit = new System.Windows.Forms.Button();
            this.btnLinkAdd = new System.Windows.Forms.Button();
            this.lvwLinks = new System.Windows.Forms.ListView();
            this.clnLinkText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnLinkURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnLinkTarget = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbxTitle = new System.Windows.Forms.GroupBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.tsMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbxLinks.SuspendLayout();
            this.gbxTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSectionAdd,
            this.tsbSectionDelete,
            this.toolStripSeparator1,
            this.tscLanguage});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(752, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbSectionAdd
            // 
            this.tsbSectionAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbSectionAdd.Image")));
            this.tsbSectionAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSectionAdd.Name = "tsbSectionAdd";
            this.tsbSectionAdd.Size = new System.Drawing.Size(57, 22);
            this.tsbSectionAdd.Text = "[Add]";
            this.tsbSectionAdd.Click += new System.EventHandler(this.tsbSectionAdd_Click);
            // 
            // tsbSectionDelete
            // 
            this.tsbSectionDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbSectionDelete.Image")));
            this.tsbSectionDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSectionDelete.Name = "tsbSectionDelete";
            this.tsbSectionDelete.Size = new System.Drawing.Size(68, 22);
            this.tsbSectionDelete.Text = "[Delete]";
            this.tsbSectionDelete.Click += new System.EventHandler(this.tsbSectionDelete_Click);
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
            this.tscLanguage.Size = new System.Drawing.Size(160, 25);
            this.tscLanguage.SelectedIndexChanged += new System.EventHandler(this.tscLanguage_SelectedIndexChanged);
            // 
            // lvwSections
            // 
            this.lvwSections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnSectionTitle});
            this.lvwSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSections.FullRowSelect = true;
            this.lvwSections.Location = new System.Drawing.Point(0, 0);
            this.lvwSections.MultiSelect = false;
            this.lvwSections.Name = "lvwSections";
            this.lvwSections.Size = new System.Drawing.Size(292, 397);
            this.lvwSections.TabIndex = 1;
            this.lvwSections.UseCompatibleStateImageBehavior = false;
            this.lvwSections.View = System.Windows.Forms.View.Details;
            this.lvwSections.VirtualMode = true;
            this.lvwSections.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwSections_RetrieveVirtualItem);
            this.lvwSections.SelectedIndexChanged += new System.EventHandler(this.lvwSections_SelectedIndexChanged);
            // 
            // clnSectionTitle
            // 
            this.clnSectionTitle.Text = "[Title]";
            this.clnSectionTitle.Width = 180;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvwSections);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbxLinks);
            this.splitContainer1.Panel2.Controls.Add(this.gbxTitle);
            this.splitContainer1.Size = new System.Drawing.Size(752, 397);
            this.splitContainer1.SplitterDistance = 292;
            this.splitContainer1.TabIndex = 2;
            // 
            // gbxLinks
            // 
            this.gbxLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxLinks.Controls.Add(this.btnLinkDelete);
            this.gbxLinks.Controls.Add(this.btnLinkEdit);
            this.gbxLinks.Controls.Add(this.btnLinkAdd);
            this.gbxLinks.Controls.Add(this.lvwLinks);
            this.gbxLinks.Location = new System.Drawing.Point(3, 60);
            this.gbxLinks.Name = "gbxLinks";
            this.gbxLinks.Size = new System.Drawing.Size(450, 334);
            this.gbxLinks.TabIndex = 1;
            this.gbxLinks.TabStop = false;
            this.gbxLinks.Text = "[Links]";
            // 
            // btnLinkDelete
            // 
            this.btnLinkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLinkDelete.Location = new System.Drawing.Point(218, 300);
            this.btnLinkDelete.Name = "btnLinkDelete";
            this.btnLinkDelete.Size = new System.Drawing.Size(100, 25);
            this.btnLinkDelete.TabIndex = 3;
            this.btnLinkDelete.Text = "[Delete]";
            this.btnLinkDelete.UseVisualStyleBackColor = true;
            this.btnLinkDelete.Click += new System.EventHandler(this.btnLinkDelete_Click);
            // 
            // btnLinkEdit
            // 
            this.btnLinkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLinkEdit.Location = new System.Drawing.Point(112, 300);
            this.btnLinkEdit.Name = "btnLinkEdit";
            this.btnLinkEdit.Size = new System.Drawing.Size(100, 25);
            this.btnLinkEdit.TabIndex = 2;
            this.btnLinkEdit.Text = "[Edit]";
            this.btnLinkEdit.UseVisualStyleBackColor = true;
            this.btnLinkEdit.Click += new System.EventHandler(this.btnLinkEdit_Click);
            // 
            // btnLinkAdd
            // 
            this.btnLinkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLinkAdd.Location = new System.Drawing.Point(6, 300);
            this.btnLinkAdd.Name = "btnLinkAdd";
            this.btnLinkAdd.Size = new System.Drawing.Size(100, 25);
            this.btnLinkAdd.TabIndex = 1;
            this.btnLinkAdd.Text = "[Add]";
            this.btnLinkAdd.UseVisualStyleBackColor = true;
            this.btnLinkAdd.Click += new System.EventHandler(this.btnLinkAdd_Click);
            // 
            // lvwLinks
            // 
            this.lvwLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLinks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnLinkText,
            this.clnLinkURL,
            this.clnLinkTarget});
            this.lvwLinks.FullRowSelect = true;
            this.lvwLinks.Location = new System.Drawing.Point(6, 19);
            this.lvwLinks.MultiSelect = false;
            this.lvwLinks.Name = "lvwLinks";
            this.lvwLinks.Size = new System.Drawing.Size(438, 275);
            this.lvwLinks.TabIndex = 0;
            this.lvwLinks.UseCompatibleStateImageBehavior = false;
            this.lvwLinks.View = System.Windows.Forms.View.Details;
            this.lvwLinks.VirtualMode = true;
            this.lvwLinks.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwLinks_RetrieveVirtualItem);
            this.lvwLinks.DoubleClick += new System.EventHandler(this.lvwLinks_DoubleClick);
            // 
            // clnLinkText
            // 
            this.clnLinkText.Text = "[Text]";
            this.clnLinkText.Width = 140;
            // 
            // clnLinkURL
            // 
            this.clnLinkURL.Text = "[URL]";
            this.clnLinkURL.Width = 120;
            // 
            // clnLinkTarget
            // 
            this.clnLinkTarget.Text = "[Target]";
            this.clnLinkTarget.Width = 90;
            // 
            // gbxTitle
            // 
            this.gbxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTitle.Controls.Add(this.txtTitle);
            this.gbxTitle.Location = new System.Drawing.Point(3, 3);
            this.gbxTitle.Name = "gbxTitle";
            this.gbxTitle.Size = new System.Drawing.Size(450, 51);
            this.gbxTitle.TabIndex = 0;
            this.gbxTitle.TabStop = false;
            this.gbxTitle.Text = "[Title]";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(6, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(438, 20);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // FooterContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 422);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tsMain);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(650, 300);
            this.Name = "FooterContentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Footer]";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbxLinks.ResumeLayout(false);
            this.gbxTitle.ResumeLayout(false);
            this.gbxTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbSectionAdd;
        private System.Windows.Forms.ToolStripButton tsbSectionDelete;
        private System.Windows.Forms.ListView lvwSections;
        private System.Windows.Forms.ColumnHeader clnSectionTitle;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox tscLanguage;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbxTitle;
        private System.Windows.Forms.GroupBox gbxLinks;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ListView lvwLinks;
        private System.Windows.Forms.ColumnHeader clnLinkText;
        private System.Windows.Forms.ColumnHeader clnLinkURL;
        private System.Windows.Forms.ColumnHeader clnLinkTarget;
        private System.Windows.Forms.Button btnLinkDelete;
        private System.Windows.Forms.Button btnLinkEdit;
        private System.Windows.Forms.Button btnLinkAdd;
    }
}