using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace WebsiteBuilder.UI.Resources {
    class IconPack {

        public static IconPack Current { get; private set; }

        private readonly Dictionary<Icon, Image> _Images;

        private readonly Dictionary<Icon, System.Drawing.Icon> _Icons;

        private IconPack() {
            _Images = new Dictionary<Icon, Image>();
            _Icons = new Dictionary<Icon, System.Drawing.Icon>();
        }

        public Image GetImage(Icon icon) {
            Image image = null;
            _Images.TryGetValue(icon, out image);
            return image;
        }

        public System.Drawing.Icon GetIcon(Icon icon) {
            System.Drawing.Icon image = null;
            _Icons.TryGetValue(icon, out image);
            return image;
        }

        public static void LoadDefault() {
            Assembly assembly = Assembly.GetEntryAssembly();
            FileInfo file = new FileInfo(assembly.FullName);
            String path = Path.Combine(file.Directory.FullName, "Resources", "IconPacks", "Default.zip");
            Current = Load(path);
        }

        public static IconPack Load(String path) {
            IconPack pack = new IconPack();
            ZipArchive archive = ZipFile.OpenRead(path);

            foreach (ZipArchiveEntry entry in archive.Entries) {
                Icon icon;
                String name = Path.GetFileNameWithoutExtension(entry.Name);

                if (Enum.TryParse(name, true, out icon)) {
                    Image image = Image.FromStream(entry.Open());
                    
                    pack._Images.Add(icon, image);
                    pack._Icons.Add(icon, GetIcon(image));
                }
            }

            return pack;
        }

        private static System.Drawing.Icon GetIcon(Image image) {
            Bitmap bitmap = (Bitmap)image;
            System.Drawing.Icon icon = System.Drawing.Icon.FromHandle(bitmap.GetHicon());
            return icon;
        }

        public enum Icon {
            Add,
            Edit,
            Delete,
            Save,
            EditContent,
            Settings,
            Open,
            Page,
            Build,
            BuildAndRun,
            Close,
            AutoClose,
            InsertLink
        }
    }
}
