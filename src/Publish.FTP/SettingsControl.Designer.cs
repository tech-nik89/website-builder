namespace WebsiteBuilder.Publish.FTP {
	partial class SettingsControl {
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
			this.gbxServer = new System.Windows.Forms.GroupBox();
			this.cbxEncryption = new System.Windows.Forms.ComboBox();
			this.lblEncryption = new System.Windows.Forms.Label();
			this.numPort = new System.Windows.Forms.NumericUpDown();
			this.lblPort = new System.Windows.Forms.Label();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.lblHost = new System.Windows.Forms.Label();
			this.gbxCredentials = new System.Windows.Forms.GroupBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.lblUserName = new System.Windows.Forms.Label();
			this.gbxServer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
			this.gbxCredentials.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxServer
			// 
			this.gbxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxServer.Controls.Add(this.cbxEncryption);
			this.gbxServer.Controls.Add(this.lblEncryption);
			this.gbxServer.Controls.Add(this.numPort);
			this.gbxServer.Controls.Add(this.lblPort);
			this.gbxServer.Controls.Add(this.txtHost);
			this.gbxServer.Controls.Add(this.lblHost);
			this.gbxServer.Location = new System.Drawing.Point(3, 3);
			this.gbxServer.Name = "gbxServer";
			this.gbxServer.Size = new System.Drawing.Size(473, 133);
			this.gbxServer.TabIndex = 0;
			this.gbxServer.TabStop = false;
			this.gbxServer.Text = "[Server]";
			// 
			// cbxEncryption
			// 
			this.cbxEncryption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxEncryption.FormattingEnabled = true;
			this.cbxEncryption.Location = new System.Drawing.Point(115, 84);
			this.cbxEncryption.Name = "cbxEncryption";
			this.cbxEncryption.Size = new System.Drawing.Size(156, 21);
			this.cbxEncryption.TabIndex = 5;
			// 
			// lblEncryption
			// 
			this.lblEncryption.AutoSize = true;
			this.lblEncryption.Location = new System.Drawing.Point(19, 87);
			this.lblEncryption.Name = "lblEncryption";
			this.lblEncryption.Size = new System.Drawing.Size(63, 13);
			this.lblEncryption.TabIndex = 4;
			this.lblEncryption.Text = "[Encryption]";
			// 
			// numPort
			// 
			this.numPort.Location = new System.Drawing.Point(115, 58);
			this.numPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
			this.numPort.Name = "numPort";
			this.numPort.Size = new System.Drawing.Size(156, 20);
			this.numPort.TabIndex = 3;
			// 
			// lblPort
			// 
			this.lblPort.AutoSize = true;
			this.lblPort.Location = new System.Drawing.Point(19, 60);
			this.lblPort.Name = "lblPort";
			this.lblPort.Size = new System.Drawing.Size(32, 13);
			this.lblPort.TabIndex = 2;
			this.lblPort.Text = "[Port]";
			// 
			// txtHost
			// 
			this.txtHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtHost.Location = new System.Drawing.Point(115, 32);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(327, 20);
			this.txtHost.TabIndex = 1;
			// 
			// lblHost
			// 
			this.lblHost.AutoSize = true;
			this.lblHost.Location = new System.Drawing.Point(19, 35);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(35, 13);
			this.lblHost.TabIndex = 0;
			this.lblHost.Text = "[Host]";
			// 
			// gbxCredentials
			// 
			this.gbxCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxCredentials.Controls.Add(this.txtPassword);
			this.gbxCredentials.Controls.Add(this.lblPassword);
			this.gbxCredentials.Controls.Add(this.txtUserName);
			this.gbxCredentials.Controls.Add(this.lblUserName);
			this.gbxCredentials.Location = new System.Drawing.Point(3, 142);
			this.gbxCredentials.Name = "gbxCredentials";
			this.gbxCredentials.Size = new System.Drawing.Size(473, 100);
			this.gbxCredentials.TabIndex = 1;
			this.gbxCredentials.TabStop = false;
			this.gbxCredentials.Text = "[Credentials]";
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.txtPassword.Location = new System.Drawing.Point(115, 55);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = 'l';
			this.txtPassword.Size = new System.Drawing.Size(327, 20);
			this.txtPassword.TabIndex = 5;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(19, 58);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(59, 13);
			this.lblPassword.TabIndex = 4;
			this.lblPassword.Text = "[Password]";
			// 
			// txtUserName
			// 
			this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUserName.Location = new System.Drawing.Point(115, 29);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(327, 20);
			this.txtUserName.TabIndex = 3;
			// 
			// lblUserName
			// 
			this.lblUserName.AutoSize = true;
			this.lblUserName.Location = new System.Drawing.Point(19, 32);
			this.lblUserName.Name = "lblUserName";
			this.lblUserName.Size = new System.Drawing.Size(63, 13);
			this.lblUserName.TabIndex = 2;
			this.lblUserName.Text = "[UserName]";
			// 
			// SettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbxCredentials);
			this.Controls.Add(this.gbxServer);
			this.Name = "SettingsControl";
			this.Size = new System.Drawing.Size(479, 327);
			this.gbxServer.ResumeLayout(false);
			this.gbxServer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
			this.gbxCredentials.ResumeLayout(false);
			this.gbxCredentials.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxServer;
		private System.Windows.Forms.NumericUpDown numPort;
		private System.Windows.Forms.Label lblPort;
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.ComboBox cbxEncryption;
		private System.Windows.Forms.Label lblEncryption;
		private System.Windows.Forms.GroupBox gbxCredentials;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.Label lblUserName;
	}
}
