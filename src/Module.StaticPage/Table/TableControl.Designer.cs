namespace WebsiteBuilder.Modules.Table {
    partial class TableControl {
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
			this.txtData = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tslColumnDelimiter = new System.Windows.Forms.ToolStripLabel();
			this.tscColumnDelimiter = new System.Windows.Forms.ToolStripComboBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tslHeaderPosition = new System.Windows.Forms.ToolStripLabel();
			this.tscHeaderPosition = new System.Windows.Forms.ToolStripComboBox();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtData
			// 
			this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtData.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtData.Location = new System.Drawing.Point(0, 25);
			this.txtData.Multiline = true;
			this.txtData.Name = "txtData";
			this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtData.Size = new System.Drawing.Size(622, 341);
			this.txtData.TabIndex = 0;
			this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslColumnDelimiter,
            this.tscColumnDelimiter,
            this.toolStripSeparator1,
            this.tslHeaderPosition,
            this.tscHeaderPosition});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(622, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tslColumnDelimiter
			// 
			this.tslColumnDelimiter.Name = "tslColumnDelimiter";
			this.tslColumnDelimiter.Size = new System.Drawing.Size(106, 22);
			this.tslColumnDelimiter.Text = "[ColumnDelimiter]";
			// 
			// tscColumnDelimiter
			// 
			this.tscColumnDelimiter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscColumnDelimiter.Name = "tscColumnDelimiter";
			this.tscColumnDelimiter.Size = new System.Drawing.Size(121, 25);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tslHeaderPosition
			// 
			this.tslHeaderPosition.Name = "tslHeaderPosition";
			this.tslHeaderPosition.Size = new System.Drawing.Size(96, 22);
			this.tslHeaderPosition.Text = "[HeaderPosition]";
			// 
			// tscHeaderPosition
			// 
			this.tscHeaderPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.tscHeaderPosition.Name = "tscHeaderPosition";
			this.tscHeaderPosition.Size = new System.Drawing.Size(121, 25);
			// 
			// TableControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.toolStrip1);
			this.Name = "TableControl";
			this.Size = new System.Drawing.Size(622, 366);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtData;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel tslColumnDelimiter;
        private System.Windows.Forms.ToolStripComboBox tscColumnDelimiter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslHeaderPosition;
        private System.Windows.Forms.ToolStripComboBox tscHeaderPosition;
    }
}
