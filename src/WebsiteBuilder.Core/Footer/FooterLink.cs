using System;
using WebsiteBuilder.Core.Localization;

namespace WebsiteBuilder.Core.Footer {
    public class FooterLink {

        public LocalizedString Text { get; set; }

        public String Data { get; set; }

        public FooterLinkType Type { get; set; }

        public String Target { get; set; }

        public FooterLink() {
            Text = new LocalizedString();
        }
    }
}
