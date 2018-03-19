using System;
using System.Collections.Generic;

namespace WebsiteStudio.Interface.Compiling.Security {
	public interface IUser {

		String Name { get; }

		String Password { get; }

		IEnumerable<IGroup> GroupMemberships { get; }

	}
}
