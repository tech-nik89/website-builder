namespace WebsiteBuilder.UI.Controls
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
            this.chkUglyURLs = new System.Windows.Forms.CheckBox();
            this.btnOutputBrowse = new System.Windows.Forms.Button();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.gbxTheme = new System.Windows.Forms.GroupBox();
            this.btnThemeBrowse = new System.Windows.Forms.Button();
            this.txtThemePath = new System.Windows.Forms.TextBox();
            this.lblThemePath = new System.Windows.Forms.Label();
            this.ofdFile = new System.Windows.Forms.OpenFileDialog();
            this.fbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.gbxOutput.SuspendLayout();
            this.gbxTheme.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxOutput
            // 
            this.gbxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxOutput.Controls.Add(this.chkUglyURLs);
            this.gbxOutput.Controls.Add(this.btnOutputBrowse);
            this.gbxOutput.Controls.Add(this.txtOutputPath);
            this.gbxOutput.Controls.Add(this.lblOutputPath);
            this.gbxOutput.Location = new System.Drawing.Point(3, 3);
            this.gbxOutput.Name = "gbxOutput";
            this.gbxOutput.Size = new System.Drawing.Size(421, 104);
            this.gbxOutput.TabIndex = 0;
            this.gbxOutput.TabStop = false;
            this.gbxOutput.Text = "[Output directory]";
            // 
            // chkUglyURLs
            // 
            this.chkUglyURLs.AutoSize = true;
            this.chkUglyURLs.Location = new System.Drawing.Point(71, 64);
            this.chkUglyURLs.Name = "chkUglyURLs";
            this.chkUglyURLs.Size = new System.Drawing.Size(83, 17);
            this.chkUglyURLs.TabIndex = 3;
            this.chkUglyURLs.Text = "[Ugly URLs]";
            this.chkUglyURLs.UseVisualStyleBackColor = true;
            // 
            // btnOutputBrowse
            // 
            this.btnOutputBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOutputBrowse.Location = new System.Drawing.Point(352, 27);
            this.btnOutputBrowse.Name = "btnOutputBrowse";
            this.btnOutputBrowse.Size = new System.Drawing.Size(40, 23);
            this.btnOutputBrowse.TabIndex = 2;
            this.btnOutputBrowse.Text = "...";
            this.btnOutputBrowse.UseVisualStyleBackColor = true;
            this.btnOutputBrowse.Click += new System.EventHandler(this.btnOutputBrowse_Click);
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputPath.Location = new System.Drawing.Point(71, 29);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(275, 20);
            this.txtOutputPath.TabIndex = 1;
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(18, 32);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(38, 13);
            this.lblOutputPath.TabIndex = 0;
            this.lblOutputPath.Text = "[Path:]";
            // 
            // gbxTheme
            // 
            this.gbxTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTheme.Controls.Add(this.btnThemeBrowse);
            this.gbxTheme.Controls.Add(this.txtThemePath);
            this.gbxTheme.Controls.Add(this.lblThemePath);
            this.gbxTheme.Location = new System.Drawing.Point(3, 113);
            this.gbxTheme.Name = "gbxTheme";
            this.gbxTheme.Size = new System.Drawing.Size(421, 73);
            this.gbxTheme.TabIndex = 3;
            this.gbxTheme.TabStop = false;
            this.gbxTheme.Text = "[Theme]";
            // 
            // btnThemeBrowse
            // 
            this.btnThemeBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemeBrowse.Location = new System.Drawing.Point(352, 27);
            this.btnThemeBrowse.Name = "btnThemeBrowse";
            this.btnThemeBrowse.Size = new System.Drawing.Size(40, 23);
            this.btnThemeBrowse.TabIndex = 2;
            this.btnThemeBrowse.Text = "...";
            this.btnThemeBrowse.UseVisualStyleBackColor = true;
            this.btnThemeBrowse.Click += new System.EventHandler(this.btnThemeBrowse_Click);
            // 
            // txtThemePath
            // 
            this.txtThemePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtThemePath.Location = new System.Drawing.Point(71, 29);
            this.txtThemePath.Name = "txtThemePath";
            this.txtThemePath.Size = new System.Drawing.Size(275, 20);
            this.txtThemePath.TabIndex = 1;
            // 
            // lblThemePath
            // 
            this.lblThemePath.AutoSize = true;
            this.lblThemePath.Location = new System.Drawing.Point(18, 32);
            this.lblThemePath.Name = "lblThemePath";
            this.lblThemePath.Size = new System.Drawing.Size(38, 13);
            this.lblThemePath.TabIndex = 0;
            this.lblThemePath.Text = "[Path:]";
            // 
            // ProjectGeneralSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxTheme);
            this.Controls.Add(this.gbxOutput);
            this.Name = "ProjectGeneralSettings";
            this.Size = new System.Drawing.Size(427, 223);
            this.gbxOutput.ResumeLayout(false);
            this.gbxOutput.PerformLayout();
            this.gbxTheme.ResumeLayout(false);
            this.gbxTheme.PerformLayout();
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
    }
}
