namespace WebsiteStudio.Editors.TinyMCE {
	partial class ImageForm {
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
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnBrowseURL = new System.Windows.Forms.Button();
			this.txtTooltip = new System.Windows.Forms.TextBox();
			this.lblTooltip = new System.Windows.Forms.Label();
			this.txtAlternativeText = new System.Windows.Forms.TextBox();
			this.lblAlternativeText = new System.Windows.Forms.Label();
			this.txtURL = new System.Windows.Forms.TextBox();
			this.lblURL = new System.Windows.Forms.Label();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.tabSize = new System.Windows.Forms.TabPage();
			this.lblWidth = new System.Windows.Forms.Label();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.lblHeight = new System.Windows.Forms.Label();
			this.chkKeepRatio = new System.Windows.Forms.CheckBox();
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabSize.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(186, 154);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 8;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(292, 154);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnBrowseURL
			// 
			this.btnBrowseURL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseURL.Location = new System.Drawing.Point(309, 17);
			this.btnBrowseURL.Name = "btnBrowseURL";
			this.btnBrowseURL.Size = new System.Drawing.Size(39, 20);
			this.btnBrowseURL.TabIndex = 12;
			this.btnBrowseURL.Text = "...";
			this.btnBrowseURL.UseVisualStyleBackColor = true;
			this.btnBrowseURL.Click += new System.EventHandler(this.btnBrowseURL_Click);
			// 
			// txtTooltip
			// 
			this.txtTooltip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTooltip.Location = new System.Drawing.Point(138, 69);
			this.txtTooltip.Name = "txtTooltip";
			this.txtTooltip.Size = new System.Drawing.Size(210, 20);
			this.txtTooltip.TabIndex = 15;
			// 
			// lblTooltip
			// 
			this.lblTooltip.AutoSize = true;
			this.lblTooltip.Location = new System.Drawing.Point(19, 72);
			this.lblTooltip.Name = "lblTooltip";
			this.lblTooltip.Size = new System.Drawing.Size(48, 13);
			this.lblTooltip.TabIndex = 16;
			this.lblTooltip.Text = "[Tooltip:]";
			// 
			// txtAlternativeText
			// 
			this.txtAlternativeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAlternativeText.Location = new System.Drawing.Point(138, 43);
			this.txtAlternativeText.Name = "txtAlternativeText";
			this.txtAlternativeText.Size = new System.Drawing.Size(210, 20);
			this.txtAlternativeText.TabIndex = 14;
			// 
			// lblAlternativeText
			// 
			this.lblAlternativeText.AutoSize = true;
			this.lblAlternativeText.Location = new System.Drawing.Point(19, 46);
			this.lblAlternativeText.Name = "lblAlternativeText";
			this.lblAlternativeText.Size = new System.Drawing.Size(87, 13);
			this.lblAlternativeText.TabIndex = 13;
			this.lblAlternativeText.Text = "[AlternativeText:]";
			// 
			// txtURL
			// 
			this.txtURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtURL.Location = new System.Drawing.Point(138, 17);
			this.txtURL.Name = "txtURL";
			this.txtURL.Size = new System.Drawing.Size(165, 20);
			this.txtURL.TabIndex = 11;
			// 
			// lblURL
			// 
			this.lblURL.AutoSize = true;
			this.lblURL.Location = new System.Drawing.Point(19, 20);
			this.lblURL.Name = "lblURL";
			this.lblURL.Size = new System.Drawing.Size(38, 13);
			this.lblURL.TabIndex = 10;
			this.lblURL.Text = "[URL:]";
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Controls.Add(this.tabSize);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(380, 136);
			this.tabMain.TabIndex = 17;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.lblURL);
			this.tabGeneral.Controls.Add(this.btnBrowseURL);
			this.tabGeneral.Controls.Add(this.txtURL);
			this.tabGeneral.Controls.Add(this.txtTooltip);
			this.tabGeneral.Controls.Add(this.lblAlternativeText);
			this.tabGeneral.Controls.Add(this.lblTooltip);
			this.tabGeneral.Controls.Add(this.txtAlternativeText);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(372, 110);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "[General]";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// tabSize
			// 
			this.tabSize.Controls.Add(this.chkKeepRatio);
			this.tabSize.Controls.Add(this.numHeight);
			this.tabSize.Controls.Add(this.lblHeight);
			this.tabSize.Controls.Add(this.numWidth);
			this.tabSize.Controls.Add(this.lblWidth);
			this.tabSize.Location = new System.Drawing.Point(4, 22);
			this.tabSize.Name = "tabSize";
			this.tabSize.Padding = new System.Windows.Forms.Padding(3);
			this.tabSize.Size = new System.Drawing.Size(372, 110);
			this.tabSize.TabIndex = 1;
			this.tabSize.Text = "[Size]";
			this.tabSize.UseVisualStyleBackColor = true;
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(19, 20);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(44, 13);
			this.lblWidth.TabIndex = 11;
			this.lblWidth.Text = "[Width:]";
			// 
			// numWidth
			// 
			this.numWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numWidth.Location = new System.Drawing.Point(137, 18);
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(210, 20);
			this.numWidth.TabIndex = 12;
			this.numWidth.ValueChanged += new System.EventHandler(this.numWidth_ValueChanged);
			// 
			// numHeight
			// 
			this.numHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numHeight.Location = new System.Drawing.Point(137, 44);
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(210, 20);
			this.numHeight.TabIndex = 14;
			this.numHeight.ValueChanged += new System.EventHandler(this.numHeight_ValueChanged);
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(19, 46);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(47, 13);
			this.lblHeight.TabIndex = 13;
			this.lblHeight.Text = "[Height:]";
			// 
			// chkKeepRatio
			// 
			this.chkKeepRatio.AutoSize = true;
			this.chkKeepRatio.Location = new System.Drawing.Point(137, 70);
			this.chkKeepRatio.Name = "chkKeepRatio";
			this.chkKeepRatio.Size = new System.Drawing.Size(82, 17);
			this.chkKeepRatio.TabIndex = 15;
			this.chkKeepRatio.Text = "[KeepRatio]";
			this.chkKeepRatio.UseVisualStyleBackColor = true;
			this.chkKeepRatio.CheckedChanged += new System.EventHandler(this.chkKeepRatio_CheckedChanged);
			// 
			// ImageForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(404, 191);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.MinimizeBox = false;
			this.Name = "ImageForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Image]";
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabSize.ResumeLayout(false);
			this.tabSize.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnBrowseURL;
		private System.Windows.Forms.TextBox txtTooltip;
		private System.Windows.Forms.Label lblTooltip;
		private System.Windows.Forms.TextBox txtAlternativeText;
		private System.Windows.Forms.Label lblAlternativeText;
		private System.Windows.Forms.TextBox txtURL;
		private System.Windows.Forms.Label lblURL;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabSize;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.CheckBox chkKeepRatio;
	}
}