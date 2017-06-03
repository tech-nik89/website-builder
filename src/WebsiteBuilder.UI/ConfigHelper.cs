using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WebsiteBuilder.Core;

namespace WebsiteBuilder.UI {
    static class ConfigHelper {

        private static Properties.Settings Settings => Properties.Settings.Default;

        private const int RecentListMaxLength = 6;

        public static void RestoreMainForm(Form form) {
            if (Settings.MainFormState > -1) {
                form.WindowState = (FormWindowState)Settings.MainFormState;
            }

            if (form.WindowState == FormWindowState.Normal) {
                if (Settings.MainFormHeight > -1) {
                    form.Height = Settings.MainFormHeight;
                }

                if (Settings.MainFormWidth > -1) {
                    form.Width = Settings.MainFormWidth;
                }

                if (Settings.MainFormX > -1) {
                    form.Left = Settings.MainFormX;
                }

                if (Settings.MainFormY > -1) {
                    form.Top = Settings.MainFormY;
                }
            }
        }

        public static void StoreMainForm(Form form) {
            Settings.MainFormState = (int)form.WindowState;
            Settings.MainFormHeight = form.Height;
            Settings.MainFormWidth = form.Width;
            Settings.MainFormX = form.Left;
            Settings.MainFormY = form.Top;
            Settings.Save();
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
    }
}
