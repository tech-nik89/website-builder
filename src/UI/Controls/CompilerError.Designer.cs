namespace WebsiteStudio.UI.Controls {
	partial class CompilerError {
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
			this.lvwErrors = new System.Windows.Forms.ListView();
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// lvwErrors
			// 
			this.lvwErrors.BackColor = System.Drawing.SystemColors.ControlLight;
			this.lvwErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnType,
            this.clnMessage});
			this.lvwErrors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwErrors.FullRowSelect = true;
			this.lvwErrors.HideSelection = false;
			this.lvwErrors.Location = new System.Drawing.Point(0, 0);
			this.lvwErrors.MultiSelect = false;
			this.lvwErrors.Name = "lvwErrors";
			this.lvwErrors.Size = new System.Drawing.Size(517, 301);
			this.lvwErrors.TabIndex = 0;
			this.lvwErrors.UseCompatibleStateImageBehavior = false;
			this.lvwErrors.View = System.Windows.Forms.View.Details;
			this.lvwErrors.VirtualMode = true;
			this.lvwErrors.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwErrors_RetrieveVirtualItem);
			// 
			// clnType
			// 
			this.clnType.Text = "[Type]";
			this.clnType.Width = 120;
			// 
			// clnMessage
			// 
			this.clnMessage.Text = "[Message]";
			this.clnMessage.Width = 320;
			// 
			// CompilerError
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwErrors);
			this.Name = "CompilerError";
			this.Size = new System.Drawing.Size(517, 301);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lvwErrors;
		private System.Windows.Forms.ColumnHeader clnType;
		private System.Windows.Forms.ColumnHeader clnMessage;
	}
}
