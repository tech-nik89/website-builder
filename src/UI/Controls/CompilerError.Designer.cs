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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerError));
			this.lvwErrors = new System.Windows.Forms.ListView();
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbError = new System.Windows.Forms.ToolStripButton();
			this.tsbWarning = new System.Windows.Forms.ToolStripButton();
			this.tsbInfo = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwErrors
			// 
			this.lvwErrors.BackColor = System.Drawing.SystemColors.Control;
			this.lvwErrors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnType,
            this.clnMessage});
			this.lvwErrors.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwErrors.FullRowSelect = true;
			this.lvwErrors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwErrors.HideSelection = false;
			this.lvwErrors.Location = new System.Drawing.Point(0, 25);
			this.lvwErrors.MultiSelect = false;
			this.lvwErrors.Name = "lvwErrors";
			this.lvwErrors.Size = new System.Drawing.Size(501, 238);
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
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbError,
            this.toolStripSeparator1,
            this.tsbWarning,
            this.toolStripSeparator2,
            this.tsbInfo});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(501, 25);
			this.tsMain.TabIndex = 1;
			// 
			// tsbError
			// 
			this.tsbError.Image = ((System.Drawing.Image)(resources.GetObject("tsbError.Image")));
			this.tsbError.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbError.Name = "tsbError";
			this.tsbError.Size = new System.Drawing.Size(60, 22);
			this.tsbError.Text = "[Error]";
			this.tsbError.Click += new System.EventHandler(this.tsbFilter_Click);
			// 
			// tsbWarning
			// 
			this.tsbWarning.Image = ((System.Drawing.Image)(resources.GetObject("tsbWarning.Image")));
			this.tsbWarning.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbWarning.Name = "tsbWarning";
			this.tsbWarning.Size = new System.Drawing.Size(80, 22);
			this.tsbWarning.Text = "[Warning]";
			this.tsbWarning.Click += new System.EventHandler(this.tsbFilter_Click);
			// 
			// tsbInfo
			// 
			this.tsbInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsbInfo.Image")));
			this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbInfo.Name = "tsbInfo";
			this.tsbInfo.Size = new System.Drawing.Size(56, 22);
			this.tsbInfo.Text = "[Info]";
			this.tsbInfo.Click += new System.EventHandler(this.tsbFilter_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// CompilerError
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(501, 263);
			this.Controls.Add(this.lvwErrors);
			this.Controls.Add(this.tsMain);
			this.Name = "CompilerError";
			this.Resize += new System.EventHandler(this.CompilerError_Resize);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwErrors;
		private System.Windows.Forms.ColumnHeader clnType;
		private System.Windows.Forms.ColumnHeader clnMessage;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbError;
		private System.Windows.Forms.ToolStripButton tsbWarning;
		private System.Windows.Forms.ToolStripButton tsbInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
	}
}
