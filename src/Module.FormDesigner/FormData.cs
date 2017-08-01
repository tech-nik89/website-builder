using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WebsiteBuilder.Modules.FormDesigner.Data;

namespace WebsiteBuilder.Modules.FormDesigner {
	class FormData {

		private static readonly Encoding _Encoding = Encoding.UTF8;

		private static readonly JsonSerializerSettings _Settings = new JsonSerializerSettings() {
			TypeNameHandling = TypeNameHandling.Auto
		};
		
		public String Id { get; set; }

		public String SubmitButtonText { get; set; }

		public String TargetMailAddress { get; set; }

		public String TargetService { get; set; }

		public String SuccessMessage { get; set; }

		public List<FormDataItem> Items { get; private set; }

		public FormData() {
			Items = new List<FormDataItem>();
		}

		public static String Serialize(FormData data) {
			String json = JsonConvert.SerializeObject(data, _Settings);
			Byte[] buffer = _Encoding.GetBytes(json);
			return Convert.ToBase64String(buffer);
		}

		public static FormData Deserialize(String data) {
			if (String.IsNullOrWhiteSpace(data)) {
				return new FormData();
			}

			try {
				Byte[] buffer = Convert.FromBase64String(data);
				String json = _Encoding.GetString(buffer);
				return JsonConvert.DeserializeObject<FormData>(json, _Settings);
			}
			catch {
				return new FormData();
			}
		}

	}
}
