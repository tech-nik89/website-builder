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
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.tabMemberships = new System.Windows.Forms.TabPage();
			this.lvwGroups = new System.Windows.Forms.ListView();
			this.clnGroup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabMemberships.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPassword
			// 
			this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPassword.Font = new System.Drawing.Font("Wingdings", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
			this.txtPassword.Location = new System.Drawing.Point(112, 51);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = 'l';
			this.txtPassword.Size = new System.Drawing.Size(221, 20);
			this.txtPassword.TabIndex = 1;
			// 
			// lblPassword
			// 
			this.lblPassword.AutoSize = true;
			this.lblPassword.Location = new System.Drawing.Point(21, 54);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(59, 13);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "[Password]";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(112, 24);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(221, 20);
			this.txtName.TabIndex = 0;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(21, 27);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "[Name]";
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(166, 204);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 2;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(272, 204);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabGeneral);
			this.tabMain.Controls.Add(this.tabMemberships);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(360, 186);
			this.tabMain.TabIndex = 4;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.txtName);
			this.tabGeneral.Controls.Add(this.txtPassword);
			this.tabGeneral.Controls.Add(this.lblName);
			this.tabGeneral.Controls.Add(this.lblPassword);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(352, 160);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "[General]";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// tabMemberships
			// 
			this.tabMemberships.Controls.Add(this.lvwGroups);
			this.tabMemberships.Location = new System.Drawing.Point(4, 22);
			this.tabMemberships.Name = "tabMemberships";
			this.tabMemberships.Padding = new System.Windows.Forms.Padding(3);
			this.tabMemberships.Size = new System.Drawing.Size(352, 163);
			this.tabMemberships.TabIndex = 1;
			this.tabMemberships.Text = "[Memberships]";
			this.tabMemberships.UseVisualStyleBackColor = true;
			// 
			// lvwGroups
			// 
			this.lvwGroups.CheckBoxes = true;
			this.lvwGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnGroup});
			this.lvwGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwGroups.FullRowSelect = true;
			this.lvwGroups.GridLines = true;
			this.lvwGroups.Location = new System.Drawing.Point(3, 3);
			this.lvwGroups.Name = "lvwGroups";
			this.lvwGroups.Size = new System.Drawing.Size(346, 157);
			this.lvwGroups.TabIndex = 0;
			this.lvwGroups.UseCompatibleStateImageBehavior = false;
			this.lvwGroups.View = System.Windows.Forms.View.Details;
			// 
			// clnGroup
			// 
			this.clnGroup.Text = "[Group]";
			this.clnGroup.Width = 240;
			// 
			// UserForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 241);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 280);
			this.Name = "UserForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserForm";
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabMemberships.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabMemberships;
		private System.Windows.Forms.ListView lvwGroups;
		private System.Windows.Forms.ColumnHeader clnGroup;
	}
}