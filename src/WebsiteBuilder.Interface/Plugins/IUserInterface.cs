using System;

namespace WebsiteBuilder.Interface.Plugins {
    public interface IUserInterface {

        String Data { get; set; }

        void Insert(String str);

    }
}
