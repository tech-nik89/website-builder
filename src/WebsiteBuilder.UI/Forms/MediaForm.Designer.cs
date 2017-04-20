namespace WebsiteBuilder.UI.Forms {
    partial class MediaForm {
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
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clnAutoSave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbAddReference = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAddImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslAutoSave = new System.Windows.Forms.ToolStripLabel();
            this.tscAutoSave = new System.Windows.Forms.ToolStripComboBox();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwFiles
            // 
            this.lvwFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName,
            this.clnSize,
            this.clnType,
            this.clnAutoSave});
            this.lvwFiles.FullRowSelect = true;
            this.lvwFiles.HideSelection = false;
            this.lvwFiles.Location = new System.Drawing.Point(0, 28);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(568, 329);
            this.lvwFiles.TabIndex = 0;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.View = System.Windows.Forms.View.Details;
            this.lvwFiles.VirtualMode = true;
            this.lvwFiles.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwFiles_RetrieveVirtualItem);
            this.lvwFiles.SelectedIndexChanged += new System.EventHandler(this.lvwFiles_SelectedIndexChanged);
            // 
            // clnName
            // 
            this.clnName.Text = "[Name]";
            this.clnName.Width = 180;
            // 
            // clnSize
            // 
            this.clnSize.Text = "[Size]";
            this.clnSize.Width = 120;
            // 
            // clnType
            // 
            this.clnType.Text = "[Type]";
            this.clnType.Width = 120;
            // 
            // clnAutoSave
            // 
            this.clnAutoSave.Text = "[Auto Save]";
            this.clnAutoSave.Width = 120;
            // 
            // tsMain
            // 
            this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbRemove,
            this.toolStripSeparator1,
            this.tslAutoSave,
            this.tscAutoSave});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(568, 25);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddReference,
            this.tsbAddImport});
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(50, 22);
            this.tsbAdd.Text = "[Add]";
            // 
            // tsbAddReference
            // 
            this.tsbAddReference.Name = "tsbAddReference";
            this.tsbAddReference.Size = new System.Drawing.Size(182, 22);
            this.tsbAddReference.Text = "[Add reference]";
            this.tsbAddReference.Click += new System.EventHandler(this.tsbAddReference_Click);
            // 
            // tsbAddImport
            // 
            this.tsbAddImport.Name = "tsbAddImport";
            this.tsbAddImport.Size = new System.Drawing.Size(182, 22);
            this.tsbAddImport.Text = "[Import into project]";
            this.tsbAddImport.Click += new System.EventHandler(this.tsbAddImport_Click);
            // 
            // tsbRemove
            // 
            this.tsbRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemove.Name = "tsbRemove";
            this.tsbRemove.Size = new System.Drawing.Size(62, 22);
            this.tsbRemove.Text = "[Remove]";
            this.tsbRemove.Click += new System.EventHandler(this.tsbRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslAutoSave
            // 
            this.tslAutoSave.Name = "tslAutoSave";
            this.tslAutoSave.Size = new System.Drawing.Size(71, 22);
            this.tslAutoSave.Text = "[Auto Save:]";
            // 
            // tscAutoSave
            // 
            this.tscAutoSave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscAutoSave.Name = "tscAutoSave";
            this.tscAutoSave.Size = new System.Drawing.Size(121, 25);
            this.tscAutoSave.SelectedIndexChanged += new System.EventHandler(this.tscAutoSave_SelectedIndexChanged);
            // 
            // MediaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 357);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.lvwFiles);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 270);
            this.Name = "MediaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Media";
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbRemove;
        private System.Windows.Forms.ToolStripDropDownButton tsbAdd;
        private System.Windows.Forms.ToolStripMenuItem tsbAddReference;
        private System.Windows.Forms.ToolStripMenuItem tsbAddImport;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.ColumnHeader clnName;
        private System.Windows.Forms.ColumnHeader clnSize;
        private System.Windows.Forms.ColumnHeader clnType;
		private System.Windows.Forms.ColumnHeader clnAutoSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel tslAutoSave;
		private System.Windows.Forms.ToolStripComboBox tscAutoSave;
	}
}