using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using WebsiteBuilder.Interface.Icons;

namespace WebsiteBuilder.UI.Resources {
    class IconPack : IIconPack {

        public static IIconPack Current { get; private set; }

        private readonly Dictionary<IconPackIcon, Image> _Images;

        private readonly Dictionary<IconPackIcon, Icon> _Icons;

        private IconPack() {
            _Images = new Dictionary<IconPackIcon, Image>();
            _Icons = new Dictionary<IconPackIcon, Icon>();
        }

        public Image GetImage(IconPackIcon icon) {
            Image image = null;
            _Images.TryGetValue(icon, out image);
            return image;
        }

        public Icon GetIcon(IconPackIcon icon) {
            Icon image = null;
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
                IconPackIcon icon;
                String name = Path.GetFileNameWithoutExtension(entry.Name);

                if (Enum.TryParse(name, true, out icon)) {
                    Image image = Image.FromStream(entry.Open());
                    
                    pack._Images.Add(icon, image);
                    pack._Icons.Add(icon, GetIcon(image));
                }
            }

            return pack;
        }

        private static Icon GetIcon(Image image) {
            Bitmap bitmap = (Bitmap)image;
            Icon icon = Icon.FromHandle(bitmap.GetHicon());
            return icon;
        }
    }
}
