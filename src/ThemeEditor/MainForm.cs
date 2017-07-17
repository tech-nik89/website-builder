using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using ThemeEditor.Localization;
using System.Xml;
using System.IO;

namespace ThemeEditor {
	public partial class MainForm : Form {

		private const String ThemeFileExtensionName = "wbtx";

		private static readonly String ThemeFileExtension = String.Format("*.{0}", ThemeFileExtensionName);

		public static readonly String[] SupportedFileTypes = { "png", "bmp", "gif", "jpg", "jpeg", "tiff" };

		private int _LastIndex = -1;

		private Theme _Theme;
		
		private Theme Theme {
			get {
				if (_Theme == null) {
					_Theme = Theme.Create();
				}

				return _Theme;
			}
		}

		public MainForm() {
			InitializeComponent();
			LocalizeComponent();

			String themeFilter = String.Format(Strings.ThemeFileFilter, ThemeFileExtension);
			ofdTheme.Filter = themeFilter;
			sfdTheme.Filter = themeFilter;

			String imagesFilter = String.Format(Strings.ImageFileFilter, String.Join(";", SupportedFileTypes.Select(x => "*." + x)));
			ofdImage.Filter = imagesFilter;
		}

		private void LocalizeComponent() {
			Text = Strings.Title;

			mnuFile.Text = Strings.File;
			mnuFileOpen.Text = Strings.Open;
			mnuFileSave.Text = Strings.Save;
			mnuFileSaveAs.Text = Strings.SaveAs;
			mnuFileExit.Text = Strings.Exit;
			
			tabSettings.Text = Strings.Settings;
			tabStyles.Text = Strings.Styles;
			tabImages.Text = Strings.Images;
			tabTemplates.Text = Strings.Templates;

			gbxDescription.Text = Strings.Description;
			gbxGeneral.Text = Strings.General;

			lblCssImageClass.Text = Strings.ImageClass + ":";
			lblMaxMenuDepth.Text = Strings.MaxMenuDepth + ":";

			tsbStylesAdd.Text = Strings.Add;
			tsbStylesEdit.Text = Strings.Edit;
			tsbStylesDelete.Text = Strings.Delete;

			clnStylesName.Text = Strings.Name;
			clnStylesType.Text = Strings.Type;

			tsbImagesAdd.Text = Strings.Add;
			tsbImagesEdit.Text = Strings.Edit;
			tsbImagesRemove.Text = Strings.Delete;

			clnImagesName.Text = Strings.Name;
			clnTemplate.Text = Strings.Template;
		}

		private void MainForm_Load(object sender, EventArgs e) {
			lvwTemplates.Items.Add(Strings.Body);
			lvwTemplates.Items.Add(Strings.NavItems);
			lvwTemplates.Items.Add(Strings.NavItem);
			lvwTemplates.Items.Add(Strings.LanguageItems);
			lvwTemplates.Items.Add(Strings.LanguageItem);
		}

		private void lvwTemplates_SelectedIndexChanged(object sender, EventArgs e) {
			if (_LastIndex > -1) {
				SaveCurrentTemplate();
			}

			if (lvwTemplates.SelectedIndices.Count > 0) {
				_LastIndex = lvwTemplates.SelectedIndices[0];
				txtHTML.Text = GetTemplate(_LastIndex).InnerXml;
			}
			else {
				_LastIndex = -1;
				txtHTML.Text = String.Empty;
			}
		}

		private void SaveCurrentTemplate() {
			GetTemplate(_LastIndex).InnerXml = txtHTML.Text;
		}

		private XmlElement GetTemplate(int index) {
			switch (index) {
				case 0: return Theme.Body;
				case 1: return Theme.NavItems;
				case 2: return Theme.NavItem;
				case 3: return Theme.LanguageItems;
				case 4: return Theme.LanguageItem;
			}

			return null;
		}

		private void FillFormFromDocument() {
			txtDescription.Text = Theme.Description.InnerText;
			txtCssImageClass.Text = Theme.ImageCssClass.InnerText;

			int maxMenuDepth = 1;
			if (int.TryParse(Theme.MaxMenuDepth.InnerText, out maxMenuDepth)) {
				numMaxMenuDepth.Value = maxMenuDepth;
			}

			RefreshStylesList();
			RefreshImageList();
		}

		private void RefreshStylesList() {
			lvwStyles.Items.Clear();

			foreach (XmlElement element in Theme.Styles) {
				String[] columns = {
					element.Attributes["name"]?.InnerText,
					element.Attributes["type"]?.InnerText
				};

				if (columns.Any(c => c == null)) {
					continue;
				}

				ListViewItem item = new ListViewItem(columns);
				item.Tag = element.InnerText;
				lvwStyles.Items.Add(item);
			}
		}

		private void RefreshImageList() {
			lvwImages.Items.Clear();

			foreach (XmlElement element in Theme.Images) {
				String[] columns = { element.Attributes["name"]?.InnerText };

				if (columns.Any(c => c == null)) {
					continue;
				}

				ListViewItem item = new ListViewItem(columns);
				item.Tag = element.InnerText;
				lvwImages.Items.Add(item);
			}
		}

		private void mnuFileOpen_Click(object sender, EventArgs e) {
			if (ofdTheme.ShowDialog() != DialogResult.OK) {
				return;
			}

			try {
				_Theme = Theme.Load(ofdTheme.FileName);
				FillFormFromDocument();
			}
			catch (Exception ex) {
				HandleError(ex);
			}
		}

		private void mnuFileSave_Click(object sender, EventArgs e) {
			Save(false);
		}

		private void mnuFileSaveAs_Click(object sender, EventArgs e) {
			Save(true);
		}

		private void mnuFileExit_Click(object sender, EventArgs e) {
			Close();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {

		}

		private void Save(bool saveAs) {
			String path = Theme.Path;

			if (saveAs || String.IsNullOrWhiteSpace(path)) {
				DialogResult result = sfdTheme.ShowDialog();

				if (result != DialogResult.OK) {
					return;
				}

				path = sfdTheme.FileName;
			}

			Theme.Description.InnerText = txtDescription.Text;
			Theme.ImageCssClass.InnerText = txtCssImageClass.Text;
			Theme.MaxMenuDepth.InnerText = ((int)numMaxMenuDepth.Value).ToString();

			if (_LastIndex > -1) {
				SaveCurrentTemplate();
			}

			Theme.Save(Theme, path);
		}

		private void HandleError(Exception e) {
			MessageBox.Show(e.Message, Strings.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void tsbStylesAdd_Click(object sender, EventArgs e) {
			StyleForm form = new StyleForm();
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			XmlElement element = Theme.CreateStyle();
			element.SetAttribute("name", form.StyleName);
			element.SetAttribute("type", form.StyleType);
			element.InnerText = form.Style;

			RefreshStylesList();
		}

		private void tsbStylesEdit_Click(object sender, EventArgs e) {
			EditStyle();
		}

		private void lvwStyles_DoubleClick(object sender, EventArgs e) {
			EditStyle();
		}

		private void EditStyle() {
			if (lvwStyles.SelectedIndices.Count == 0) {
				return;
			}

			StyleForm form = new StyleForm();
			form.StyleName = lvwStyles.SelectedItems[0].SubItems[0].Text;
			form.StyleType = lvwStyles.SelectedItems[0].SubItems[1].Text;
			form.Style = (String)lvwStyles.SelectedItems[0].Tag;

			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			XmlElement element = Theme.Styles.ElementAt(lvwStyles.SelectedIndices[0]);
			element.InnerText = form.Style;
			element.SetAttribute("name", form.StyleName);
			element.SetAttribute("type", form.StyleType);

			RefreshStylesList();
		}

		private void tsbStylesDelete_Click(object sender, EventArgs e) {
			if (lvwStyles.SelectedIndices.Count == 0) {
				return;
			}

			DialogResult result = MessageBox.Show(Strings.DeleteItemConfirm, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes) {
				return;
			}

			XmlElement element = Theme.Styles.ElementAt(lvwStyles.SelectedIndices[0]);
			element.ParentNode.RemoveChild(element);

			RefreshStylesList();
		}

		private void tsbImagesAdd_Click(object sender, EventArgs e) {
			ImageForm form = new ImageForm();
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}

			XmlElement image = Theme.CreateImage();
			image.SetAttribute("name", form.ImageName);
			image.InnerText = Convert.ToBase64String(form.ImageData);

			RefreshImageList();
		}

		private void tsbImagesEdit_Click(object sender, EventArgs e) {
			if (lvwImages.SelectedIndices.Count == 0) {
				return;
			}

			XmlElement image = Theme.Images.ElementAt(lvwImages.SelectedIndices[0]);

			ImageForm form = new ImageForm(image.Attributes["name"]?.InnerText);
			if (form.ShowDialog() != DialogResult.OK) {
				return;
			}
			
			image.SetAttribute("name", form.ImageName);
			if (form.ImageData.Length > 0) {
				image.InnerText = Convert.ToBase64String(form.ImageData);
			}

			RefreshImageList();
		}

		private void tsbImagesRemove_Click(object sender, EventArgs e) {
			if (lvwImages.SelectedIndices.Count == 0) {
				return;
			}

			DialogResult result = MessageBox.Show(Strings.DeleteItemConfirm, Strings.Delete, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result != DialogResult.Yes) {
				return;
			}

			XmlElement element = Theme.Images.ElementAt(lvwImages.SelectedIndices[0]);
			element.ParentNode.RemoveChild(element);

			RefreshImageList();
		}
		
		private void lvwImages_SelectedIndexChanged(object sender, EventArgs e) {
			if (lvwImages.SelectedIndices.Count == 0) {
				pbxImage.Image = null;
			}
			else {
				Byte[] buffer = Convert.FromBase64String((String)lvwImages.SelectedItems[0].Tag);
				using (MemoryStream stream = new MemoryStream(buffer)) {
					pbxImage.Image = Image.FromStream(stream);
				}
			}
		}
	}
}
