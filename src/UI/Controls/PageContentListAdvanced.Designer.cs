namespace WebsiteStudio.UI.Controls {
	partial class PageContentListAdvanced {
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
			this.wbContent = new System.Windows.Forms.WebBrowser();
			this.SuspendLayout();
			// 
			// wbContent
			// 
			this.wbContent.AllowWebBrowserDrop = false;
			this.wbContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.wbContent.IsWebBrowserContextMenuEnabled = false;
			this.wbContent.Location = new System.Drawing.Point(0, 0);
			this.wbContent.MinimumSize = new System.Drawing.Size(20, 20);
			this.wbContent.Name = "wbContent";
			this.wbContent.Size = new System.Drawing.Size(630, 462);
			this.wbContent.TabIndex = 0;
			this.wbContent.WebBrowserShortcutsEnabled = false;
			this.wbContent.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.wbContent_PreviewKeyDown);
			// 
			// PageContentListAdvanced
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 462);
			this.Controls.Add(this.wbContent);
			this.Name = "PageContentListAdvanced";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.WebBrowser wbContent;
	}
}
