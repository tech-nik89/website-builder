namespace WebsiteBuilder.Modules.FormDesigner {
	partial class FormDesignerControl {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDesignerControl));
			this.tsMain = new System.Windows.Forms.ToolStrip();
			this.tsbAdd = new System.Windows.Forms.ToolStripDropDownButton();
			this.tsbAddHorizontalLine = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddHeadline = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddText = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddTextBox = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddTextArea = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddCheckbox = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddRadioButton = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbAddDropDown = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbEdit = new System.Windows.Forms.ToolStripButton();
			this.tsbDelete = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbUp = new System.Windows.Forms.ToolStripButton();
			this.tsbDown = new System.Windows.Forms.ToolStripButton();
			this.lvwItems = new System.Windows.Forms.ListView();
			this.clnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clnTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tsMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsMain
			// 
			this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.tsbEdit,
            this.tsbDelete,
            this.toolStripSeparator1,
            this.tsbUp,
            this.tsbDown});
			this.tsMain.Location = new System.Drawing.Point(0, 0);
			this.tsMain.Name = "tsMain";
			this.tsMain.Size = new System.Drawing.Size(467, 25);
			this.tsMain.TabIndex = 0;
			this.tsMain.Text = "toolStrip1";
			// 
			// tsbAdd
			// 
			this.tsbAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddHorizontalLine,
            this.tsbAddHeadline,
            this.tsbAddText,
            this.tsbAddTextBox,
            this.tsbAddTextArea,
            this.tsbAddCheckbox,
            this.tsbAddRadioButton,
            this.tsbAddDropDown});
			this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
			this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAdd.Name = "tsbAdd";
			this.tsbAdd.Size = new System.Drawing.Size(66, 22);
			this.tsbAdd.Text = "[Add]";
			// 
			// tsbAddHorizontalLine
			// 
			this.tsbAddHorizontalLine.Name = "tsbAddHorizontalLine";
			this.tsbAddHorizontalLine.Size = new System.Drawing.Size(162, 22);
			this.tsbAddHorizontalLine.Text = "[Horizontal Line]";
			this.tsbAddHorizontalLine.Click += new System.EventHandler(this.tsbAddHorizontalLine_Click);
			// 
			// tsbAddHeadline
			// 
			this.tsbAddHeadline.Name = "tsbAddHeadline";
			this.tsbAddHeadline.Size = new System.Drawing.Size(162, 22);
			this.tsbAddHeadline.Text = "[Headline]";
			this.tsbAddHeadline.Click += new System.EventHandler(this.tsbAddHeadline_Click);
			// 
			// tsbAddText
			// 
			this.tsbAddText.Name = "tsbAddText";
			this.tsbAddText.Size = new System.Drawing.Size(162, 22);
			this.tsbAddText.Text = "[Text]";
			this.tsbAddText.Click += new System.EventHandler(this.tsbAddText_Click);
			// 
			// tsbAddTextBox
			// 
			this.tsbAddTextBox.Name = "tsbAddTextBox";
			this.tsbAddTextBox.Size = new System.Drawing.Size(162, 22);
			this.tsbAddTextBox.Text = "[Textbox]";
			this.tsbAddTextBox.Click += new System.EventHandler(this.tsbAddTextBox_Click);
			// 
			// tsbAddTextArea
			// 
			this.tsbAddTextArea.Name = "tsbAddTextArea";
			this.tsbAddTextArea.Size = new System.Drawing.Size(162, 22);
			this.tsbAddTextArea.Text = "[Textarea]";
			this.tsbAddTextArea.Click += new System.EventHandler(this.tsbAddTextArea_Click);
			// 
			// tsbAddCheckbox
			// 
			this.tsbAddCheckbox.Name = "tsbAddCheckbox";
			this.tsbAddCheckbox.Size = new System.Drawing.Size(162, 22);
			this.tsbAddCheckbox.Text = "[Checkbox]";
			this.tsbAddCheckbox.Click += new System.EventHandler(this.tsbAddCheckbox_Click);
			// 
			// tsbAddRadioButton
			// 
			this.tsbAddRadioButton.Name = "tsbAddRadioButton";
			this.tsbAddRadioButton.Size = new System.Drawing.Size(162, 22);
			this.tsbAddRadioButton.Text = "[Radiobutton]";
			this.tsbAddRadioButton.Click += new System.EventHandler(this.tsbAddRadioButton_Click);
			// 
			// tsbAddDropDown
			// 
			this.tsbAddDropDown.Name = "tsbAddDropDown";
			this.tsbAddDropDown.Size = new System.Drawing.Size(162, 22);
			this.tsbAddDropDown.Text = "[Dropdown]";
			this.tsbAddDropDown.Click += new System.EventHandler(this.tsbAddDropDown_Click);
			// 
			// tsbEdit
			// 
			this.tsbEdit.Image = ((System.Drawing.Image)(resources.GetObject("tsbEdit.Image")));
			this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbEdit.Name = "tsbEdit";
			this.tsbEdit.Size = new System.Drawing.Size(55, 22);
			this.tsbEdit.Text = "[Edit]";
			this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
			// 
			// tsbDelete
			// 
			this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
			this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDelete.Name = "tsbDelete";
			this.tsbDelete.Size = new System.Drawing.Size(68, 22);
			this.tsbDelete.Text = "[Delete]";
			this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbUp
			// 
			this.tsbUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbUp.Image")));
			this.tsbUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbUp.Name = "tsbUp";
			this.tsbUp.Size = new System.Drawing.Size(50, 22);
			this.tsbUp.Text = "[Up]";
			this.tsbUp.Click += new System.EventHandler(this.tsbUp_Click);
			// 
			// tsbDown
			// 
			this.tsbDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbDown.Image")));
			this.tsbDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbDown.Name = "tsbDown";
			this.tsbDown.Size = new System.Drawing.Size(66, 22);
			this.tsbDown.Text = "[Down]";
			this.tsbDown.Click += new System.EventHandler(this.tsbDown_Click);
			// 
			// lvwItems
			// 
			this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clnType,
            this.clnTitle});
			this.lvwItems.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvwItems.FullRowSelect = true;
			this.lvwItems.GridLines = true;
			this.lvwItems.HideSelection = false;
			this.lvwItems.Location = new System.Drawing.Point(0, 25);
			this.lvwItems.Name = "lvwItems";
			this.lvwItems.Size = new System.Drawing.Size(467, 251);
			this.lvwItems.TabIndex = 1;
			this.lvwItems.UseCompatibleStateImageBehavior = false;
			this.lvwItems.View = System.Windows.Forms.View.Details;
			this.lvwItems.VirtualMode = true;
			this.lvwItems.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvwItems_RetrieveVirtualItem);
			this.lvwItems.SelectedIndexChanged += new System.EventHandler(this.lvwItems_SelectedIndexChanged);
			this.lvwItems.DoubleClick += new System.EventHandler(this.tsbEdit_Click);
			// 
			// clnType
			// 
			this.clnType.Text = "[Type]";
			this.clnType.Width = 160;
			// 
			// clnTitle
			// 
			this.clnTitle.Text = "[Title]";
			this.clnTitle.Width = 240;
			// 
			// FormDesignerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lvwItems);
			this.Controls.Add(this.tsMain);
			this.Name = "FormDesignerControl";
			this.Size = new System.Drawing.Size(467, 276);
			this.tsMain.ResumeLayout(false);
			this.tsMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsMain;
		private System.Windows.Forms.ToolStripButton tsbEdit;
		private System.Windows.Forms.ToolStripButton tsbDelete;
		private System.Windows.Forms.ListView lvwItems;
		private System.Windows.Forms.ColumnHeader clnTitle;
		private System.Windows.Forms.ColumnHeader clnType;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton tsbUp;
		private System.Windows.Forms.ToolStripButton tsbDown;
		private System.Windows.Forms.ToolStripDropDownButton tsbAdd;
		private System.Windows.Forms.ToolStripMenuItem tsbAddHorizontalLine;
		private System.Windows.Forms.ToolStripMenuItem tsbAddHeadline;
		private System.Windows.Forms.ToolStripMenuItem tsbAddText;
		private System.Windows.Forms.ToolStripMenuItem tsbAddTextBox;
		private System.Windows.Forms.ToolStripMenuItem tsbAddTextArea;
		private System.Windows.Forms.ToolStripMenuItem tsbAddCheckbox;
		private System.Windows.Forms.ToolStripMenuItem tsbAddRadioButton;
		private System.Windows.Forms.ToolStripMenuItem tsbAddDropDown;
	}
}
