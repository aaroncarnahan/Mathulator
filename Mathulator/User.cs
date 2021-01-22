using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Mathulator
{
	public class User
	{
		[Key]
		public string UserName { get; set; }
		public string UserPassword { get; set; }

		public User()
		{
			this.UserName = "User";
			this.UserPassword = "password";
		}
	}
}
