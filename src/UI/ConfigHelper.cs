using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebsiteStudio.Core;
using WebsiteStudio.UI.Forms;

namespace WebsiteStudio.UI {
	static class ConfigHelper {

		private static Properties.Settings Settings => Properties.Settings.Default;

		private const int RecentListMaxLength = 6;

		public static void RestoreMainForm(MainForm form) {
			RestoreForm(form, Settings.MainFormState, Settings.MainFormX, Settings.MainFormY, Settings.MainFormWidth, Settings.MainFormHeight);
		}

		public static void RestoreContentForm(PageContentForm form) {
			RestoreForm(form, Settings.ContentFormState, Settings.ContentFormX, Settings.ContentFormY, Settings.ContentFormWidth, Settings.ContentFormHeight);
		}

		private static void RestoreForm(Form form, int state, int x, int y, int width, int height) {
			if (state > -1) {
				form.WindowState = (FormWindowState)state;
			}

			if (form.WindowState == FormWindowState.Normal) {
				if (height > -1) {
					form.Height = height;
				}

				if (width > -1) {
					form.Width = width;
				}

				if (x > -1) {
					form.Left = x;
				}

				if (y > -1) {
					form.Top = y;
				}
			}
		}

		public static void StoreMainForm(MainForm form) {
			Settings.MainFormState = (int)form.WindowState;
			Settings.MainFormHeight = form.Height;
			Settings.MainFormWidth = form.Width;
			Settings.MainFormX = form.Left;
			Settings.MainFormY = form.Top;
		}

		public static void StoreContentForm(PageContentForm form) {
			Settings.ContentFormState = (int)form.WindowState;
			Settings.ContentFormHeight = form.Height;
			Settings.ContentFormWidth = form.Width;
			Settings.ContentFormX = form.Left;
			Settings.ContentFormY = form.Top;
		}

		public static void AddRecentProject(String path) {
			FileInfo info = new FileInfo(path);
			if (!info.Exists|| info.Extension != Project.FileExtension) {
				return;
			}

			Settings.RecentProjects.Remove(path);
			Settings.RecentProjects.Insert(0, path);

			while (Settings.RecentProjects.Count > RecentListMaxLength) {
				Settings.RecentProjects.RemoveAt(Settings.RecentProjects.Count - 1);
			}
		}

		public static void UpdateRecents(ToolStripMenuItem menuItem, Action<String> itemClick) {
			menuItem.DropDownItems.Clear();

			if (Settings.RecentProjects == null) {
				Settings.RecentProjects = new StringCollection();
			}
			
			String[] projects = Settings.RecentProjects
				.Cast<String>().Where(x => File.Exists(x)).ToArray();

			for (int i = 0; i < projects.Length; i++) {
				String path = projects[i];
				ToolStripItem item = new ToolStripMenuItem((i + 1) + " " + Path.GetFileName(path));

				item.Tag = path;
				item.Click += (sender, e) => {
					itemClick((String)((ToolStripMenuItem)sender).Tag);
				};

				menuItem.DropDownItems.Add(item);
			}

			menuItem.Enabled = projects.Any();
			Settings.RecentProjects.Clear();
			Settings.RecentProjects.AddRange(projects);
		}

		public static void Save() {
			Settings.Save();
		}
	}
}
