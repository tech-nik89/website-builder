using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteBuilder.Interface.Plugins {
    public interface IPluginHelper {

        IEditor CreateEditor();

    }
}
