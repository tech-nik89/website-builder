namespace WebsiteStudio.Modules.Image {
	partial class StaticImageControl {
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
			this.btnID = new System.Windows.Forms.Button();
			this.txtID = new System.Windows.Forms.TextBox();
			this.lblID = new System.Windows.Forms.Label();
			this.txtAlternateText = new System.Windows.Forms.TextBox();
			this.lblAlternateText = new System.Windows.Forms.Label();
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.lblWidth = new System.Windows.Forms.Label();
			this.lblMaxWidth = new System.Windows.Forms.Label();
			this.numMaxWidth = new System.Windows.Forms.NumericUpDown();
			this.lblMaxHeight = new System.Windows.Forms.Label();
			this.numMaxHeight = new System.Windows.Forms.NumericUpDown();
			this.lblHeight = new System.Windows.Forms.Label();
			this.numHeight = new System.Windows.Forms.NumericUpDown();
			this.cbxWidth = new System.Windows.Forms.ComboBox();
			this.cbxMaxWidth = new System.Windows.Forms.ComboBox();
			this.cbxHeight = new System.Windows.Forms.ComboBox();
			this.cbxMaxHeight = new System.Windows.Forms.ComboBox();
			this.gbxGeneral = new System.Windows.Forms.GroupBox();
			this.gbxSize = new System.Windows.Forms.GroupBox();
			this.gbxOptions = new System.Windows.Forms.GroupBox();
			this.cbxAlignment = new System.Windows.Forms.ComboBox();
			this.lblAlignment = new System.Windows.Forms.Label();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabImage = new System.Windows.Forms.TabPage();
			this.tabLink = new System.Windows.Forms.TabPage();
			this.lblFooterTextExplanation = new System.Windows.Forms.Label();
			this.txtFooterText = new System.Windows.Forms.TextBox();
			this.lblFooterText = new System.Windows.Forms.Label();
			this.cbxLinkTarget = new System.Windows.Forms.ComboBox();
			this.lblLinkTarget = new System.Windows.Forms.Label();
			this.lblLink = new System.Windows.Forms.Label();
			this.txtLink = new System.Windows.Forms.TextBox();
			this.btnLinkBrowse = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
			this.gbxGeneral.SuspendLayout();
			this.gbxSize.SuspendLayout();
			this.gbxOptions.SuspendLayout();
			this.tabMain.SuspendLayout();
			this.tabImage.SuspendLayout();
			this.tabLink.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnID
			// 
			this.btnID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnID.Location = new System.Drawing.Point(415, 28);
			this.btnID.Name = "btnID";
			this.btnID.Size = new System.Drawing.Size(75, 23);
			this.btnID.TabIndex = 1;
			this.btnID.Text = "...";
			this.btnID.UseVisualStyleBackColor = true;
			this.btnID.Click += new System.EventHandler(this.btnID_Click);
			// 
			// txtID
			// 
			this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtID.Location = new System.Drawing.Point(127, 30);
			this.txtID.Name = "txtID";
			this.txtID.ReadOnly = true;
			this.txtID.Size = new System.Drawing.Size(282, 20);
			this.txtID.TabIndex = 4;
			// 
			// lblID
			// 
			this.lblID.AutoSize = true;
			this.lblID.Location = new System.Drawing.Point(23, 33);
			this.lblID.Name = "lblID";
			this.lblID.Size = new System.Drawing.Size(27, 13);
			this.lblID.TabIndex = 3;
			this.lblID.Text = "[ID:]";
			// 
			// txtAlternateText
			// 
			this.txtAlternateText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAlternateText.Location = new System.Drawing.Point(127, 56);
			this.txtAlternateText.Name = "txtAlternateText";
			this.txtAlternateText.Size = new System.Drawing.Size(363, 20);
			this.txtAlternateText.TabIndex = 2;
			this.txtAlternateText.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblAlternateText
			// 
			this.lblAlternateText.AutoSize = true;
			this.lblAlternateText.Location = new System.Drawing.Point(23, 59);
			this.lblAlternateText.Name = "lblAlternateText";
			this.lblAlternateText.Size = new System.Drawing.Size(79, 13);
			this.lblAlternateText.TabIndex = 6;
			this.lblAlternateText.Text = "[AlternateText:]";
			// 
			// numWidth
			// 
			this.numWidth.Location = new System.Drawing.Point(127, 35);
			this.numWidth.Name = "numWidth";
			this.numWidth.Size = new System.Drawing.Size(120, 20);
			this.numWidth.TabIndex = 3;
			this.numWidth.ValueChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblWidth
			// 
			this.lblWidth.AutoSize = true;
			this.lblWidth.Location = new System.Drawing.Point(23, 37);
			this.lblWidth.Name = "lblWidth";
			this.lblWidth.Size = new System.Drawing.Size(44, 13);
			this.lblWidth.TabIndex = 9;
			this.lblWidth.Text = "[Width:]";
			// 
			// lblMaxWidth
			// 
			this.lblMaxWidth.AutoSize = true;
			this.lblMaxWidth.Location = new System.Drawing.Point(23, 63);
			this.lblMaxWidth.Name = "lblMaxWidth";
			this.lblMaxWidth.Size = new System.Drawing.Size(64, 13);
			this.lblMaxWidth.TabIndex = 11;
			this.lblMaxWidth.Text = "[MaxWidth:]";
			// 
			// numMaxWidth
			// 
			this.numMaxWidth.Location = new System.Drawing.Point(127, 61);
			this.numMaxWidth.Name = "numMaxWidth";
			this.numMaxWidth.Size = new System.Drawing.Size(120, 20);
			this.numMaxWidth.TabIndex = 10;
			this.numMaxWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.numMaxWidth.ValueChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblMaxHeight
			// 
			this.lblMaxHeight.AutoSize = true;
			this.lblMaxHeight.Location = new System.Drawing.Point(23, 115);
			this.lblMaxHeight.Name = "lblMaxHeight";
			this.lblMaxHeight.Size = new System.Drawing.Size(67, 13);
			this.lblMaxHeight.TabIndex = 15;
			this.lblMaxHeight.Text = "[MaxHeight:]";
			// 
			// numMaxHeight
			// 
			this.numMaxHeight.Location = new System.Drawing.Point(127, 113);
			this.numMaxHeight.Name = "numMaxHeight";
			this.numMaxHeight.Size = new System.Drawing.Size(120, 20);
			this.numMaxHeight.TabIndex = 14;
			this.numMaxHeight.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.numMaxHeight.ValueChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblHeight
			// 
			this.lblHeight.AutoSize = true;
			this.lblHeight.Location = new System.Drawing.Point(23, 89);
			this.lblHeight.Name = "lblHeight";
			this.lblHeight.Size = new System.Drawing.Size(47, 13);
			this.lblHeight.TabIndex = 13;
			this.lblHeight.Text = "[Height:]";
			// 
			// numHeight
			// 
			this.numHeight.Location = new System.Drawing.Point(127, 87);
			this.numHeight.Name = "numHeight";
			this.numHeight.Size = new System.Drawing.Size(120, 20);
			this.numHeight.TabIndex = 12;
			this.numHeight.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
			this.numHeight.ValueChanged += new System.EventHandler(this.Control_Changed);
			// 
			// cbxWidth
			// 
			this.cbxWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxWidth.FormattingEnabled = true;
			this.cbxWidth.Location = new System.Drawing.Point(253, 34);
			this.cbxWidth.Name = "cbxWidth";
			this.cbxWidth.Size = new System.Drawing.Size(67, 21);
			this.cbxWidth.TabIndex = 16;
			this.cbxWidth.SelectedIndexChanged += new System.EventHandler(this.Control_Changed);
			// 
			// cbxMaxWidth
			// 
			this.cbxMaxWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaxWidth.FormattingEnabled = true;
			this.cbxMaxWidth.Location = new System.Drawing.Point(253, 60);
			this.cbxMaxWidth.Name = "cbxMaxWidth";
			this.cbxMaxWidth.Size = new System.Drawing.Size(67, 21);
			this.cbxMaxWidth.TabIndex = 17;
			this.cbxMaxWidth.CursorChanged += new System.EventHandler(this.Control_Changed);
			// 
			// cbxHeight
			// 
			this.cbxHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxHeight.FormattingEnabled = true;
			this.cbxHeight.Location = new System.Drawing.Point(253, 86);
			this.cbxHeight.Name = "cbxHeight";
			this.cbxHeight.Size = new System.Drawing.Size(67, 21);
			this.cbxHeight.TabIndex = 18;
			this.cbxHeight.CursorChanged += new System.EventHandler(this.Control_Changed);
			// 
			// cbxMaxHeight
			// 
			this.cbxMaxHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxMaxHeight.FormattingEnabled = true;
			this.cbxMaxHeight.Location = new System.Drawing.Point(253, 112);
			this.cbxMaxHeight.Name = "cbxMaxHeight";
			this.cbxMaxHeight.Size = new System.Drawing.Size(67, 21);
			this.cbxMaxHeight.TabIndex = 19;
			this.cbxMaxHeight.CursorChanged += new System.EventHandler(this.Control_Changed);
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.lblID);
			this.gbxGeneral.Controls.Add(this.txtID);
			this.gbxGeneral.Controls.Add(this.btnID);
			this.gbxGeneral.Controls.Add(this.lblAlternateText);
			this.gbxGeneral.Controls.Add(this.txtAlternateText);
			this.gbxGeneral.Location = new System.Drawing.Point(6, 6);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(539, 100);
			this.gbxGeneral.TabIndex = 20;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// gbxSize
			// 
			this.gbxSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxSize.Controls.Add(this.lblWidth);
			this.gbxSize.Controls.Add(this.numWidth);
			this.gbxSize.Controls.Add(this.cbxMaxHeight);
			this.gbxSize.Controls.Add(this.numMaxWidth);
			this.gbxSize.Controls.Add(this.cbxHeight);
			this.gbxSize.Controls.Add(this.lblMaxWidth);
			this.gbxSize.Controls.Add(this.cbxMaxWidth);
			this.gbxSize.Controls.Add(this.numHeight);
			this.gbxSize.Controls.Add(this.cbxWidth);
			this.gbxSize.Controls.Add(this.lblHeight);
			this.gbxSize.Controls.Add(this.lblMaxHeight);
			this.gbxSize.Controls.Add(this.numMaxHeight);
			this.gbxSize.Location = new System.Drawing.Point(6, 112);
			this.gbxSize.Name = "gbxSize";
			this.gbxSize.Size = new System.Drawing.Size(539, 163);
			this.gbxSize.TabIndex = 21;
			this.gbxSize.TabStop = false;
			this.gbxSize.Text = "[Size]";
			// 
			// gbxOptions
			// 
			this.gbxOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxOptions.Controls.Add(this.cbxAlignment);
			this.gbxOptions.Controls.Add(this.lblAlignment);
			this.gbxOptions.Location = new System.Drawing.Point(6, 281);
			this.gbxOptions.Name = "gbxOptions";
			this.gbxOptions.Size = new System.Drawing.Size(539, 82);
			this.gbxOptions.TabIndex = 22;
			this.gbxOptions.TabStop = false;
			this.gbxOptions.Text = "[Options]";
			// 
			// cbxAlignment
			// 
			this.cbxAlignment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxAlignment.FormattingEnabled = true;
			this.cbxAlignment.Location = new System.Drawing.Point(127, 35);
			this.cbxAlignment.Name = "cbxAlignment";
			this.cbxAlignment.Size = new System.Drawing.Size(193, 21);
			this.cbxAlignment.TabIndex = 11;
			// 
			// lblAlignment
			// 
			this.lblAlignment.AutoSize = true;
			this.lblAlignment.Location = new System.Drawing.Point(23, 38);
			this.lblAlignment.Name = "lblAlignment";
			this.lblAlignment.Size = new System.Drawing.Size(62, 13);
			this.lblAlignment.TabIndex = 10;
			this.lblAlignment.Text = "[Alignment:]";
			// 
			// tabMain
			// 
			this.tabMain.Controls.Add(this.tabImage);
			this.tabMain.Controls.Add(this.tabLink);
			this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMain.Location = new System.Drawing.Point(0, 0);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(559, 401);
			this.tabMain.TabIndex = 23;
			// 
			// tabImage
			// 
			this.tabImage.Controls.Add(this.gbxGeneral);
			this.tabImage.Controls.Add(this.gbxOptions);
			this.tabImage.Controls.Add(this.gbxSize);
			this.tabImage.Location = new System.Drawing.Point(4, 22);
			this.tabImage.Name = "tabImage";
			this.tabImage.Padding = new System.Windows.Forms.Padding(3);
			this.tabImage.Size = new System.Drawing.Size(551, 375);
			this.tabImage.TabIndex = 0;
			this.tabImage.Text = "[Image]";
			this.tabImage.UseVisualStyleBackColor = true;
			// 
			// tabLink
			// 
			this.tabLink.Controls.Add(this.lblFooterTextExplanation);
			this.tabLink.Controls.Add(this.txtFooterText);
			this.tabLink.Controls.Add(this.lblFooterText);
			this.tabLink.Controls.Add(this.cbxLinkTarget);
			this.tabLink.Controls.Add(this.lblLinkTarget);
			this.tabLink.Controls.Add(this.lblLink);
			this.tabLink.Controls.Add(this.txtLink);
			this.tabLink.Controls.Add(this.btnLinkBrowse);
			this.tabLink.Location = new System.Drawing.Point(4, 22);
			this.tabLink.Name = "tabLink";
			this.tabLink.Padding = new System.Windows.Forms.Padding(3);
			this.tabLink.Size = new System.Drawing.Size(551, 375);
			this.tabLink.TabIndex = 1;
			this.tabLink.Text = "[Link]";
			this.tabLink.UseVisualStyleBackColor = true;
			// 
			// lblFooterTextExplanation
			// 
			this.lblFooterTextExplanation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblFooterTextExplanation.Location = new System.Drawing.Point(130, 122);
			this.lblFooterTextExplanation.Name = "lblFooterTextExplanation";
			this.lblFooterTextExplanation.Size = new System.Drawing.Size(366, 53);
			this.lblFooterTextExplanation.TabIndex = 12;
			this.lblFooterTextExplanation.Text = "[Explanation]";
			// 
			// txtFooterText
			// 
			this.txtFooterText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFooterText.Location = new System.Drawing.Point(133, 89);
			this.txtFooterText.Name = "txtFooterText";
			this.txtFooterText.Size = new System.Drawing.Size(363, 20);
			this.txtFooterText.TabIndex = 11;
			// 
			// lblFooterText
			// 
			this.lblFooterText.AutoSize = true;
			this.lblFooterText.Location = new System.Drawing.Point(29, 92);
			this.lblFooterText.Name = "lblFooterText";
			this.lblFooterText.Size = new System.Drawing.Size(67, 13);
			this.lblFooterText.TabIndex = 10;
			this.lblFooterText.Text = "[FooterText:]";
			// 
			// cbxLinkTarget
			// 
			this.cbxLinkTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxLinkTarget.FormattingEnabled = true;
			this.cbxLinkTarget.Items.AddRange(new object[] {
            "_blank",
            "_self",
            "_parent",
            "_top"});
			this.cbxLinkTarget.Location = new System.Drawing.Point(133, 62);
			this.cbxLinkTarget.Name = "cbxLinkTarget";
			this.cbxLinkTarget.Size = new System.Drawing.Size(363, 21);
			this.cbxLinkTarget.TabIndex = 8;
			this.cbxLinkTarget.SelectedIndexChanged += new System.EventHandler(this.Control_Changed);
			// 
			// lblLinkTarget
			// 
			this.lblLinkTarget.AutoSize = true;
			this.lblLinkTarget.Location = new System.Drawing.Point(29, 65);
			this.lblLinkTarget.Name = "lblLinkTarget";
			this.lblLinkTarget.Size = new System.Drawing.Size(47, 13);
			this.lblLinkTarget.TabIndex = 9;
			this.lblLinkTarget.Text = "[Target:]";
			// 
			// lblLink
			// 
			this.lblLink.AutoSize = true;
			this.lblLink.Location = new System.Drawing.Point(29, 39);
			this.lblLink.Name = "lblLink";
			this.lblLink.Size = new System.Drawing.Size(36, 13);
			this.lblLink.TabIndex = 6;
			this.lblLink.Text = "[Link:]";
			// 
			// txtLink
			// 
			this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLink.Location = new System.Drawing.Point(133, 36);
			this.txtLink.Name = "txtLink";
			this.txtLink.Size = new System.Drawing.Size(282, 20);
			this.txtLink.TabIndex = 7;
			this.txtLink.TextChanged += new System.EventHandler(this.Control_Changed);
			// 
			// btnLinkBrowse
			// 
			this.btnLinkBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnLinkBrowse.Location = new System.Drawing.Point(421, 34);
			this.btnLinkBrowse.Name = "btnLinkBrowse";
			this.btnLinkBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnLinkBrowse.TabIndex = 5;
			this.btnLinkBrowse.Text = "...";
			this.btnLinkBrowse.UseVisualStyleBackColor = true;
			this.btnLinkBrowse.Click += new System.EventHandler(this.btnLinkBrowse_Click);
			// 
			// StaticImageControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.tabMain);
			this.Name = "StaticImageControl";
			this.Size = new System.Drawing.Size(559, 401);
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxWidth)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxHeight)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.gbxSize.ResumeLayout(false);
			this.gbxSize.PerformLayout();
			this.gbxOptions.ResumeLayout(false);
			this.gbxOptions.PerformLayout();
			this.tabMain.ResumeLayout(false);
			this.tabImage.ResumeLayout(false);
			this.tabLink.ResumeLayout(false);
			this.tabLink.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnID;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.Label lblID;
		private System.Windows.Forms.TextBox txtAlternateText;
		private System.Windows.Forms.Label lblAlternateText;
		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label lblWidth;
		private System.Windows.Forms.Label lblMaxWidth;
		private System.Windows.Forms.NumericUpDown numMaxWidth;
		private System.Windows.Forms.Label lblMaxHeight;
		private System.Windows.Forms.NumericUpDown numMaxHeight;
		private System.Windows.Forms.Label lblHeight;
		private System.Windows.Forms.NumericUpDown numHeight;
		private System.Windows.Forms.ComboBox cbxWidth;
		private System.Windows.Forms.ComboBox cbxMaxWidth;
		private System.Windows.Forms.ComboBox cbxHeight;
		private System.Windows.Forms.ComboBox cbxMaxHeight;
		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.GroupBox gbxSize;
		private System.Windows.Forms.GroupBox gbxOptions;
		private System.Windows.Forms.ComboBox cbxAlignment;
		private System.Windows.Forms.Label lblAlignment;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabImage;
		private System.Windows.Forms.TabPage tabLink;
		private System.Windows.Forms.Label lblLink;
		private System.Windows.Forms.TextBox txtLink;
		private System.Windows.Forms.Button btnLinkBrowse;
		private System.Windows.Forms.ComboBox cbxLinkTarget;
		private System.Windows.Forms.Label lblLinkTarget;
		private System.Windows.Forms.TextBox txtFooterText;
		private System.Windows.Forms.Label lblFooterText;
		private System.Windows.Forms.Label lblFooterTextExplanation;
	}
}
