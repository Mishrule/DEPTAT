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

		//[HttpGet]
		//public async Task<IActionResult> Register()
		//{
		//	RegisterViewModel registerViewModel = new RegisterViewModel();
		//	return View(registerViewModel);
		//}

		//[HttpPost]
		//[ValidateAntiForgeryToken]
		//public async Task<IActionResult> Register(RegisterViewModel model)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		var user = new ApplicationUser
		//		{
		//			UserName = model.Username, 
		//			Email = model.Email, 
		//			FirstName = model.FirstName,
		//			Othername = model.Othername,
		//			LastName = model.LastName,

		//		};
		//		var result = await _userManager.CreateAsync(user, model.Password);
		//		if (result.Succeeded)
		//		{
		//			await _signInManager.SignInAsync(user, isPersistent: false);
		//			return RedirectToAction("Index", "Home");
		//		}
		//		AddErrors(result);
		//	}


		//	return View(model);
		//}

		[HttpGet]
		public async Task<IActionResult> Register(string returnurl = null)
		{

			ViewData["ReturnUrl"] = returnurl;
			RegisterViewModel registerViewModel = new RegisterViewModel();
			return View(registerViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string returnurl = null)
		{

			ViewData["ReturnUrl"] = returnurl;
			returnurl = returnurl ?? Url.Content("Home/Dashboard");
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
					return LocalRedirect(returnurl);
				}
				AddErrors(result);
			}


			return View(model);
		}




		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> LogOff()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(HomeController.Index), "Home");
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}

		[HttpGet]
		public IActionResult Login(string returnurl = "Home/Dashboard")
		{
			ViewData["ReturnUrl"] = returnurl;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model, string returnurl = null)
		{
			returnurl = returnurl ?? Url.Content("/Home/Dashboard");
			ViewData["ReturnUrl"] = returnurl;
			// returnurl = returnurl ?? Url.Content("/Account/ResetPassword");
			
            if (ModelState.IsValid)
			{
				// Check if the returnUrl is a local URL
				if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
				{
					var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
					//return LocalRedirect(returnurl);
					return LocalRedirect(model.ReturnUrl);
				}
				else
				{
					// If the returnUrl is not a local URL or is empty, redirect to a default local URL
					return RedirectToAction("Index", "Home");
				}
				
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View(model);
			}


			return View(model);
		}

	}

}
