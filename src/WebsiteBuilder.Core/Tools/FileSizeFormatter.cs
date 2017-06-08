using System.Linq;

namespace WebsiteBuilder.Core.Tools {
	public static class FileSizeFormatter {

		private static readonly string[] _Units = new string[] { "bytes", "KB", "MB", "GB", "TB", "PB" };

		private const string _Format = "{0} {1}";

		public static string FormatFileSize(this long size) {
			for (int i = 0; i < _Units.Length; i++) {
				if (size < 1024) {
					return string.Format(_Format, size, _Units[i]);
				}

				if (i < _Units.Length - 1) {
					size /= 1024;
				}
			}

			return string.Format(_Format, size, _Units.Last());
		}

	}
}
