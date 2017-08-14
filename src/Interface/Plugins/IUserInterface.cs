using System;

namespace WebsiteStudio.Interface.Plugins {
	public interface IUserInterface {

		String Data { get; set; }

		bool Dirty { get; }
		
	}
}
