using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DEPTAT.Application.Models.Accounts
{
	public class LoginViewModel
	{
		[Required]
		public string Username { get; set; }
		

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Remember me?")]
		public bool RememberMe { get; set; }
		// The returnUrl property to store the URL to redirect the user after login
		public string ReturnUrl => "~/";
	}
}
