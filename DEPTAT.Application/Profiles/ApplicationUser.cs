
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPTAT.Application.Profiles
{
	public class ApplicationUser : IdentityUser
	{
		//public string Id { get; set; }
		//public string Username { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; } = string.Empty;
		public string Othername { get; set; } = string.Empty;
		public string LastName { get; set; } = string.Empty;
		public string Name => LastName + ", " + FirstName + " " + LastName + " " + Othername;
		[NotMapped]
		public string RoleId { get; set; }
		[NotMapped]
		public string Role { get; set; }
		[NotMapped]
		public IEnumerable<SelectListItem>? RoleList { get; set; }

	}
}
