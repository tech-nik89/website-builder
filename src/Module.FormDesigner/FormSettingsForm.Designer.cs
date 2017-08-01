namespace WebsiteBuilder.Modules.FormDesigner {
	partial class FormSettingsForm {
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
			this.gbxTarget = new System.Windows.Forms.GroupBox();
			this.cbxService = new System.Windows.Forms.ComboBox();
			this.lblService = new System.Windows.Forms.Label();
			this.lblMail = new System.Windows.Forms.Label();
			this.txtTargetMailAddress = new System.Windows.Forms.TextBox();
			this.gbxButtons = new System.Windows.Forms.GroupBox();
			this.txtSubmitButtonText = new System.Windows.Forms.TextBox();
			this.lblSubmit = new System.Windows.Forms.Label();
			this.gbxTarget.SuspendLayout();
			this.gbxButtons.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(222, 206);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 0;
			this.btnAccept.Text = "[Accept]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(328, 206);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// gbxTarget
			// 
			this.gbxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxTarget.Controls.Add(this.txtTargetMailAddress);
			this.gbxTarget.Controls.Add(this.lblMail);
			this.gbxTarget.Controls.Add(this.lblService);
			this.gbxTarget.Controls.Add(this.cbxService);
			this.gbxTarget.Location = new System.Drawing.Point(12, 12);
			this.gbxTarget.Name = "gbxTarget";
			this.gbxTarget.Size = new System.Drawing.Size(416, 100);
			this.gbxTarget.TabIndex = 2;
			this.gbxTarget.TabStop = false;
			this.gbxTarget.Text = "[Target Service]";
			// 
			// cbxService
			// 
			this.cbxService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cbxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxService.FormattingEnabled = true;
			this.cbxService.Location = new System.Drawing.Point(95, 31);
			this.cbxService.Name = "cbxService";
			this.cbxService.Size = new System.Drawing.Size(295, 21);
			this.cbxService.TabIndex = 0;
			// 
			// lblService
			// 
			this.lblService.AutoSize = true;
			this.lblService.Location = new System.Drawing.Point(20, 34);
			this.lblService.Name = "lblService";
			this.lblService.Size = new System.Drawing.Size(49, 13);
			this.lblService.TabIndex = 1;
			this.lblService.Text = "[Service]";
			// 
			// lblMail
			// 
			this.lblMail.AutoSize = true;
			this.lblMail.Location = new System.Drawing.Point(20, 61);
			this.lblMail.Name = "lblMail";
			this.lblMail.Size = new System.Drawing.Size(32, 13);
			this.lblMail.TabIndex = 2;
			this.lblMail.Text = "[Mail]";
			// 
			// txtTargetMailAddress
			// 
			this.txtTargetMailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTargetMailAddress.Location = new System.Drawing.Point(95, 58);
			this.txtTargetMailAddress.Name = "txtTargetMailAddress";
			this.txtTargetMailAddress.Size = new System.Drawing.Size(295, 20);
			this.txtTargetMailAddress.TabIndex = 3;
			// 
			// gbxButtons
			// 
			this.gbxButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxButtons.Controls.Add(this.txtSubmitButtonText);
			this.gbxButtons.Controls.Add(this.lblSubmit);
			this.gbxButtons.Location = new System.Drawing.Point(12, 118);
			this.gbxButtons.Name = "gbxButtons";
			this.gbxButtons.Size = new System.Drawing.Size(416, 72);
			this.gbxButtons.TabIndex = 3;
			this.gbxButtons.TabStop = false;
			this.gbxButtons.Text = "[Buttons]";
			// 
			// txtSubmitButtonText
			// 
			this.txtSubmitButtonText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSubmitButtonText.Location = new System.Drawing.Point(95, 29);
			this.txtSubmitButtonText.Name = "txtSubmitButtonText";
			this.txtSubmitButtonText.Size = new System.Drawing.Size(295, 20);
			this.txtSubmitButtonText.TabIndex = 5;
			// 
			// lblSubmit
			// 
			this.lblSubmit.AutoSize = true;
			this.lblSubmit.Location = new System.Drawing.Point(20, 32);
			this.lblSubmit.Name = "lblSubmit";
			this.lblSubmit.Size = new System.Drawing.Size(45, 13);
			this.lblSubmit.TabIndex = 4;
			this.lblSubmit.Text = "[Submit]";
			// 
			// FormSettingsForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(440, 243);
			this.ControlBox = false;
			this.Controls.Add(this.gbxButtons);
			this.Controls.Add(this.gbxTarget);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormSettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Settings]";
			this.gbxTarget.ResumeLayout(false);
			this.gbxTarget.PerformLayout();
			this.gbxButtons.ResumeLayout(false);
			this.gbxButtons.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox gbxTarget;
		private System.Windows.Forms.TextBox txtTargetMailAddress;
		private System.Windows.Forms.Label lblMail;
		private System.Windows.Forms.Label lblService;
		private System.Windows.Forms.ComboBox cbxService;
		private System.Windows.Forms.GroupBox gbxButtons;
		private System.Windows.Forms.TextBox txtSubmitButtonText;
		private System.Windows.Forms.Label lblSubmit;
	}
}