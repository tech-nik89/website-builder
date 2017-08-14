using System.Drawing;

namespace WebsiteStudio.Interface.Icons {
	public interface IIconPack {

		Icon GetIcon(IconPackIcon icon);

		Image GetImage(IconPackIcon icon);

	}
}
