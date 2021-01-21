using System;
using System.Collections.Generic;
using System.Text;

namespace Mathulator
{
	public class User
	{
		public string UserName { get; set; }
		public string UserPassword { get; set; }

		public User()
		{
			this.UserName = "User";
			this.UserPassword = "password";
		}
	}
}
