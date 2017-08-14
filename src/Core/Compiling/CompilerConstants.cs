using System;
using System.Text.RegularExpressions;

namespace WebsiteStudio.Core.Compiling {
	public class CompilerConstants {

		private const String HexRegexPattern = "[0-9a-f]";
		private static readonly String GuidRegexPattern = String.Format("{0}{{8}}-{0}{{4}}-{0}{{4}}-{0}{{4}}-{0}{{12}}", HexRegexPattern);

		public static readonly Regex MediaLinkRegex = new Regex(String.Format(@"@Media\(({0})\)", GuidRegexPattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public const String MediaLinkFormat = "@Media({0})";

		public static readonly Regex PageLinkRegex = new Regex(String.Format(@"@Page\(({0})\)", GuidRegexPattern), RegexOptions.Compiled | RegexOptions.IgnoreCase);
		public const String PageLinkFormat = "@Page({0})";

	}
}
