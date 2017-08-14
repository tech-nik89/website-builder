using System;
using System.Collections.Generic;
using System.Linq;
using WebsiteStudio.Interface.Compiling;
using WebsiteStudio.Interface.Plugins;

namespace WebsiteStudio.Modules.Table {

	[PluginInfo("Table", Author = "tech-nik89")]
	public class TableModule : IModule {

		private readonly IPluginHelper _PluginHelper;

		public TableModule(IPluginHelper pluginHelper) {
			_PluginHelper = pluginHelper;
		}

		public String Compile(String source, ICompileHelper compileHelper) {
			try {
				IEditor editor = _PluginHelper.CreateEditor();
				TableData data = TableData.Derserialize(source);

				String[,] cells = GetTable(data);
				int rowCount = cells.GetLength(0);
				int colCount = cells.GetLength(1);
				IHtmlElement table = compileHelper.CreateHtmlElement("table");

				for (int row = 0; row < rowCount; row++) {
					IHtmlElement tr = compileHelper.CreateHtmlElement("tr");
					table.AppendChild(tr);

					for (int col = 0; col < colCount; col++) {
						IHtmlElement td = GetCell(compileHelper, data.HeaderPosition, row, col);
						td.Content = editor.Compile(cells[row, col]);
						tr.AppendChild(td);
					}
				}

				return compileHelper.Compile(table);
			}
			catch {
				return String.Empty;
			}
		}

		private static IHtmlElement GetCell(ICompileHelper helper, HeaderPosition position, int row, int col) {
			if (position == HeaderPosition.Top && row == 0) {
				return helper.CreateHtmlElement("th");
			}

			if (position == HeaderPosition.Left && col == 0) {
				return helper.CreateHtmlElement("th");
			}

			return helper.CreateHtmlElement("td");
		}

		private static String[,] GetTable(TableData data) {
			if (String.IsNullOrWhiteSpace(data.Data)) {
				return new String[0, 0];
			}

			String[] rowSeparator = new String[] { Environment.NewLine };
			String[] colSeparator = new String[] { data.ColumnDelimiter };
			String[] dataRows = data.Data.Split(rowSeparator, StringSplitOptions.RemoveEmptyEntries);
			List<String[]> rows = new List<String[]>();

			foreach(String row in dataRows) {
				rows.Add(row.Split(colSeparator, StringSplitOptions.RemoveEmptyEntries));
			}

			int rowCount = rows.Count;
			int colCount = rows.Max(x => x.Length);
			String[,] cells = new String[rowCount, colCount];

			for (int row = 0; row < rowCount; row++) {
				for (int col = 0; col < colCount; col++) {
					if (col >= rows[row].Length) {
						continue;
					}

					cells[row, col] = rows[row][col]?.Trim() ?? String.Empty;
				}
			}

			return cells;
		}

		public IUserInterface GetUserInterface() {
			return new TableControl(_PluginHelper);
		}

	}
}
