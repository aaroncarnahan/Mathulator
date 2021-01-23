using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security;
using System.Text;

namespace Mathulator
{
	public class User
	{
		public int UserId { get; set; }
		public string UserName { get; set; }
		public string UserPassword { get; set; }
	}
}
