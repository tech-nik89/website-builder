namespace WebsiteBuilder.Modules.FormDesigner {
	partial class InputItemForm {
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
			this.gbxDetails = new System.Windows.Forms.GroupBox();
			this.txtId = new System.Windows.Forms.TextBox();
			this.lblId = new System.Windows.Forms.Label();
			this.txtLabel = new System.Windows.Forms.TextBox();
			this.lblLabel = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.gbxItems = new System.Windows.Forms.GroupBox();
			this.txtItems = new System.Windows.Forms.TextBox();
			this.gbxDetails.SuspendLayout();
			this.gbxItems.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbxDetails
			// 
			this.gbxDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxDetails.Controls.Add(this.txtId);
			this.gbxDetails.Controls.Add(this.lblId);
			this.gbxDetails.Controls.Add(this.txtLabel);
			this.gbxDetails.Controls.Add(this.lblLabel);
			this.gbxDetails.Location = new System.Drawing.Point(12, 12);
			this.gbxDetails.Name = "gbxDetails";
			this.gbxDetails.Size = new System.Drawing.Size(383, 98);
			this.gbxDetails.TabIndex = 0;
			this.gbxDetails.TabStop = false;
			this.gbxDetails.Text = "[Details]";
			// 
			// txtId
			// 
			this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtId.Location = new System.Drawing.Point(80, 30);
			this.txtId.Name = "txtId";
			this.txtId.Size = new System.Drawing.Size(283, 20);
			this.txtId.TabIndex = 1;
			// 
			// lblId
			// 
			this.lblId.AutoSize = true;
			this.lblId.Location = new System.Drawing.Point(17, 33);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(24, 13);
			this.lblId.TabIndex = 2;
			this.lblId.Text = "[ID]";
			// 
			// txtLabel
			// 
			this.txtLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLabel.Location = new System.Drawing.Point(80, 56);
			this.txtLabel.Name = "txtLabel";
			this.txtLabel.Size = new System.Drawing.Size(283, 20);
			this.txtLabel.TabIndex = 2;
			// 
			// lblLabel
			// 
			this.lblLabel.AutoSize = true;
			this.lblLabel.Location = new System.Drawing.Point(17, 59);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(39, 13);
			this.lblLabel.TabIndex = 0;
			this.lblLabel.Text = "[Label]";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(295, 296);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccept.Location = new System.Drawing.Point(189, 296);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 3;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// gbxItems
			// 
			this.gbxItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbxItems.Controls.Add(this.txtItems);
			this.gbxItems.Location = new System.Drawing.Point(12, 116);
			this.gbxItems.Name = "gbxItems";
			this.gbxItems.Size = new System.Drawing.Size(383, 174);
			this.gbxItems.TabIndex = 5;
			this.gbxItems.TabStop = false;
			this.gbxItems.Text = "[Items]";
			// 
			// txtItems
			// 
			this.txtItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtItems.Location = new System.Drawing.Point(6, 19);
			this.txtItems.Multiline = true;
			this.txtItems.Name = "txtItems";
			this.txtItems.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtItems.Size = new System.Drawing.Size(371, 149);
			this.txtItems.TabIndex = 0;
			// 
			// InputItemForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(407, 333);
			this.ControlBox = false;
			this.Controls.Add(this.gbxItems);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbxDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "InputItemForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[Item]";
			this.gbxDetails.ResumeLayout(false);
			this.gbxDetails.PerformLayout();
			this.gbxItems.ResumeLayout(false);
			this.gbxItems.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbxDetails;
		private System.Windows.Forms.TextBox txtLabel;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.GroupBox gbxItems;
		private System.Windows.Forms.TextBox txtItems;
	}
}