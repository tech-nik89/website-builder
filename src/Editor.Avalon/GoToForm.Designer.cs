namespace WebsiteStudio.Editors.Avalon {
	partial class GoToForm {
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
			this.lblCurrentLineCaption = new System.Windows.Forms.Label();
			this.lblCurrentLine = new System.Windows.Forms.Label();
			this.lblTargetLineCaption = new System.Windows.Forms.Label();
			this.lblLineCountCaption = new System.Windows.Forms.Label();
			this.lblLineCount = new System.Windows.Forms.Label();
			this.numTargetLine = new System.Windows.Forms.NumericUpDown();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numTargetLine)).BeginInit();
			this.SuspendLayout();
			// 
			// lblCurrentLineCaption
			// 
			this.lblCurrentLineCaption.AutoSize = true;
			this.lblCurrentLineCaption.Location = new System.Drawing.Point(21, 22);
			this.lblCurrentLineCaption.Name = "lblCurrentLineCaption";
			this.lblCurrentLineCaption.Size = new System.Drawing.Size(67, 13);
			this.lblCurrentLineCaption.TabIndex = 0;
			this.lblCurrentLineCaption.Text = "[CurrentLine]";
			// 
			// lblCurrentLine
			// 
			this.lblCurrentLine.AutoSize = true;
			this.lblCurrentLine.Location = new System.Drawing.Point(148, 22);
			this.lblCurrentLine.Name = "lblCurrentLine";
			this.lblCurrentLine.Size = new System.Drawing.Size(67, 13);
			this.lblCurrentLine.TabIndex = 1;
			this.lblCurrentLine.Text = "[CurrentLine]";
			// 
			// lblTargetLineCaption
			// 
			this.lblTargetLineCaption.AutoSize = true;
			this.lblTargetLineCaption.Location = new System.Drawing.Point(21, 48);
			this.lblTargetLineCaption.Name = "lblTargetLineCaption";
			this.lblTargetLineCaption.Size = new System.Drawing.Size(64, 13);
			this.lblTargetLineCaption.TabIndex = 2;
			this.lblTargetLineCaption.Text = "[TargetLine]";
			// 
			// lblLineCountCaption
			// 
			this.lblLineCountCaption.AutoSize = true;
			this.lblLineCountCaption.Location = new System.Drawing.Point(21, 75);
			this.lblLineCountCaption.Name = "lblLineCountCaption";
			this.lblLineCountCaption.Size = new System.Drawing.Size(61, 13);
			this.lblLineCountCaption.TabIndex = 3;
			this.lblLineCountCaption.Text = "[LineCount]";
			// 
			// lblLineCount
			// 
			this.lblLineCount.AutoSize = true;
			this.lblLineCount.Location = new System.Drawing.Point(148, 75);
			this.lblLineCount.Name = "lblLineCount";
			this.lblLineCount.Size = new System.Drawing.Size(61, 13);
			this.lblLineCount.TabIndex = 4;
			this.lblLineCount.Text = "[LineCount]";
			// 
			// numTargetLine
			// 
			this.numTargetLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.numTargetLine.Location = new System.Drawing.Point(151, 46);
			this.numTargetLine.Name = "numTargetLine";
			this.numTargetLine.Size = new System.Drawing.Size(147, 20);
			this.numTargetLine.TabIndex = 5;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(198, 113);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "[Cancel]";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnAccept
			// 
			this.btnAccept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAccept.Location = new System.Drawing.Point(92, 113);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(100, 25);
			this.btnAccept.TabIndex = 7;
			this.btnAccept.Text = "[OK]";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// GoToForm
			// 
			this.AcceptButton = this.btnAccept;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(310, 150);
			this.Controls.Add(this.btnAccept);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.numTargetLine);
			this.Controls.Add(this.lblLineCount);
			this.Controls.Add(this.lblLineCountCaption);
			this.Controls.Add(this.lblTargetLineCaption);
			this.Controls.Add(this.lblCurrentLine);
			this.Controls.Add(this.lblCurrentLineCaption);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "GoToForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "[GoTo]";
			((System.ComponentModel.ISupportInitialize)(this.numTargetLine)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblCurrentLineCaption;
		private System.Windows.Forms.Label lblCurrentLine;
		private System.Windows.Forms.Label lblTargetLineCaption;
		private System.Windows.Forms.Label lblLineCountCaption;
		private System.Windows.Forms.Label lblLineCount;
		private System.Windows.Forms.NumericUpDown numTargetLine;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnAccept;
	}
}