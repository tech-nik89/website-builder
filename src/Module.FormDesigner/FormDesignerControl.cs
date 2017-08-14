using System;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.FormDesigner.Data;
using WebsiteStudio.Modules.FormDesigner.Localization;

namespace WebsiteStudio.Modules.FormDesigner {
	public partial class FormDesignerControl : UserControl, IUserInterface {

		private readonly IPluginHelper _PluginHelper;

		private FormData _Data;

		public bool Dirty { get; private set; }

		public String Data {
			get {
				Dirty = false;
				return FormData.Serialize(_Data);
			}
			set {
				_Data = FormData.Deserialize(value);
				RefreshList();
				Dirty = false;
			}
		}

		public FormDesignerControl(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
			_Data = new FormData();

			InitializeComponent();
			LocalizeComponent();
			ApplyIcons();
			EnableControls();
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbAdd.Image = iconPack.GetImage(IconPackIcon.Add);
			tsbEdit.Image = iconPack.GetImage(IconPackIcon.Edit);
			tsbDelete.Image = iconPack.GetImage(IconPackIcon.Delete);
			tsbUp.Image = iconPack.GetImage(IconPackIcon.OrderUp);
			tsbDown.Image = iconPack.GetImage(IconPackIcon.OrderDown);
			tsbSettings.Image = iconPack.GetImage(IconPackIcon.Settings);
		}

		private void LocalizeComponent() {
			tsbAdd.Text = Strings.Add;
			tsbEdit.Text = Strings.Edit;
			tsbDelete.Text = Strings.Delete;
			tsbUp.Text = Strings.Up;
			tsbDown.Text = Strings.Down;
			tsbSettings.Text = Strings.Settings;

			tsbAddCheckbox.Text = Strings.CheckBox;
			tsbAddDropDown.Text = Strings.DropDown;
			tsbAddHeadline.Text = Strings.Headline;
			tsbAddHorizontalLine.Text = Strings.HorizontalLine;
			tsbAddRadioButton.Text = Strings.RadioButton;
			tsbAddText.Text = Strings.Text;
			tsbAddTextArea.Text = Strings.TextArea;
			tsbAddTextBox.Text = Strings.TextBox;

			clnTitle.Text = Strings.Title;
			clnType.Text = Strings.Type;
		}
		
		private void lvwItems_SelectedIndexChanged(object sender, EventArgs e) {
			EnableControls();
		}

		private void lvwItems_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
			FormDataItem item = _Data.Items[e.ItemIndex];
			String[] columns = { item.Type, item.Title };
			e.Item = new ListViewItem(columns);
		}

		private void RefreshList() {
			int count = _Data.Items.Count;
			int index = lvwItems.SelectedIndices.Count > 0
				? lvwItems.SelectedIndices[0] : -1;

			lvwItems.VirtualListSize = 0;
			lvwItems.VirtualListSize = count;

			if (index > -1 && index < _Data.Items.Count) {
				lvwItems.SelectedIndices.Clear();
				lvwItems.SelectedIndices.Add(index);
			}
		}

		private void EnableControls() {
			Boolean editEnabled = lvwItems.SelectedIndices.Count > 0;
			tsbEdit.Enabled = editEnabled;
			tsbDelete.Enabled = editEnabled;

			tsbUp.Enabled = editEnabled && lvwItems.SelectedIndices[0] > 0;
			tsbDown.Enabled = editEnabled && lvwItems.SelectedIndices[0] < _Data.Items.Count - 1;
		}

		private void tsbAddHorizontalLine_Click(object sender, EventArgs e) {
			Add(new HorizontalLineItem());
		}

		private void tsbAddHeadline_Click(object sender, EventArgs e) {
			Add(new HeadlineItem());
		}

		private void tsbAddText_Click(object sender, EventArgs e) {
			Add(new TextItem());
		}

		private void tsbAddTextBox_Click(object sender, EventArgs e) {
			Add(new TextBoxItem());
		}

		private void tsbAddTextArea_Click(object sender, EventArgs e) {
			Add(new TextAreaItem());
		}

		private void tsbAddCheckbox_Click(object sender, EventArgs e) {
			Add(new CheckBoxItem());
		}

		private void tsbAddRadioButton_Click(object sender, EventArgs e) {
			Add(new RadioButtonItem());
		}

		private void tsbAddDropDown_Click(object sender, EventArgs e) {
			Add(new DropDownItem());
		}

		private void tsbEdit_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0) {
				return;
			}

			Edit(_Data.Items[lvwItems.SelectedIndices[0]]);
			Dirty = true;
			RefreshList();
		}

		private void tsbDelete_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0) {
				return;
			}

			if (MessageBox.Show(Strings.DeleteConfirmMessage, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) {
				return;
			}

			_Data.Items.RemoveAt(lvwItems.SelectedIndices[0]);
			Dirty = true;
			RefreshList();
		}

		private void Add(FormDataItem item) {
			Edit(item);
			_Data.Items.Add(item);
			Dirty = true;
			RefreshList();
		}

		private Boolean Edit(FormDataItem item) {
			if (item.GetType().IsSubclassOf(typeof(InputItem))) {
				return ProcessInputItem((InputItem)item);
			}
			else if (item is HeadlineItem) {
				return ProcessHeadLine((HeadlineItem)item);
			}
			else if (item is TextAreaItem) {
				return ProcessTextArea((TextAreaItem)item);
			}
			else if (item is DropDownItem) {
				return ProcessDropDown((DropDownItem)item);
			}
			else if (item is TextItem) {
				return ProcessTextItem((TextItem)item);
			}

			return false;
		}

		private Boolean ProcessTextArea(TextAreaItem item) {
			InputItemForm form = new InputItemForm();
			form.Text = item.Type;
			form.ItemName = item.Name;
			form.ItemLabel = item.Label;

			if (form.ShowDialog() != DialogResult.OK) {
				return false;
			}

			item.Name = form.ItemName;
			item.Label = form.ItemLabel;

			return true;
		}

		private Boolean ProcessHeadLine(HeadlineItem item) {
			InputItemForm form = new InputItemForm();
			form.EnableItemName = false;
			form.Text = item.Type;
			form.ItemName = item.Name;
			form.ItemLabel = item.HeadlineText;

			if (form.ShowDialog() != DialogResult.OK) {
				return false;
			}

			item.Name = form.ItemName;
			item.HeadlineText = form.ItemLabel;

			return true;
		}

		private Boolean ProcessDropDown(DropDownItem item) {
			InputItemForm form = new InputItemForm();
			form.Text = item.Type;
			form.ItemName = item.Name;
			form.ItemLabel = item.Label;
			form.Items = item.Items.ToArray();

			if (form.ShowDialog() != DialogResult.OK) {
				return false;
			}

			item.Name = form.ItemName;
			item.Label = form.ItemLabel;

			item.Items.Clear();
			item.Items.AddRange(form.Items);

			return true;
		}

		private Boolean ProcessTextItem(TextItem item) {
			InputItemForm form = new InputItemForm();
			form.EnableItemName = false;
			form.Text = item.Type;
			form.ItemName = item.Name;
			form.ItemLabel = item.Text;

			if (form.ShowDialog() != DialogResult.OK) {
				return false;
			}

			item.Name = form.ItemName;
			item.Text = form.ItemLabel;

			return true;
		}

		private Boolean ProcessInputItem(InputItem item) {
			InputItemForm form = new InputItemForm();
			form.Text = item.Type;
			form.ItemName = item.Name;
			form.ItemLabel = item.Label;

			if (form.ShowDialog() != DialogResult.OK) {
				return false;
			}

			item.Name = form.ItemName;
			item.Label = form.ItemLabel;

			return true;
		}

		private void tsbUp_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0 || lvwItems.SelectedIndices[0] < 1) {
				return;
			}

			int index = lvwItems.SelectedIndices[0];
			FormDataItem item = _Data.Items[index];
			index--;

			_Data.Items.Remove(item);
			_Data.Items.Insert(index, item);

			RefreshList();

			lvwItems.SelectedIndices.Clear();
			lvwItems.SelectedIndices.Add(index);
		}

		private void tsbDown_Click(object sender, EventArgs e) {
			if (lvwItems.SelectedIndices.Count == 0 || lvwItems.SelectedIndices[0] >= _Data.Items.Count - 1) {
				return;
			}

			int index = lvwItems.SelectedIndices[0];
			FormDataItem item = _Data.Items[index];
			index++;

			_Data.Items.Remove(item);
			_Data.Items.Insert(index, item);

			RefreshList();

			lvwItems.SelectedIndices.Clear();
			lvwItems.SelectedIndices.Add(index);
		}

		private void tsbSettings_Click(object sender, EventArgs e) {
			FormSettingsForm form = new FormSettingsForm(_PluginHelper);

			form.SubmitButtonText = _Data.SubmitButtonText;
			form.TargetService = _Data.TargetService;
			form.TargetMailAddress = _Data.TargetMailAddress;
			form.SuccessMessage = _Data.SuccessMessage;

			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			_Data.SubmitButtonText = form.SubmitButtonText;
			_Data.TargetService = form.TargetService;
			_Data.TargetMailAddress = form.TargetMailAddress;
			_Data.SuccessMessage = form.SuccessMessage;
		}
	}
}
