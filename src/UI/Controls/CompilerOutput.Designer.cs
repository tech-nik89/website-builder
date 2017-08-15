namespace WebsiteStudio.UI.Controls {
	partial class CompilerOutput {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompilerOutput));
			this.tslMain = new System.Windows.Forms.ToolStrip();
			this.tsbClear = new System.Windows.Forms.ToolStripButton();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.tslMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tslMain
			// 
			this.tslMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tslMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClear});
			this.tslMain.Location = new System.Drawing.Point(0, 0);
			this.tslMain.Name = "tslMain";
			this.tslMain.Size = new System.Drawing.Size(694, 25);
			this.tslMain.TabIndex = 0;
			// 
			// tsbClear
			// 
			this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
			this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbClear.Name = "tsbClear";
			this.tsbClear.Size = new System.Drawing.Size(23, 22);
			this.tsbClear.Text = "[ClearAll]";
			this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtOutput.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtOutput.Location = new System.Drawing.Point(0, 25);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtOutput.Size = new System.Drawing.Size(694, 299);
			this.txtOutput.TabIndex = 1;
			// 
			// CompilerOutput
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 324);
			this.Controls.Add(this.txtOutput);
			this.Controls.Add(this.tslMain);
			this.Name = "CompilerOutput";
			this.tslMain.ResumeLayout(false);
			this.tslMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tslMain;
		private System.Windows.Forms.ToolStripButton tsbClear;
		private System.Windows.Forms.TextBox txtOutput;
	}
}
