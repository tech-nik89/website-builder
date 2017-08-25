namespace WebsiteStudio.Editors.TinyMCE {
	partial class LinkForm {
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
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.btnBrowseURL = new System.Windows.Forms.Button();
			this.txtTooltip = new System.Windows.Forms.TextBox();
			this.lblTooltip = new System.Windows.Forms.Label();
			this.txtDisplayText = new System.Windows.Forms.TextBox();
			this.lblDisplayText = new System.Windows.Forms.Label();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lblURL = new System.Windows.Forms.Label();
			this.tabOptions = new System.Windows.Forms.TabPage();
			this.cbxTarget = new System.Windows.Forms.ComboBox();
			this.lblTarget = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabOptions.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Controls.Add(this.tabOptions);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(395, 151);
			this.tabMain.TabIndex = 0;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.btnBrowseURL);
			this.tabGeneral.Controls.Add(this.txtTooltip);
			this.tabGeneral.Controls.Add(this.lblTooltip);
			this.tabGeneral.Controls.Add(this.txtDisplayText);
			this.tabGeneral.Controls.Add(this.lblDisplayText);
			this.tabGeneral.Controls.Add(this.txtURL);
			this.tabGeneral.Controls.Add(this.lblURL);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(387, 125);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "[General]";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// btnBrowseURL
			// 
			this.btnBrowseURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseURL.Location = new System.Drawing.Point(319, 21);
			this.btnBrowseURL.Name = "btnBrowseURL";
			this.btnBrowseURL.Size = new System.Drawing.Size(39, 20);
			this.btnBrowseURL.TabIndex = 2;
			this.btnBrowseURL.Text = "...";
			this.btnBrowseURL.UseVisualStyleBackColor = true;
			this.btnBrowseURL.Click += new System.EventHandler(this.btnBrowseURL_Click);
			// 
			// txtTooltip
			// 
			this.txtTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTooltip.Location = new System.Drawing.Point(139, 73);
			this.txtTooltip.Name = "txtTooltip";
			this.txtTooltip.Size = new System.Drawing.Size(219, 20);
			this.txtTooltip.TabIndex = 4;
			// 
			// lblTooltip
			// 
			this.lblTooltip.AutoSize = true;
			this.lblTooltip.Location = new System.Drawing.Point(20, 76);
			this.lblTooltip.Name = "lblTooltip";
			this.lblTooltip.Size = new System.Drawing.Size(48, 13);
			this.lblTooltip.TabIndex = 4;
			this.lblTooltip.Text = "[Tooltip:]";
			// 
			// txtDisplayText
			// 
			this.txtDisplayText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDisplayText.Location = new System.Drawing.Point(139, 47);
			this.txtDisplayText.Name = "txtDisplayText";
			this.txtDisplayText.Size = new System.Drawing.Size(219, 20);
			this.txtDisplayText.TabIndex = 3;
			// 
			// lblDisplayText
			// 
			this.lblDisplayText.AutoSize = true;
			this.lblDisplayText.Location = new System.Drawing.Point(20, 50);
			this.lblDisplayText.Name = "lblDisplayText";
			this.lblDisplayText.Size = new System.Drawing.Size(84, 13);
			this.lblDisplayText.TabIndex = 2;
			this.lblDisplayText.Text = "[TextToDisplay:]";
			// 
			// txtURL
			// 
			this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtURL.Location = new System.Drawing.Point(139, 21);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(174, 20);
			this.txtURL.TabIndex = 1;
			// 
			// lblURL
			// 
			this.lblURL.AutoSize = true;
			this.lblURL.Location = new System.Drawing.Point(20, 24);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(38, 13);
			this.lblURL.TabIndex = 0;
			this.lblURL.Text = "[URL:]";
			// 
			// tabOptions
			// 
			this.tabOptions.Controls.Add(this.cbxTarget);
			this.tabOptions.Controls.Add(this.lblTarget);
			this.tabOptions.Location = new System.Drawing.Point(4, 22);
			this.tabOptions.Name = "tabOptions";
			this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
			this.tabOptions.Size = new System.Drawing.Size(387, 125);
			this.tabOptions.TabIndex = 1;
			this.tabOptions.Text = "[Options]";
			this.tabOptions.UseVisualStyleBackColor = true;
			// 
			// cbxTarget
			// 
			this.cbxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxTarget.FormattingEnabled = true;
			this.cbxTarget.Items.AddRange(new object[] {
            "_blank",
            "_self",
            "_parent",
            "_top"});
			this.cbxTarget.Location = new System.Drawing.Point(139, 21);
			this.cbxTarget.Name = "cbxTarget";
			this.cbxTarget.Size = new System.Drawing.Size(219, 21);
			this.cbxTarget.TabIndex = 5;
			// 
			// lblTarget
			// 
			this.lblTarget.AutoSize = true;
			this.lblTarget.Location = new System.Drawing.Point(20, 24);
			this.lblTarget.Name = "lblTarget";
			this.lblTarget.Size = new System.Drawing.Size(47, 13);
			this.lblTarget.TabIndex = 6;
			this.lblTarget.Text = "[Target:]";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(303, 169);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(197, 169);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 6;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// LinkForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(419, 206);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tabMain);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(435, 245);
			this.Name = "LinkForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Link]";
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabOptions.ResumeLayout(false);
			this.tabOptions.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabOptions;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnBrowseURL;
		private System.Windows.Forms.TextBox txtTooltip;
		private System.Windows.Forms.Label lblTooltip;
		private System.Windows.Forms.TextBox txtDisplayText;
		private System.Windows.Forms.Label lblDisplayText;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lblURL;
		private System.Windows.Forms.ComboBox cbxTarget;
		private System.Windows.Forms.Label lblTarget;
	}
}