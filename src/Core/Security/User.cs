using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebsiteStudio.Interface.Compiling.Security;

namespace WebsiteStudio.Core.Security {

	[DebuggerDisplay("{Name}")]
	public class User : IUser {

		private readonly Project _Project;

		private String _Name;
		public String Name {
			get => _Name;
			set { _Name = value; _Project.Dirty = true; }
		}

		private String _Password;
		public String Password {
			get => _Password;
			set { _Password = value; _Project.Dirty = true; }
		}

		public CustomCollection<Group> Memberships { get; private set; }

		public IEnumerable<IGroup> GroupMemberships => Memberships.Cast<IGroup>();

		internal User(Project project) {
			_Project = project;
			Memberships = new CustomCollection<Group>(_Project);
		}

		public void SetAndEncryptPassword(String plainPassword) {
			if (String.IsNullOrWhiteSpace(plainPassword)) {
				return;
			}

			using (SHA1 sha1 = SHA1.Create()) {
				var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(plainPassword));
				Password = String.Format("{{SHA}}{0}", Convert.ToBase64String(hash));
			}
		}
	}
}
