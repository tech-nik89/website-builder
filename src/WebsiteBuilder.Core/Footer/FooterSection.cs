using System.Collections.Generic;
using WebsiteBuilder.Core.Localization;

namespace WebsiteBuilder.Core.Footer {
    public class FooterSection {

        public LocalizedString Title { get; set; }

        public List<FooterLink> Items { get; set; }

        public FooterSection() {
            Title = new LocalizedString();
            Items = new List<FooterLink>();
        }

    }
}
