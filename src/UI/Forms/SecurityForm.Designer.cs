namespace WebsiteStudio.UI.Forms {
	partial class SecurityForm {
		/// <summary> 
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Komponenten-Designer generierter Code

		/// <summary> 
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent() {
			this.lvwUsers = new System.Windows.Forms.ListView();
			this.clnUserName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnUserDelete = new System.Windows.Forms.Button();
			this.btnUserEdit = new System.Windows.Forms.Button();
			this.btnUserAdd = new System.Windows.Forms.Button();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGroups = new System.Windows.Forms.TabPage();
			this.btnGroupDelete = new System.Windows.Forms.Button();
			this.btnGroupAdd = new System.Windows.Forms.Button();
			this.btnGroupEdit = new System.Windows.Forms.Button();
			this.lvwGroups = new System.Windows.Forms.ListView();
			this.clnGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabUsers = new System.Windows.Forms.TabPage();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabMain.SuspendLayout();
			this.tabGroups.SuspendLayout();
			this.tabUsers.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvwUsers
			// 
			this.lvwUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnUserName});
			this.lvwUsers.FullRowSelect = true;
			this.lvwUsers.GridLines = true;
			this.lvwUsers.HideSelection = false;
			this.lvwUsers.Location = new System.Drawing.Point(0, 0);
			this.lvwUsers.Name = "lvwUsers";
			this.lvwUsers.Size = new System.Drawing.Size(540, 297);
			this.lvwUsers.TabIndex = 4;
			this.lvwUsers.UseCompatibleStateImageBehavior = false;
			this.lvwUsers.View = System.Windows.Forms.View.Details;
			this.lvwUsers.VirtualMode = true;
			this.lvwUsers.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwItems_RetrieveVirtualItem);
			this.lvwUsers.SelectedIndexChanged += new System.EventHandler(this.lvwUsers_SelectedIndexChanged);
			this.lvwUsers.DoubleClick += new System.EventHandler(this.btnUserEdit_Click);
			// 
			// clnUserName
			// 
			this.clnUserName.Text = "[Name]";
			this.clnUserName.Width = 240;
			// 
			// btnUserDelete
			// 
			this.btnUserDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUserDelete.Location = new System.Drawing.Point(218, 303);
			this.btnUserDelete.Name = "btnUserDelete";
			this.btnUserDelete.Size = new System.Drawing.Size(100, 25);
			this.btnUserDelete.TabIndex = 10;
			this.btnUserDelete.Text = "[Delete]";
			this.btnUserDelete.UseVisualStyleBackColor = true;
			this.btnUserDelete.Click += new System.EventHandler(this.btnUserDelete_Click);
			// 
			// btnUserEdit
			// 
			this.btnUserEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUserEdit.Location = new System.Drawing.Point(112, 303);
			this.btnUserEdit.Name = "btnUserEdit";
			this.btnUserEdit.Size = new System.Drawing.Size(100, 25);
			this.btnUserEdit.TabIndex = 9;
			this.btnUserEdit.Text = "[Edit]";
			this.btnUserEdit.UseVisualStyleBackColor = true;
			this.btnUserEdit.Click += new System.EventHandler(this.btnUserEdit_Click);
			// 
			// btnUserAdd
			// 
			this.btnUserAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUserAdd.Location = new System.Drawing.Point(6, 303);
			this.btnUserAdd.Name = "btnUserAdd";
			this.btnUserAdd.Size = new System.Drawing.Size(100, 25);
			this.btnUserAdd.TabIndex = 8;
			this.btnUserAdd.Text = "[Add]";
			this.btnUserAdd.UseVisualStyleBackColor = true;
			this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
			// 
			// tabMain
			// 
			this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabMain.Controls.Add(this.tabGroups);
			this.tabMain.Controls.Add(this.tabUsers);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(548, 360);
			this.tabMain.TabIndex = 11;
			// 
			// tabGroups
			// 
			this.tabGroups.Controls.Add(this.btnGroupDelete);
			this.tabGroups.Controls.Add(this.btnGroupAdd);
			this.tabGroups.Controls.Add(this.btnGroupEdit);
			this.tabGroups.Controls.Add(this.lvwGroups);
			this.tabGroups.Location = new System.Drawing.Point(4, 22);
			this.tabGroups.Name = "tabGroups";
			this.tabGroups.Padding = new System.Windows.Forms.Padding(3);
			this.tabGroups.Size = new System.Drawing.Size(540, 334);
			this.tabGroups.TabIndex = 1;
			this.tabGroups.Text = "[Groups]";
			this.tabGroups.UseVisualStyleBackColor = true;
			// 
			// btnGroupDelete
			// 
			this.btnGroupDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGroupDelete.Location = new System.Drawing.Point(218, 303);
			this.btnGroupDelete.Name = "btnGroupDelete";
			this.btnGroupDelete.Size = new System.Drawing.Size(100, 25);
			this.btnGroupDelete.TabIndex = 13;
			this.btnGroupDelete.Text = "[Delete]";
			this.btnGroupDelete.UseVisualStyleBackColor = true;
			this.btnGroupDelete.Click += new System.EventHandler(this.btnGroupDelete_Click);
			// 
			// btnGroupAdd
			// 
			this.btnGroupAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGroupAdd.Location = new System.Drawing.Point(6, 303);
			this.btnGroupAdd.Name = "btnGroupAdd";
			this.btnGroupAdd.Size = new System.Drawing.Size(100, 25);
			this.btnGroupAdd.TabIndex = 11;
			this.btnGroupAdd.Text = "[Add]";
			this.btnGroupAdd.UseVisualStyleBackColor = true;
			this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
			// 
			// btnGroupEdit
			// 
			this.btnGroupEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGroupEdit.Location = new System.Drawing.Point(112, 303);
			this.btnGroupEdit.Name = "btnGroupEdit";
			this.btnGroupEdit.Size = new System.Drawing.Size(100, 25);
			this.btnGroupEdit.TabIndex = 12;
			this.btnGroupEdit.Text = "[Edit]";
			this.btnGroupEdit.UseVisualStyleBackColor = true;
			this.btnGroupEdit.Click += new System.EventHandler(this.btnGroupEdit_Click);
			// 
			// lvwGroups
			// 
			this.lvwGroups.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lvwGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnGroupName});
			this.lvwGroups.FullRowSelect = true;
			this.lvwGroups.GridLines = true;
			this.lvwGroups.HideSelection = false;
			this.lvwGroups.Location = new System.Drawing.Point(0, 0);
			this.lvwGroups.Name = "lvwGroups";
			this.lvwGroups.Size = new System.Drawing.Size(540, 297);
			this.lvwGroups.TabIndex = 5;
			this.lvwGroups.UseCompatibleStateImageBehavior = false;
			this.lvwGroups.View = System.Windows.Forms.View.Details;
			this.lvwGroups.VirtualMode = true;
			this.lvwGroups.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwGroups_RetrieveVirtualItem);
			this.lvwGroups.SelectedIndexChanged += new System.EventHandler(this.lvwGroups_SelectedIndexChanged);
			this.lvwGroups.DoubleClick += new System.EventHandler(this.btnGroupEdit_Click);
			// 
			// clnGroupName
			// 
			this.clnGroupName.Text = "[Name]";
			this.clnGroupName.Width = 240;
			// 
			// tabUsers
			// 
			this.tabUsers.Controls.Add(this.lvwUsers);
			this.tabUsers.Controls.Add(this.btnUserDelete);
			this.tabUsers.Controls.Add(this.btnUserAdd);
			this.tabUsers.Controls.Add(this.btnUserEdit);
			this.tabUsers.Location = new System.Drawing.Point(4, 22);
			this.tabUsers.Name = "tabUsers";
			this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
			this.tabUsers.Size = new System.Drawing.Size(540, 334);
			this.tabUsers.TabIndex = 0;
			this.tabUsers.Text = "[Users]";
			this.tabUsers.UseVisualStyleBackColor = true;
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(354, 378);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 12;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(460, 378);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SecurityForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(572, 415);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tabMain);
			this.Name = "SecurityForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Security]";
			this.tabMain.ResumeLayout(false);
			this.tabGroups.ResumeLayout(false);
			this.tabUsers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.ListView lvwUsers;
		private System.Windows.Forms.ColumnHeader clnUserName;
		private System.Windows.Forms.Button btnUserDelete;
		private System.Windows.Forms.Button btnUserEdit;
		private System.Windows.Forms.Button btnUserAdd;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabUsers;
		private System.Windows.Forms.TabPage tabGroups;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView lvwGroups;
		private System.Windows.Forms.ColumnHeader clnGroupName;
		private System.Windows.Forms.Button btnGroupDelete;
		private System.Windows.Forms.Button btnGroupAdd;
		private System.Windows.Forms.Button btnGroupEdit;
	}
}
