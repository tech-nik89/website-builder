using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebsiteBuilder.Modules.Toolbox {
	static class DataSerializer {

		public static String Serialize<T>(IEnumerable<T> data) where T : IItem {
			return JsonConvert.SerializeObject(data);
		}

		public static IEnumerable<T> Deserialize<T>(String data) where T : IItem {
			List<T> list = new List<T>();

			try {
				T[] items = JsonConvert.DeserializeObject<T[]>(data);
				if (items != null) {
					list.AddRange(items);
				}
			}
			catch {
			}

			return list;
		}

	}
}
