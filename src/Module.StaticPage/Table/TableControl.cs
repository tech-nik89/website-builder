using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using WebsiteStudio.Interface.Icons;
using WebsiteStudio.Interface.Plugins;
using WebsiteStudio.Modules.Localization;

namespace WebsiteStudio.Modules.Table {
	public partial class TableControl : UserControl, IUserInterface {

		private static readonly ResourceManager _ResourceManager = new ResourceManager("WebsiteStudio.Modules.Localization.Strings", typeof(TableControl).Assembly);

		private static readonly Dictionary<String, String> _ColumnDelimiters = new Dictionary<String, String>() {
			{ "|", "Pipe" },
			{ ";", "Semicolon" },
			{ ",", "Comma" },
			{ "\t", "Tab" }
		};

		private const String _ColumnDelimiterFormat = "{0} ({1})";

		private readonly IPluginHelper _PluginHelper;

		public bool Dirty { get; private set; }

		private TableData _Data;

		public String Data {
			get {
				Dirty = false;

				_Data.Data = txtData.Text;
				_Data.ColumnDelimiter = _ColumnDelimiters.Keys.ElementAt(tscColumnDelimiter.SelectedIndex);
				_Data.HeaderPosition = (HeaderPosition)tscHeaderPosition.SelectedIndex;

				return TableData.Serialize(_Data);
			}
			set {
				_Data = TableData.Derserialize(value);
				txtData.Text = _Data.Data;

				tscColumnDelimiter.SelectedIndex = GetKeyIndex(_Data.ColumnDelimiter, _ColumnDelimiters);
				tscHeaderPosition.SelectedIndex = (int)_Data.HeaderPosition;

				Dirty = false;
			}
		}
		
		public TableControl(IPluginHelper pluginHelper) {
			InitializeComponent();
			LocalizeComponent();
			FillHeaderPositions();
			FillColumnDelimiters();

			_Data = new TableData();
			_PluginHelper = pluginHelper;

			ApplyIcons();
		}

		private void ApplyIcons() {
			IIconPack iconPack = _PluginHelper.GetIconPack();
			if (iconPack == null) {
				return;
			}

			tsbInsertLink.Image = iconPack.GetImage(IconPackIcon.InsertLink);
		}

		private void FillColumnDelimiters() {
			tscColumnDelimiter.Items.Clear();

			foreach(var item in _ColumnDelimiters) {
				String text = String.Format(_ColumnDelimiterFormat, item.Key, _ResourceManager.GetString(item.Value));
				tscColumnDelimiter.Items.Add(text);
			}
		}

		private void FillHeaderPositions() {
			tscHeaderPosition.Items.Clear();

			String[] names = Enum.GetNames(typeof(HeaderPosition));
			foreach(String name in names) {
				tscHeaderPosition.Items.Add(_ResourceManager.GetString(name));
			}
		}

		private void LocalizeComponent() {
			tslColumnDelimiter.Text = Strings.ColumnDelimiter + ":";
			tslHeaderPosition.Text = Strings.HeaderPosition + ":";
			tsbInsertLink.Text = Strings.InsertLink;
		}
		
		private static int GetKeyIndex<TKey, TValue>(TKey key, Dictionary<TKey, TValue> dictionary) {
			for(int i = 0; i < dictionary.Count; i++) {
				if (key.Equals(dictionary.Keys.ElementAt(i))) {
					return i;
				}
			}

			return -1;
		}

		private void txtData_TextChanged(object sender, EventArgs e) {
			Dirty = true;
		}

		private void tsbInsertLink_Click(object sender, EventArgs e) {
			String link = _PluginHelper.GetLink();
			if (String.IsNullOrWhiteSpace(link)) {
				return;
			}

			int selectionIndex = txtData.SelectionStart;
			txtData.Text = txtData.Text.Insert(selectionIndex, link);
			txtData.SelectionStart = selectionIndex + link.Length;
		}
	}
}
