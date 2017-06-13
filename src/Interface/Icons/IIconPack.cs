using System.Drawing;

namespace WebsiteBuilder.Interface.Icons {
	public interface IIconPack {

		Icon GetIcon(IconPackIcon icon);

		Image GetImage(IconPackIcon icon);

	}
}
