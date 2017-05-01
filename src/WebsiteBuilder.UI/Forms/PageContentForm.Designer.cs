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
            this.tsbSaveAndClose = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMediaLink = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.pnlModuleContainer = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveAndClose,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbMediaLink,
            this.tsbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSaveAndClose
            // 
            this.tsbSaveAndClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAndClose.Image")));
            this.tsbSaveAndClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAndClose.Name = "tsbSaveAndClose";
            this.tsbSaveAndClose.Size = new System.Drawing.Size(112, 22);
            this.tsbSaveAndClose.Text = "[Save and close]";
            this.tsbSaveAndClose.Click += new System.EventHandler(this.tsbSaveAndClose_Click);
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
            // tsbMediaLink
            // 
            this.tsbMediaLink.Image = ((System.Drawing.Image)(resources.GetObject("tsbMediaLink.Image")));
            this.tsbMediaLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMediaLink.Name = "tsbMediaLink";
            this.tsbMediaLink.Size = new System.Drawing.Size(89, 22);
            this.tsbMediaLink.Text = "{Insert Link]";
            this.tsbMediaLink.Click += new System.EventHandler(this.tsbMediaLink_Click);
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
            // PageContentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 409);
            this.Controls.Add(this.pnlModuleContainer);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "PageContentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "[Page Content]";
            this.Shown += new System.EventHandler(this.PageContentForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSaveAndClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.Panel pnlModuleContainer;
        private System.Windows.Forms.ToolStripButton tsbMediaLink;
        private System.Windows.Forms.ToolStripButton tsbSave;
    }
}