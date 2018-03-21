namespace WebsiteStudio.UI.Forms {
	partial class GroupForm {
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
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabMain = new System.Windows.Forms.TabControl();
			this.tabGeneral = new System.Windows.Forms.TabPage();
			this.tabMembers = new System.Windows.Forms.TabPage();
			this.lvwMembers = new System.Windows.Forms.ListView();
			this.clnMemberName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabMain.SuspendLayout();
			this.tabGeneral.SuspendLayout();
			this.tabMembers.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(88, 16);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(319, 20);
			this.txtName.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(17, 19);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(41, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "[Name]";
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(201, 221);
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
			this.btnCancel.Location = new System.Drawing.Point(307, 221);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 2;
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
			this.tabMain.Controls.Add(this.tabMembers);
			this.tabMain.Location = new System.Drawing.Point(12, 12);
			this.tabMain.Name = "tabMain";
			this.tabMain.SelectedIndex = 0;
			this.tabMain.Size = new System.Drawing.Size(395, 203);
			this.tabMain.TabIndex = 3;
			// 
			// tabGeneral
			// 
			this.tabGeneral.Controls.Add(this.txtName);
			this.tabGeneral.Controls.Add(this.lblName);
			this.tabGeneral.Location = new System.Drawing.Point(4, 22);
			this.tabGeneral.Name = "tabGeneral";
			this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
			this.tabGeneral.Size = new System.Drawing.Size(427, 165);
			this.tabGeneral.TabIndex = 0;
			this.tabGeneral.Text = "[General]";
			this.tabGeneral.UseVisualStyleBackColor = true;
			// 
			// tabMembers
			// 
			this.tabMembers.Controls.Add(this.lvwMembers);
			this.tabMembers.Location = new System.Drawing.Point(4, 22);
			this.tabMembers.Name = "tabMembers";
			this.tabMembers.Padding = new System.Windows.Forms.Padding(3);
			this.tabMembers.Size = new System.Drawing.Size(387, 177);
			this.tabMembers.TabIndex = 1;
			this.tabMembers.Text = "[Members]";
			this.tabMembers.UseVisualStyleBackColor = true;
			// 
			// lvwMembers
			// 
			this.lvwMembers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnMemberName});
			this.lvwMembers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwMembers.FullRowSelect = true;
			this.lvwMembers.GridLines = true;
			this.lvwMembers.Location = new System.Drawing.Point(3, 3);
			this.lvwMembers.Name = "lvwMembers";
			this.lvwMembers.Size = new System.Drawing.Size(381, 171);
			this.lvwMembers.TabIndex = 0;
			this.lvwMembers.UseCompatibleStateImageBehavior = false;
			this.lvwMembers.View = System.Windows.Forms.View.Details;
			this.lvwMembers.VirtualMode = true;
			this.lvwMembers.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwMembers_RetrieveVirtualItem);
			// 
			// clnMemberName
			// 
			this.clnMemberName.Text = "[Name]";
			this.clnMemberName.Width = 240;
			// 
			// GroupForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(419, 258);
			this.Controls.Add(this.tabMain);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAccept);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 230);
			this.Name = "GroupForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Group]";
			this.tabMain.ResumeLayout(false);
			this.tabGeneral.ResumeLayout(false);
			this.tabGeneral.PerformLayout();
			this.tabMembers.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabControl tabMain;
		private System.Windows.Forms.TabPage tabGeneral;
		private System.Windows.Forms.TabPage tabMembers;
		private System.Windows.Forms.ListView lvwMembers;
		private System.Windows.Forms.ColumnHeader clnMemberName;
	}
}