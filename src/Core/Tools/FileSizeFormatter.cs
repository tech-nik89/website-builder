using System;
using System.Linq;

namespace WebsiteStudio.Core.Tools {
	public static class FileSizeFormatter {

		private static readonly String[] _Units = new String[] { "bytes", "KB", "MB", "GB", "TB", "PB" };

		private const String _Format = "{0} {1}";

		public static String FormatFileSize(this long size) {
			for (int i = 0; i < _Units.Length; i++) {
				if (size < 1024) {
					return String.Format(_Format, size, _Units[i]);
				}

				if (i < _Units.Length - 1) {
					size /= 1024;
				}
			}

			return String.Format(_Format, size, _Units.Last());
		}

	}
}
