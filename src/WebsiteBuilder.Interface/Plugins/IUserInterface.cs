using System;

namespace WebsiteBuilder.Interface.Plugins {
    public interface IUserInterface {

        String Data { get; set; }

        void ApplyMediaLink(String str);

        bool SupportsMediaLinks { get; }

    }
}
