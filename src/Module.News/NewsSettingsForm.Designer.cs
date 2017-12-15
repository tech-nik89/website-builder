namespace WebsiteStudio.Modules.News {
    partial class NewsSettingsForm {
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.lblLargeItemsCount = new System.Windows.Forms.Label();
			this.numLargeItemsCount = new System.Windows.Forms.NumericUpDown();
			this.lblExpanderText = new System.Windows.Forms.Label();
			this.txtExpanderText = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.numLargeItemsCount)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(252, 104);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAccept.Location = new System.Drawing.Point(146, 104);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 1;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// lblLargeItemsCount
			// 
			this.lblLargeItemsCount.AutoSize = true;
			this.lblLargeItemsCount.Location = new System.Drawing.Point(22, 25);
			this.lblLargeItemsCount.Name = "lblLargeItemsCount";
			this.lblLargeItemsCount.Size = new System.Drawing.Size(93, 13);
			this.lblLargeItemsCount.TabIndex = 2;
			this.lblLargeItemsCount.Text = "[LargeItemsCount]";
			// 
			// numLargeItemsCount
			// 
			this.numLargeItemsCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numLargeItemsCount.Location = new System.Drawing.Point(162, 23);
			this.numLargeItemsCount.Name = "numLargeItemsCount";
			this.numLargeItemsCount.Size = new System.Drawing.Size(190, 20);
			this.numLargeItemsCount.TabIndex = 3;
			// 
			// lblExpanderText
			// 
			this.lblExpanderText.AutoSize = true;
			this.lblExpanderText.Location = new System.Drawing.Point(22, 52);
			this.lblExpanderText.Name = "lblExpanderText";
			this.lblExpanderText.Size = new System.Drawing.Size(79, 13);
			this.lblExpanderText.TabIndex = 6;
			this.lblExpanderText.Text = "[ExpanderText]";
			// 
			// txtExpanderText
			// 
			this.txtExpanderText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtExpanderText.Location = new System.Drawing.Point(162, 49);
			this.txtExpanderText.Name = "txtExpanderText";
			this.txtExpanderText.Size = new System.Drawing.Size(190, 20);
			this.txtExpanderText.TabIndex = 7;
			// 
			// NewsSettingsForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(364, 141);
			this.Controls.Add(this.txtExpanderText);
			this.Controls.Add(this.lblExpanderText);
			this.Controls.Add(this.numLargeItemsCount);
			this.Controls.Add(this.lblLargeItemsCount);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(380, 180);
			this.Name = "NewsSettingsForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[News Settings]";
			((System.ComponentModel.ISupportInitialize)(this.numLargeItemsCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label lblLargeItemsCount;
        private System.Windows.Forms.NumericUpDown numLargeItemsCount;
        private System.Windows.Forms.Label lblExpanderText;
        private System.Windows.Forms.TextBox txtExpanderText;
    }
}