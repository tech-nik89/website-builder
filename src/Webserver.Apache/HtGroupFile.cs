using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebsiteStudio.Interface.Compiling.Security;

namespace WebsiteStudio.Webserver.Apache {
	class HtGroupFile : FileBase {

		private const String HtGroupFileName = ".htgroup";

		public HtGroupFile(String directoryPath)
			: base(Path.Combine(directoryPath, HtGroupFileName)) {
		}

		public void AddGroup(IGroup group, IEnumerable<IUser> users) {
			List<String> userNames = new List<String>();

			foreach (IUser user in users) {
				if (user.GroupMemberships.Contains(group)) {
					userNames.Add(user.Name);
				}
			}

			if (userNames.Count == 0) {
				return;
			}

			_Content.Append(group.Name);
			_Content.Append(":");
			_Content.Append(String.Join(" ", userNames));

			_Content.AppendLine();
		}

	}
}
