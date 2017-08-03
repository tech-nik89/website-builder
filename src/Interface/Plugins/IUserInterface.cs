using System;

namespace WebsiteBuilder.Interface.Plugins {
	public interface IUserInterface {

		String Data { get; set; }

		bool Dirty { get; }

		void Insert(String str);

	}
}
