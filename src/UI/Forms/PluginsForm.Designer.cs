namespace WebsiteStudio.UI.Forms {
	partial class PluginsForm {
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
			this.lvwPlugins = new System.Windows.Forms.ListView();
			this.clnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tslDoubleClickForDetails = new System.Windows.Forms.ToolStripLabel();
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwPlugins
			// 
			this.lvwPlugins.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnName,
            this.clnVersion,
            this.clnAuthor});
			this.lvwPlugins.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwPlugins.FullRowSelect = true;
			this.lvwPlugins.GridLines = true;
			this.lvwPlugins.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvwPlugins.HideSelection = false;
			this.lvwPlugins.Location = new System.Drawing.Point(0, 25);
			this.lvwPlugins.Name = "lvwPlugins";
			this.lvwPlugins.Size = new System.Drawing.Size(557, 365);
			this.lvwPlugins.TabIndex = 0;
			this.lvwPlugins.UseCompatibleStateImageBehavior = false;
			this.lvwPlugins.View = System.Windows.Forms.View.Details;
			this.lvwPlugins.DoubleClick += new System.EventHandler(this.lvwPlugins_DoubleClick);
			// 
			// clnName
			// 
			this.clnName.Text = "[Name]";
			this.clnName.Width = 200;
			// 
			// clnVersion
			// 
			this.clnVersion.Text = "[Version]";
			this.clnVersion.Width = 100;
			// 
			// clnAuthor
			// 
			this.clnAuthor.Text = "[Author]";
			this.clnAuthor.Width = 140;
			// 
			// tsMain
			// 
			this.tsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslDoubleClickForDetails});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(557, 25);
			this.tsMain.TabIndex = 1;
			// 
			// tslDoubleClickForDetails
			// 
			this.tslDoubleClickForDetails.Name = "tslDoubleClickForDetails";
			this.tslDoubleClickForDetails.Size = new System.Drawing.Size(38, 22);
			this.tslDoubleClickForDetails.Text = "[Hint]";
			// 
			// PluginsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(557, 390);
			this.Controls.Add(this.lvwPlugins);
			this.Controls.Add(this.tsMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(500, 230);
			this.Name = "PluginsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Plugins]";
			this.Load += new System.EventHandler(this.PluginsForm_Load);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView lvwPlugins;
		private System.Windows.Forms.ColumnHeader clnName;
		private System.Windows.Forms.ColumnHeader clnVersion;
		private System.Windows.Forms.ColumnHeader clnAuthor;
		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripLabel tslDoubleClickForDetails;
	}
}