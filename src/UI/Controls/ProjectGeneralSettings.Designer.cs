namespace WebsiteStudio.UI.Controls
{
    partial class ProjectGeneralSettings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
        private void InitializeComponent()
        {
			this.gbxOutput = new System.Windows.Forms.GroupBox();
			this.btnOutputBrowse = new System.Windows.Forms.Button();
			this.txtOutputPath = new System.Windows.Forms.TextBox();
			this.lblOutputPath = new System.Windows.Forms.Label();
			this.chkUglyURLs = new System.Windows.Forms.CheckBox();
			this.gbxTheme = new System.Windows.Forms.GroupBox();
			this.pbxFavicon = new System.Windows.Forms.PictureBox();
			this.btnFavicon = new System.Windows.Forms.Button();
			this.lblFavicon = new System.Windows.Forms.Label();
			this.btnThemeBrowse = new System.Windows.Forms.Button();
			this.txtThemePath = new System.Windows.Forms.TextBox();
			this.lblThemePath = new System.Windows.Forms.Label();
			this.ofdFile = new System.Windows.Forms.OpenFileDialog();
			this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
			this.gbxWebserver = new System.Windows.Forms.GroupBox();
			this.cbxWebserver = new System.Windows.Forms.ComboBox();
			this.chkGenerateSitemap = new System.Windows.Forms.CheckBox();
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.lblSSLRedirect = new System.Windows.Forms.Label();
			this.chkSSLRedirect = new System.Windows.Forms.CheckBox();
			this.lblGenerateSitemap = new System.Windows.Forms.Label();
			this.lblUglyURLs = new System.Windows.Forms.Label();
			this.txtBaseURL = new System.Windows.Forms.TextBox();
			this.lblBaseURL = new System.Windows.Forms.Label();
			this.txtLocalRootPath = new System.Windows.Forms.TextBox();
			this.lblLocalRootPath = new System.Windows.Forms.Label();
			this.gbxOutput.SuspendLayout();
			this.gbxTheme.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxFavicon)).BeginInit();
			this.gbxWebserver.SuspendLayout();
			this.gbxGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxOutput
			// 
			this.gbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxOutput.Controls.Add(this.btnOutputBrowse);
			this.gbxOutput.Controls.Add(this.txtOutputPath);
			this.gbxOutput.Controls.Add(this.lblOutputPath);
			this.gbxOutput.Location = new System.Drawing.Point(3, 160);
			this.gbxOutput.Name = "gbxOutput";
			this.gbxOutput.Size = new System.Drawing.Size(600, 57);
			this.gbxOutput.TabIndex = 0;
			this.gbxOutput.TabStop = false;
			this.gbxOutput.Text = "[Output directory]";
			// 
			// btnOutputBrowse
			// 
			this.btnOutputBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOutputBrowse.Location = new System.Drawing.Point(531, 21);
			this.btnOutputBrowse.Name = "btnOutputBrowse";
			this.btnOutputBrowse.Size = new System.Drawing.Size(40, 23);
			this.btnOutputBrowse.TabIndex = 6;
			this.btnOutputBrowse.Text = "...";
			this.btnOutputBrowse.UseVisualStyleBackColor = true;
			this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
			// 
			// txtOutputPath
			// 
			this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtOutputPath.Location = new System.Drawing.Point(131, 23);
			this.txtOutputPath.Name = "txtOutputPath";
			this.txtOutputPath.Size = new System.Drawing.Size(394, 20);
			this.txtOutputPath.TabIndex = 5;
			// 
			// lblOutputPath
			// 
			this.lblOutputPath.AutoSize = true;
			this.lblOutputPath.Location = new System.Drawing.Point(18, 26);
			this.lblOutputPath.Name = "lblOutputPath";
			this.lblOutputPath.Size = new System.Drawing.Size(38, 13);
			this.lblOutputPath.TabIndex = 0;
			this.lblOutputPath.Text = "[Path:]";
			// 
			// chkUglyURLs
			// 
			this.chkUglyURLs.AutoSize = true;
			this.chkUglyURLs.Location = new System.Drawing.Point(131, 75);
			this.chkUglyURLs.Name = "chkUglyURLs";
			this.chkUglyURLs.Size = new System.Drawing.Size(65, 17);
			this.chkUglyURLs.TabIndex = 2;
			this.chkUglyURLs.Text = "[Enable]";
			this.chkUglyURLs.UseVisualStyleBackColor = true;
			// 
			// gbxTheme
			// 
			this.gbxTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxTheme.Controls.Add(this.pbxFavicon);
			this.gbxTheme.Controls.Add(this.btnFavicon);
			this.gbxTheme.Controls.Add(this.lblFavicon);
			this.gbxTheme.Controls.Add(this.btnThemeBrowse);
			this.gbxTheme.Controls.Add(this.txtThemePath);
			this.gbxTheme.Controls.Add(this.lblThemePath);
			this.gbxTheme.Location = new System.Drawing.Point(3, 223);
			this.gbxTheme.Name = "gbxTheme";
			this.gbxTheme.Size = new System.Drawing.Size(600, 81);
			this.gbxTheme.TabIndex = 3;
			this.gbxTheme.TabStop = false;
			this.gbxTheme.Text = "[Theme]";
			// 
			// pbxFavicon
			// 
			this.pbxFavicon.Location = new System.Drawing.Point(212, 51);
			this.pbxFavicon.Name = "pbxFavicon";
			this.pbxFavicon.Size = new System.Drawing.Size(16, 16);
			this.pbxFavicon.TabIndex = 10;
			this.pbxFavicon.TabStop = false;
			// 
			// btnFavicon
			// 
			this.btnFavicon.Location = new System.Drawing.Point(131, 46);
			this.btnFavicon.Name = "btnFavicon";
			this.btnFavicon.Size = new System.Drawing.Size(75, 23);
			this.btnFavicon.TabIndex = 9;
			this.btnFavicon.Text = "...";
			this.btnFavicon.UseVisualStyleBackColor = true;
			this.btnFavicon.Click += new System.EventHandler(this.btnFavicon_Click);
			// 
			// lblFavicon
			// 
			this.lblFavicon.AutoSize = true;
			this.lblFavicon.Location = new System.Drawing.Point(18, 51);
			this.lblFavicon.Name = "lblFavicon";
			this.lblFavicon.Size = new System.Drawing.Size(54, 13);
			this.lblFavicon.TabIndex = 8;
			this.lblFavicon.Text = "[Favicon:]";
			// 
			// btnThemeBrowse
			// 
			this.btnThemeBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnThemeBrowse.Location = new System.Drawing.Point(531, 18);
			this.btnThemeBrowse.Name = "btnThemeBrowse";
			this.btnThemeBrowse.Size = new System.Drawing.Size(40, 23);
			this.btnThemeBrowse.TabIndex = 8;
			this.btnThemeBrowse.Text = "...";
			this.btnThemeBrowse.UseVisualStyleBackColor = true;
			this.btnThemeBrowse.Click += new System.EventHandler(this.btnThemeBrowse_Click);
			// 
			// txtThemePath
			// 
			this.txtThemePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtThemePath.Location = new System.Drawing.Point(131, 20);
			this.txtThemePath.Name = "txtThemePath";
			this.txtThemePath.Size = new System.Drawing.Size(394, 20);
			this.txtThemePath.TabIndex = 7;
			// 
			// lblThemePath
			// 
			this.lblThemePath.AutoSize = true;
			this.lblThemePath.Location = new System.Drawing.Point(18, 23);
			this.lblThemePath.Name = "lblThemePath";
			this.lblThemePath.Size = new System.Drawing.Size(38, 13);
			this.lblThemePath.TabIndex = 0;
			this.lblThemePath.Text = "[Path:]";
			// 
			// gbxWebserver
			// 
			this.gbxWebserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxWebserver.Controls.Add(this.cbxWebserver);
			this.gbxWebserver.Location = new System.Drawing.Point(3, 310);
			this.gbxWebserver.Name = "gbxWebserver";
			this.gbxWebserver.Size = new System.Drawing.Size(600, 54);
			this.gbxWebserver.TabIndex = 4;
			this.gbxWebserver.TabStop = false;
			this.gbxWebserver.Text = "[Webserver]";
			// 
			// cbxWebserver
			// 
			this.cbxWebserver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxWebserver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWebserver.FormattingEnabled = true;
			this.cbxWebserver.Location = new System.Drawing.Point(21, 19);
			this.cbxWebserver.Name = "cbxWebserver";
			this.cbxWebserver.Size = new System.Drawing.Size(550, 21);
			this.cbxWebserver.TabIndex = 10;
			// 
			// chkGenerateSitemap
			// 
			this.chkGenerateSitemap.AutoSize = true;
			this.chkGenerateSitemap.Location = new System.Drawing.Point(131, 98);
			this.chkGenerateSitemap.Name = "chkGenerateSitemap";
			this.chkGenerateSitemap.Size = new System.Drawing.Size(65, 17);
			this.chkGenerateSitemap.TabIndex = 3;
			this.chkGenerateSitemap.Text = "[Enable]";
			this.chkGenerateSitemap.UseVisualStyleBackColor = true;
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.txtLocalRootPath);
			this.gbxGeneral.Controls.Add(this.lblLocalRootPath);
			this.gbxGeneral.Controls.Add(this.lblSSLRedirect);
			this.gbxGeneral.Controls.Add(this.chkSSLRedirect);
			this.gbxGeneral.Controls.Add(this.lblGenerateSitemap);
			this.gbxGeneral.Controls.Add(this.lblUglyURLs);
			this.gbxGeneral.Controls.Add(this.chkGenerateSitemap);
			this.gbxGeneral.Controls.Add(this.txtBaseURL);
			this.gbxGeneral.Controls.Add(this.chkUglyURLs);
			this.gbxGeneral.Controls.Add(this.lblBaseURL);
			this.gbxGeneral.Location = new System.Drawing.Point(3, 3);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(600, 151);
			this.gbxGeneral.TabIndex = 5;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// lblSSLRedirect
			// 
			this.lblSSLRedirect.AutoSize = true;
			this.lblSSLRedirect.Location = new System.Drawing.Point(18, 122);
			this.lblSSLRedirect.Name = "lblSSLRedirect";
			this.lblSSLRedirect.Size = new System.Drawing.Size(76, 13);
			this.lblSSLRedirect.TabIndex = 8;
			this.lblSSLRedirect.Text = "[SSLRedirect:]";
			// 
			// chkSSLRedirect
			// 
			this.chkSSLRedirect.AutoSize = true;
			this.chkSSLRedirect.Location = new System.Drawing.Point(131, 121);
			this.chkSSLRedirect.Name = "chkSSLRedirect";
			this.chkSSLRedirect.Size = new System.Drawing.Size(65, 17);
			this.chkSSLRedirect.TabIndex = 4;
			this.chkSSLRedirect.Text = "[Enable]";
			this.chkSSLRedirect.UseVisualStyleBackColor = true;
			// 
			// lblGenerateSitemap
			// 
			this.lblGenerateSitemap.AutoSize = true;
			this.lblGenerateSitemap.Location = new System.Drawing.Point(18, 99);
			this.lblGenerateSitemap.Name = "lblGenerateSitemap";
			this.lblGenerateSitemap.Size = new System.Drawing.Size(98, 13);
			this.lblGenerateSitemap.TabIndex = 6;
			this.lblGenerateSitemap.Text = "[GenerateSitemap:]";
			// 
			// lblUglyURLs
			// 
			this.lblUglyURLs.AutoSize = true;
			this.lblUglyURLs.Location = new System.Drawing.Point(18, 76);
			this.lblUglyURLs.Name = "lblUglyURLs";
			this.lblUglyURLs.Size = new System.Drawing.Size(64, 13);
			this.lblUglyURLs.TabIndex = 5;
			this.lblUglyURLs.Text = "[UglyURLs:]";
			// 
			// txtBaseURL
			// 
			this.txtBaseURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtBaseURL.Location = new System.Drawing.Point(131, 23);
			this.txtBaseURL.Name = "txtBaseURL";
			this.txtBaseURL.Size = new System.Drawing.Size(440, 20);
			this.txtBaseURL.TabIndex = 0;
			this.txtBaseURL.TextChanged += new System.EventHandler(this.txtBaseURL_TextChanged);
			// 
			// lblBaseURL
			// 
			this.lblBaseURL.AutoSize = true;
			this.lblBaseURL.Location = new System.Drawing.Point(18, 26);
			this.lblBaseURL.Name = "lblBaseURL";
			this.lblBaseURL.Size = new System.Drawing.Size(62, 13);
			this.lblBaseURL.TabIndex = 0;
			this.lblBaseURL.Text = "[BaseURL:]";
			// 
			// txtLocalRootPath
			// 
			this.txtLocalRootPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLocalRootPath.Location = new System.Drawing.Point(131, 49);
			this.txtLocalRootPath.Name = "txtLocalRootPath";
			this.txtLocalRootPath.Size = new System.Drawing.Size(440, 20);
			this.txtLocalRootPath.TabIndex = 1;
			// 
			// lblLocalRootPath
			// 
			this.lblLocalRootPath.AutoSize = true;
			this.lblLocalRootPath.Location = new System.Drawing.Point(18, 52);
			this.lblLocalRootPath.Name = "lblLocalRootPath";
			this.lblLocalRootPath.Size = new System.Drawing.Size(87, 13);
			this.lblLocalRootPath.TabIndex = 10;
			this.lblLocalRootPath.Text = "[LocalRootPath:]";
			// 
			// ProjectGeneralSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.gbxGeneral);
			this.Controls.Add(this.gbxWebserver);
			this.Controls.Add(this.gbxTheme);
			this.Controls.Add(this.gbxOutput);
			this.Name = "ProjectGeneralSettings";
			this.Size = new System.Drawing.Size(606, 403);
			this.gbxOutput.ResumeLayout(false);
			this.gbxOutput.PerformLayout();
			this.gbxTheme.ResumeLayout(false);
			this.gbxTheme.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbxFavicon)).EndInit();
			this.gbxWebserver.ResumeLayout(false);
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxOutput;
        private System.Windows.Forms.Button btnOutputBrowse;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.GroupBox gbxTheme;
        private System.Windows.Forms.Button btnThemeBrowse;
        private System.Windows.Forms.TextBox txtThemePath;
        private System.Windows.Forms.Label lblThemePath;
        private System.Windows.Forms.OpenFileDialog ofdFile;
        private System.Windows.Forms.FolderBrowserDialog fbdDirectory;
        private System.Windows.Forms.CheckBox chkUglyURLs;
		private System.Windows.Forms.GroupBox gbxWebserver;
		private System.Windows.Forms.ComboBox cbxWebserver;
		private System.Windows.Forms.CheckBox chkGenerateSitemap;
		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.TextBox txtBaseURL;
		private System.Windows.Forms.Label lblBaseURL;
		private System.Windows.Forms.Label lblGenerateSitemap;
		private System.Windows.Forms.Label lblUglyURLs;
		private System.Windows.Forms.Label lblSSLRedirect;
		private System.Windows.Forms.CheckBox chkSSLRedirect;
		private System.Windows.Forms.Button btnFavicon;
		private System.Windows.Forms.Label lblFavicon;
		private System.Windows.Forms.PictureBox pbxFavicon;
		private System.Windows.Forms.TextBox txtLocalRootPath;
		private System.Windows.Forms.Label lblLocalRootPath;
	}
}
