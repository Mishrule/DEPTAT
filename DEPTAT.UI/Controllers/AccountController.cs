using DEPTAT.Application.Profiles;
using DEPTAT.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Text.Encodings.Web;
using DEPTAT.Application.Models;
using DEPTAT.Application.Models.Accounts;

namespace DEPTAT.UI.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly DeptatDbContext _db;

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, DeptatDbContext db)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_db = db;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Register()
		{
			RegisterViewModel registerViewModel = new RegisterViewModel();
			return View(registerViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = model.Username, 
					Email = model.Email, 
					FirstName = model.FirstName,
					Othername = model.Othername,
					LastName = model.LastName,
					
				};
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
				}
				AddErrors(result);
			}


			return View(model);
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}



	}

}
