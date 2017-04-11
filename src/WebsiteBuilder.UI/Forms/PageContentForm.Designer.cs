namespace WebsiteBuilder.UI.Forms {
    partial class PageContentForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageContentForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.pnlModuleContainer = new System.Windows.Forms.Panel();
            this.tsbInsertLink = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbInsertLink,
            this.tsbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(59, 22);
            this.tsbSave.Text = "[Save]";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            // pnlModuleContainer
            // 
            this.pnlModuleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlModuleContainer.Location = new System.Drawing.Point(0, 25);
            this.pnlModuleContainer.Name = "pnlModuleContainer";
            this.pnlModuleContainer.Size = new System.Drawing.Size(582, 384);
            this.pnlModuleContainer.TabIndex = 1;
            // 
            // tsbInsertLink
            // 
            this.tsbInsertLink.Image = ((System.Drawing.Image)(resources.GetObject("tsbInsertLink.Image")));
            this.tsbInsertLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertLink.Name = "tsbInsertLink";
            this.tsbInsertLink.Size = new System.Drawing.Size(89, 22);
            this.tsbInsertLink.Text = "{Insert Link]";
            this.tsbInsertLink.Click += new System.EventHandler(this.tsbInsertLink_Click);
            // 
            // PageContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 409);
            this.Controls.Add(this.pnlModuleContainer);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "PageContentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Page Content]";
            this.Activated += new System.EventHandler(this.PageContentForm_Activated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.Panel pnlModuleContainer;
        private System.Windows.Forms.ToolStripButton tsbInsertLink;
    }
}