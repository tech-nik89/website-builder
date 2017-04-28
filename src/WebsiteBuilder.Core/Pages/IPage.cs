using System;

namespace WebsiteBuilder.Core.Pages {
    public interface IPage {

        String Id { get; }

        String PathName { get; }

        PageCollection Pages { get; }

        IPage Parent { get; }

    }
}
