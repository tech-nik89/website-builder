namespace WebsiteStudio.UI.Forms {
	partial class UserForm {
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
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbxGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxGeneral
			// 
			this.gbxGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxGeneral.Controls.Add(this.txtPassword);
			this.gbxGeneral.Controls.Add(this.lblPassword);
			this.gbxGeneral.Controls.Add(this.txtName);
			this.gbxGeneral.Controls.Add(this.lblName);
			this.gbxGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbxGeneral.Name = "gbxGeneral";
			this.gbxGeneral.Size = new System.Drawing.Size(413, 100);
			this.gbxGeneral.TabIndex = 0;
			this.gbxGeneral.TabStop = false;
			this.gbxGeneral.Text = "[General]";
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.txtPassword.Location = new System.Drawing.Point(113, 56);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = 'l';
			this.txtPassword.Size = new System.Drawing.Size(274, 20);
			this.txtPassword.TabIndex = 3;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(22, 59);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(59, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "[Password]";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(113, 29);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(274, 20);
			this.txtName.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(22, 32);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "[Name]";
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(219, 122);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 1;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(325, 122);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// UserForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(437, 159);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.gbxGeneral);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "UserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserForm";
			this.gbxGeneral.ResumeLayout(false);
			this.gbxGeneral.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxGeneral;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
	}
}