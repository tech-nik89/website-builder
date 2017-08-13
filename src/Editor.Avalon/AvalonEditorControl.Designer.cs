namespace WebsiteBuilder.Editors.Avalon {
    partial class AvalonEditorControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvalonEditorControl));
			this.wpfHost = new System.Windows.Forms.Integration.ElementHost();
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbUndo = new System.Windows.Forms.ToolStripButton();
			this.tsbRedo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbSearch = new System.Windows.Forms.ToolStripButton();
			this.tsbInsertLink = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbCut = new System.Windows.Forms.ToolStripButton();
			this.tsbCopy = new System.Windows.Forms.ToolStripButton();
			this.tsbPaste = new System.Windows.Forms.ToolStripButton();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// wpfHost
			// 
			this.wpfHost.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wpfHost.Location = new System.Drawing.Point(0, 25);
			this.wpfHost.Name = "wpfHost";
			this.wpfHost.Size = new System.Drawing.Size(565, 234);
			this.wpfHost.TabIndex = 0;
			this.wpfHost.Child = null;
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.toolStripSeparator2,
            this.tsbUndo,
            this.tsbRedo,
            this.toolStripSeparator1,
            this.tsbSearch,
            this.tsbInsertLink});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(565, 25);
			this.tsMain.TabIndex = 1;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbUndo
			// 
			this.tsbUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbUndo.Image = ((System.Drawing.Image)(resources.GetObject("tsbUndo.Image")));
			this.tsbUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUndo.Name = "tsbUndo";
			this.tsbUndo.Size = new System.Drawing.Size(23, 22);
			this.tsbUndo.Text = "[Undo]";
			this.tsbUndo.Click += new System.EventHandler(this.tsbUndo_Click);
			// 
			// tsbRedo
			// 
			this.tsbRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbRedo.Image = ((System.Drawing.Image)(resources.GetObject("tsbRedo.Image")));
			this.tsbRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbRedo.Name = "tsbRedo";
			this.tsbRedo.Size = new System.Drawing.Size(23, 22);
			this.tsbRedo.Text = "[Redo]";
			this.tsbRedo.Click += new System.EventHandler(this.tsbRedo_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbSearch
			// 
			this.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbSearch.Image")));
			this.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSearch.Name = "tsbSearch";
			this.tsbSearch.Size = new System.Drawing.Size(23, 22);
			this.tsbSearch.Text = "[Search]";
			this.tsbSearch.Click += new System.EventHandler(this.tsbSearch_Click);
			// 
			// tsbInsertLink
			// 
			this.tsbInsertLink.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbInsertLink.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsertLink.Image")));
			this.tsbInsertLink.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInsertLink.Name = "tsbInsertLink";
			this.tsbInsertLink.Size = new System.Drawing.Size(23, 22);
			this.tsbInsertLink.Text = "[InsertLink]";
			this.tsbInsertLink.Click += new System.EventHandler(this.tsbInsertLink_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbCut
			// 
			this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCut.Image = ((System.Drawing.Image)(resources.GetObject("tsbCut.Image")));
			this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCut.Name = "tsbCut";
			this.tsbCut.Size = new System.Drawing.Size(23, 22);
			this.tsbCut.Text = "[Cut]";
			this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
			// 
			// tsbCopy
			// 
			this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
			this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbCopy.Name = "tsbCopy";
			this.tsbCopy.Size = new System.Drawing.Size(23, 22);
			this.tsbCopy.Text = "[Copy]";
			this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
			// 
			// tsbPaste
			// 
			this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
			this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbPaste.Name = "tsbPaste";
			this.tsbPaste.Size = new System.Drawing.Size(23, 22);
			this.tsbPaste.Text = "[Paste]";
			this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
			// 
			// AvalonEditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.wpfHost);
			this.Controls.Add(this.tsMain);
			this.Name = "AvalonEditorControl";
			this.Size = new System.Drawing.Size(565, 259);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost wpfHost;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbUndo;
		private System.Windows.Forms.ToolStripButton tsbRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbSearch;
		private System.Windows.Forms.ToolStripButton tsbInsertLink;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbCut;
		private System.Windows.Forms.ToolStripButton tsbCopy;
		private System.Windows.Forms.ToolStripButton tsbPaste;
	}
}
