using Newtonsoft.Json;
using System;
using System.Text;

namespace WebsiteBuilder.Publish.FTP {
	class Settings {

		public String Host { get; set; }

		public int Port { get; set; }

		public EncryptionType Encryption { get; set; }

		public String UserName { get; set; }

		public String Password { get; set; }

		public static Settings Deserialize(String data) {
			try {
				return JsonConvert.DeserializeObject<Settings>(DecodeBas64(data));
			}
			catch {
				return new Settings();
			}
		}

		public static String Serialize(Settings settings) {
			return EncodeBase64(JsonConvert.SerializeObject(settings));
		}

		private static String EncodeBase64(String data) {
			Byte[] buffer = Encoding.UTF8.GetBytes(data);
			return Convert.ToBase64String(buffer);
		}

		private static String DecodeBas64(String data) {
			Byte[] buffer = Convert.FromBase64String(data);
			return Encoding.UTF8.GetString(buffer);
		}
	}
}
