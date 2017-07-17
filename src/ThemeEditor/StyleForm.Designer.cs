namespace ThemeEditor {
	partial class StyleForm {
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
			this.cbxType = new System.Windows.Forms.ComboBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblType = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.gbxStyle = new System.Windows.Forms.GroupBox();
			this.txtData = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.gbxGeneral.SuspendLayout();
			this.gbxStyle.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.cbxType);
			this.gbxGeneral.Controls.Add(this.txtName);
			this.gbxGeneral.Controls.Add(this.lblType);
			this.gbxGeneral.Controls.Add(this.lblName);
			this.gbxGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(629, 98);
			this.gbxGeneral.TabIndex = 0;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// cbxType
			// 
			this.cbxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxType.FormattingEnabled = true;
			this.cbxType.Location = new System.Drawing.Point(103, 54);
			this.cbxType.Name = "cbxType";
			this.cbxType.Size = new System.Drawing.Size(499, 21);
			this.cbxType.TabIndex = 3;
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(103, 28);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(499, 20);
			this.txtName.TabIndex = 2;
			// 
			// lblType
			// 
			this.lblType.AutoSize = true;
			this.lblType.Location = new System.Drawing.Point(23, 57);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(37, 13);
			this.lblType.TabIndex = 1;
			this.lblType.Text = "[Type]";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(23, 31);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "[Name]";
			// 
			// gbxStyle
			// 
			this.gbxStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxStyle.Controls.Add(this.txtData);
			this.gbxStyle.Location = new System.Drawing.Point(12, 116);
			this.gbxStyle.Name = "gbxStyle";
			this.gbxStyle.Size = new System.Drawing.Size(629, 231);
			this.gbxStyle.TabIndex = 1;
			this.gbxStyle.TabStop = false;
			this.gbxStyle.Text = "[Style]";
			// 
			// txtData
			// 
			this.txtData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtData.Location = new System.Drawing.Point(6, 19);
			this.txtData.Multiline = true;
			this.txtData.Name = "txtData";
			this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtData.Size = new System.Drawing.Size(617, 206);
			this.txtData.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(541, 353);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(435, 353);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// StyleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(653, 390);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxStyle);
			this.Controls.Add(this.gbxGeneral);
			this.MinimizeBox = false;
			this.Name = "StyleForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Style]";
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.gbxStyle.ResumeLayout(false);
			this.gbxStyle.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.ComboBox cbxType;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.GroupBox gbxStyle;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
	}
}