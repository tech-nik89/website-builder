using System;
using System.Collections.Generic;

namespace WebsiteStudio.Modules.FormDesigner.Services {
	abstract class Service {

		private readonly FormData _Data;

		protected FormData Data => _Data;

		public abstract String GetUrl();

		private static readonly Dictionary<String, Type> _Services = new Dictionary<String, Type> {
			{ "formspree.io", typeof(FormSpreeService) }
		};

		public static IReadOnlyDictionary<String, Type> Services {
			get => _Services;
		}

		public static Service GetService(String key, FormData data) {
			Type type = _Services[key];
			return (Service)Activator.CreateInstance(type, data);
		}

		public Service(FormData data) {
			_Data = data;
		}

	}
}
