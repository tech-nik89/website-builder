using WebsiteBuilder.Interface.Icons;

namespace WebsiteBuilder.Interface.Plugins {
    public interface IPluginHelper {

        IEditor CreateEditor();

        IIconPack GetIconPack();

    }
}
