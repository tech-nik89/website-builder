using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using WebsiteStudio.Core.Compiling;
using WebsiteStudio.ThemeEditor.Localization;

namespace WebsiteStudio.ThemeEditor {
	public partial class MainForm : Form {
		
		private static readonly String ThemeFileExtension = String.Format("*{0}", Core.Theming.Theme.FileExtension);

		public static readonly ImageFormat[] SupportedImageFileTypes = {
			ImageFormat.Png,
			ImageFormat.Bmp,
			ImageFormat.Gif,
			ImageFormat.Jpeg,
			ImageFormat.Tiff
		};
		
		private int _LastIndex = -1;

		private readonly TextEditor _HtmlEditor;

		private readonly TextEditor _PreviewSource;

		private ThemeDocument _Theme;
		
		private ThemeDocument Theme {
			get {
				if (_Theme == null) {
					_Theme = ThemeDocument.Create();
				}

				return _Theme;
			}
		}

		public MainForm() {
			InitializeComponent();
			LocalizeComponent();

			spcMain.Panel2Collapsed = true;

			String themeFilter = String.Format(Strings.ThemeFileFilter, ThemeFileExtension);
			ofdTheme.Filter = themeFilter;
			sfdTheme.Filter = themeFilter;
			
			ofdImage.Filter = String.Format(Strings.ImageFilesFilter, String.Join(";", SupportedImageFileTypes.Select(x => "*." + x)));
			sfdImagesExport.Filter = String.Join("|", SupportedImageFileTypes.Select(x => String.Format(Strings.ImageFileFilter, x.ToString().ToUpper(), "*." + x)));

			lvwImages_SelectedIndexChanged(this, null);
			lvwStyles_SelectedIndexChanged(this, null);

			_HtmlEditor = new TextEditor() {
				SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("HTML"),
				FontFamily = new System.Windows.Media.FontFamily("Consolas"),
				ShowLineNumbers = true
			};
			ehHtmlEditor.Child = _HtmlEditor;

			_PreviewSource = new TextEditor() {
				SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("HTML"),
				FontFamily = new System.Windows.Media.FontFamily("Consolas"),
				ShowLineNumbers = true,
				HorizontalScrollBarVisibility = System.Windows.Controls.ScrollBarVisibility.Auto
			};
			ehPreviewSource.Child = _PreviewSource;
		}

		private void LocalizeComponent() {
			Text = Strings.Title;

			mnuFile.Text = Strings.File;
			mnuFileOpen.Text = Strings.Open;
			mnuFileSave.Text = Strings.Save;
			mnuFileSaveAs.Text = Strings.SaveAs;
			mnuFileExit.Text = Strings.Exit;

			mnuView.Text = Strings.View;
			mnuViewPreview.Text = Strings.ShowPreview;

			tabSettings.Text = Strings.Settings;
			tabStyles.Text = Strings.Styles;
			tabImages.Text = Strings.Images;
			tabTemplates.Text = Strings.Templates;
			tabPreviewBrowser.Text = Strings.Preview;
			tabPreviewSource.Text = Strings.Source;

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
			tsbImagesExport.Text = Strings.Export;

			clnImagesName.Text = Strings.Name;
			clnTemplate.Text = Strings.Template;

			tsbPreviewRefresh.Text = Strings.Refresh;
		}

		private void MainForm_Load(object sender, EventArgs e) {
			lvwTemplates.Items.Add(Strings.Body);
			lvwTemplates.Items.Add(Strings.NavItems);
			lvwTemplates.Items.Add(Strings.NavItem);
			lvwTemplates.Items.Add(Strings.LanguageItems);
			lvwTemplates.Items.Add(Strings.LanguageItem);
			lvwTemplates.Items.Add(Strings.FooterSection);
			lvwTemplates.Items.Add(Strings.FooterItem);
		}

		private void lvwTemplates_SelectedIndexChanged(object sender, EventArgs e) {
			if (_LastIndex > -1) {
				SaveCurrentTemplate();
			}

			if (lvwTemplates.SelectedIndices.Count > 0) {
				_LastIndex = lvwTemplates.SelectedIndices[0];
				_HtmlEditor.Text = GetTemplate(_LastIndex).InnerXml;
			}
			else {
				_LastIndex = -1;
				_HtmlEditor.Text = String.Empty;
			}
		}

		private void SaveCurrentTemplate() {
			GetTemplate(_LastIndex).InnerXml = _HtmlEditor.Text;
		}

		private XmlElement GetTemplate(int index) {
			switch (index) {
				case 0: return Theme.Body;
				case 1: return Theme.NavItems;
				case 2: return Theme.NavItem;
				case 3: return Theme.LanguageItems;
				case 4: return Theme.LanguageItem;
				case 5: return Theme.FooterSection;
				case 6: return Theme.FooterItem;
			}

			return null;
		}

		private void FillDocumentFromForm() {
			Theme.Description.InnerText = txtDescription.Text;
			Theme.ImageCssClass.InnerText = txtCssImageClass.Text;
			Theme.MaxMenuDepth.InnerText = ((int)numMaxMenuDepth.Value).ToString();

			if (_LastIndex > -1) {
				SaveCurrentTemplate();
			}
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
				_Theme = ThemeDocument.Load(ofdTheme.FileName);
				FillFormFromDocument();
				GeneratePreview();
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

			FillDocumentFromForm();

			ThemeDocument.Save(Theme, path);
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
				tsbImagesEdit.Enabled = false;
				tsbImagesRemove.Enabled = false;
				tsbImagesExport.Enabled = false;
				tslImageDetails.Text = String.Empty;
			}
			else {
				XmlElement image = Theme.Images.ElementAt(lvwImages.SelectedIndices[0]);
				Byte[] buffer = Convert.FromBase64String(image.InnerText);
				using (MemoryStream stream = new MemoryStream(buffer)) {
					pbxImage.Image = Image.FromStream(stream);
				}

				tsbImagesEdit.Enabled = true;
				tsbImagesRemove.Enabled = true;
				tsbImagesExport.Enabled = true;

				tslImageDetails.Text = String.Format(Strings.ImageDetails, buffer.Length, pbxImage.Image.Width, pbxImage.Image.Height);
			}
		}

		private void mnuViewPreview_Click(object sender, EventArgs e) {
			spcMain.Panel2Collapsed = !spcMain.Panel2Collapsed;
			mnuViewPreview.Checked = !spcMain.Panel2Collapsed;
			GeneratePreview();
		}

		private void tsbPreviewRefresh_Click(object sender, EventArgs e) {
			GeneratePreview();
		}

		private async void GeneratePreview() {
			if (!mnuViewPreview.Checked) {
				return;
			}

			mnuViewPreview.Enabled = false;
			tsbPreviewRefresh.Enabled = false;
			FillDocumentFromForm();

			PreviewCompiler renderer = new PreviewCompiler(Theme.Document);
			String html = await renderer.RenderAsync();

			wbPreview.DocumentText = html;
			_PreviewSource.Text = html;

			mnuViewPreview.Enabled = true;
			tsbPreviewRefresh.Enabled = true;
		}

		private void lvwStyles_SelectedIndexChanged(object sender, EventArgs e) {
			bool enabled = lvwStyles.SelectedIndices.Count > 0;
			tsbStylesEdit.Enabled = enabled;
			tsbStylesDelete.Enabled = enabled;
		}

		private void tsbImagesExport_Click(object sender, EventArgs e) {
			if (pbxImage.Image == null) {
				return;
			}
			
			if (sfdImagesExport.ShowDialog() != DialogResult.OK) {
				return;
			}

			String extension = Path.GetExtension(sfdImagesExport.FileName).Substring(1);
			ImageFormat format = SupportedImageFileTypes.FirstOrDefault(x => x.ToString() == extension);
			
			pbxImage.Image.Save(sfdImagesExport.FileName, format);
		}
	}
}
