namespace WebsiteStudio.UI.Controls {
	partial class PageContentList {
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
			this.clnContentType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnContentEditor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lvwContent = new System.Windows.Forms.ListView();
			this.SuspendLayout();
			// 
			// clnContentType
			// 
			this.clnContentType.Text = "[Type]";
			this.clnContentType.Width = 180;
			// 
			// clnContentEditor
			// 
			this.clnContentEditor.Text = "[Editor]";
			this.clnContentEditor.Width = 180;
			// 
			// lvwContent
			// 
			this.lvwContent.AllowDrop = true;
			this.lvwContent.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnContentType,
            this.clnContentEditor});
			this.lvwContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwContent.FullRowSelect = true;
			this.lvwContent.HideSelection = false;
			this.lvwContent.Location = new System.Drawing.Point(0, 0);
			this.lvwContent.MultiSelect = false;
			this.lvwContent.Name = "lvwContent";
			this.lvwContent.Size = new System.Drawing.Size(718, 388);
			this.lvwContent.TabIndex = 3;
			this.lvwContent.UseCompatibleStateImageBehavior = false;
			this.lvwContent.View = System.Windows.Forms.View.Details;
			this.lvwContent.VirtualMode = true;
			this.lvwContent.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwContent_RetrieveVirtualItem);
			this.lvwContent.SelectedIndexChanged += new System.EventHandler(this.lvwContent_SelectedIndexChanged);
			this.lvwContent.DoubleClick += new System.EventHandler(this.lvwContent_DoubleClick);
			// 
			// PageContentList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(718, 388);
			this.Controls.Add(this.lvwContent);
			this.Name = "PageContentList";
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ColumnHeader clnContentType;
		private System.Windows.Forms.ColumnHeader clnContentEditor;
		private System.Windows.Forms.ListView lvwContent;
	}
}
