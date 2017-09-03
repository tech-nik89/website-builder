namespace WebsiteStudio.UI.Forms {
	partial class UpdateForm {
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
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.lblVersionAvailable = new System.Windows.Forms.Label();
			this.lblVersionCurrent = new System.Windows.Forms.Label();
			this.lblVersionAvailableCaption = new System.Windows.Forms.Label();
			this.lblVersionCurrentCaption = new System.Windows.Forms.Label();
			this.lblMessage = new System.Windows.Forms.Label();
			this.gbxReleaseNotes = new System.Windows.Forms.GroupBox();
			this.txtReleaseNotes = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDownload = new System.Windows.Forms.Button();
			this.pgDownload = new System.Windows.Forms.ProgressBar();
			this.gbxGeneral.SuspendLayout();
			this.gbxReleaseNotes.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.lblVersionAvailable);
			this.gbxGeneral.Controls.Add(this.lblVersionCurrent);
			this.gbxGeneral.Controls.Add(this.lblVersionAvailableCaption);
			this.gbxGeneral.Controls.Add(this.lblVersionCurrentCaption);
			this.gbxGeneral.Controls.Add(this.lblMessage);
			this.gbxGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(560, 101);
			this.gbxGeneral.TabIndex = 0;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// lblVersionAvailable
			// 
			this.lblVersionAvailable.AutoSize = true;
			this.lblVersionAvailable.Location = new System.Drawing.Point(133, 70);
			this.lblVersionAvailable.Name = "lblVersionAvailable";
			this.lblVersionAvailable.Size = new System.Drawing.Size(10, 13);
			this.lblVersionAvailable.TabIndex = 5;
			this.lblVersionAvailable.Text = "-";
			// 
			// lblVersionCurrent
			// 
			this.lblVersionCurrent.AutoSize = true;
			this.lblVersionCurrent.Location = new System.Drawing.Point(133, 47);
			this.lblVersionCurrent.Name = "lblVersionCurrent";
			this.lblVersionCurrent.Size = new System.Drawing.Size(10, 13);
			this.lblVersionCurrent.TabIndex = 4;
			this.lblVersionCurrent.Text = "-";
			// 
			// lblVersionAvailableCaption
			// 
			this.lblVersionAvailableCaption.AutoSize = true;
			this.lblVersionAvailableCaption.Location = new System.Drawing.Point(19, 70);
			this.lblVersionAvailableCaption.Name = "lblVersionAvailableCaption";
			this.lblVersionAvailableCaption.Size = new System.Drawing.Size(94, 13);
			this.lblVersionAvailableCaption.TabIndex = 3;
			this.lblVersionAvailableCaption.Text = "[AvailableVersion:]";
			// 
			// lblVersionCurrentCaption
			// 
			this.lblVersionCurrentCaption.AutoSize = true;
			this.lblVersionCurrentCaption.Location = new System.Drawing.Point(19, 47);
			this.lblVersionCurrentCaption.Name = "lblVersionCurrentCaption";
			this.lblVersionCurrentCaption.Size = new System.Drawing.Size(73, 13);
			this.lblVersionCurrentCaption.TabIndex = 2;
			this.lblVersionCurrentCaption.Text = "[YourVersion:]";
			// 
			// lblMessage
			// 
			this.lblMessage.AutoSize = true;
			this.lblMessage.Location = new System.Drawing.Point(19, 25);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(56, 13);
			this.lblMessage.TabIndex = 1;
			this.lblMessage.Text = "[Message]";
			// 
			// gbxReleaseNotes
			// 
			this.gbxReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxReleaseNotes.Controls.Add(this.txtReleaseNotes);
			this.gbxReleaseNotes.Location = new System.Drawing.Point(12, 119);
			this.gbxReleaseNotes.Name = "gbxReleaseNotes";
			this.gbxReleaseNotes.Size = new System.Drawing.Size(560, 299);
			this.gbxReleaseNotes.TabIndex = 2;
			this.gbxReleaseNotes.TabStop = false;
			this.gbxReleaseNotes.Text = "[ReleaseNotes]";
			// 
			// txtReleaseNotes
			// 
			this.txtReleaseNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReleaseNotes.Location = new System.Drawing.Point(22, 29);
			this.txtReleaseNotes.Multiline = true;
			this.txtReleaseNotes.Name = "txtReleaseNotes";
			this.txtReleaseNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtReleaseNotes.Size = new System.Drawing.Size(517, 249);
			this.txtReleaseNotes.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(472, 424);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(100, 25);
			this.btnClose.TabIndex = 3;
			this.btnClose.Text = "[Close]";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDownload
			// 
			this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDownload.Location = new System.Drawing.Point(282, 424);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(184, 25);
			this.btnDownload.TabIndex = 4;
			this.btnDownload.Text = "[DownloadNow]";
			this.btnDownload.UseVisualStyleBackColor = true;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// pgDownload
			// 
			this.pgDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pgDownload.Location = new System.Drawing.Point(12, 424);
			this.pgDownload.Name = "pgDownload";
			this.pgDownload.Size = new System.Drawing.Size(264, 25);
			this.pgDownload.TabIndex = 5;
			// 
			// UpdateForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 461);
			this.ControlBox = false;
			this.Controls.Add(this.pgDownload);
			this.Controls.Add(this.btnDownload);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.gbxReleaseNotes);
			this.Controls.Add(this.gbxGeneral);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "UpdateForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Update]";
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.gbxReleaseNotes.ResumeLayout(false);
			this.gbxReleaseNotes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.Label lblVersionAvailable;
		private System.Windows.Forms.Label lblVersionCurrent;
		private System.Windows.Forms.Label lblVersionAvailableCaption;
		private System.Windows.Forms.Label lblVersionCurrentCaption;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.GroupBox gbxReleaseNotes;
		private System.Windows.Forms.TextBox txtReleaseNotes;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.ProgressBar pgDownload;
	}
}