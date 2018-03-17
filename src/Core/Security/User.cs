using System;
using System.Security.Cryptography;
using System.Text;

namespace WebsiteStudio.Core.Security {
	public class User {

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

		internal User(Project project) {
			_Project = project;
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
