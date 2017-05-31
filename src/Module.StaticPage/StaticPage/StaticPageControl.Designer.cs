namespace WebsiteBuilder.Modules.StaticPage {
    partial class StaticPageControl {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticPageControl));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbLink = new System.Windows.Forms.ToolStripButton();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLink});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(349, 25);
            this.tsMain.TabIndex = 0;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbLink
            // 
            this.tsbLink.Image = ((System.Drawing.Image)(resources.GetObject("tsbLink.Image")));
            this.tsbLink.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLink.Name = "tsbLink";
            this.tsbLink.Size = new System.Drawing.Size(86, 22);
            this.tsbLink.Text = "[InsertLink]";
            this.tsbLink.Click += new System.EventHandler(this.tsbLink_Click);
            // 
            // pnlEditor
            // 
            this.pnlEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEditor.Location = new System.Drawing.Point(0, 25);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(349, 207);
            this.pnlEditor.TabIndex = 1;
            // 
            // StaticPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlEditor);
            this.Controls.Add(this.tsMain);
            this.Name = "StaticPageControl";
            this.Size = new System.Drawing.Size(349, 232);
            this.Load += new System.EventHandler(this.StaticPageUserInterfaceControl_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLink;
        private System.Windows.Forms.Panel pnlEditor;
    }
}
