using DEPTAT.Application.Profiles;
using DEPTAT.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Text.Encodings.Web;
using DEPTAT.Application.Constants;
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

		public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
			RoleManager<IdentityRole> roleManager, DeptatDbContext db)
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
		public async Task<IActionResult> Register(string? returnurl = null)
		{

			//ViewData["ReturnUrl"] = returnurl;
			RegisterViewModel registerViewModel = new RegisterViewModel();
			return View(registerViewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel model, string? returnurl = null)
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
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(AccountController.Login), "Account");
		}

		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error.Description);
			}
		}

		
		[HttpGet]

		//[ValidateAntiForgeryToken]
		public IActionResult Login(string? returnUrl = null)
		{
			// If returnUrl is not provided, set it to a default page (e.g., Home/Dashboard)
			returnUrl = returnUrl ?? Url.Content("~/Home/Dashboard");

			var model = new LoginViewModel
			{
				ReturnUrl = returnUrl
			};

			return View(model);
		}


		

		[HttpPost]
		[AllowAnonymous]
		//[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe,
					lockoutOnFailure: false);
				if (result.Succeeded)
				{
					// Redirect the user to the stored ReturnUrl after a successful login
					return LocalRedirect(model.ReturnUrl);
				}

				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
			}

			// If we reach here, it means there's an error, so return the view with the model
			return View(model);
		}


		public IActionResult Signout()
		{
			return View();
		}

		public async Task<IActionResult> GetUsers()
		{
			var userList = _db.Users.ToList();
			var userRole = _db.UserRoles.ToList();
			var roles = _db.Roles.ToList();
			foreach (var user in userList)
			{
				var role = userRole.FirstOrDefault(u => u.UserId == user.Id);
				if (role == null)
				{
					user.Role = "None";
				}
				else
				{
					user.Role = roles.FirstOrDefault(u => u.Id == role.RoleId).Name;
				}
			}

			return View(userList); ;
		}


		//[Authorize(Roles = "Admin")]
		public IActionResult Delete(string userId)
		{
			var objFromDb = _db.Users.FirstOrDefault(u => u.Id == userId);
			if (objFromDb == null)
			{
				return NotFound();
			}
			_db.Users.Remove(objFromDb);
			_db.SaveChanges();
			TempData[SD.Success] = "User deleted successfully.";
			return RedirectToAction(nameof(GetUsers));
		}


		//[Authorize(Roles = "Admin")]
		public IActionResult Edit(string userId)
		{
			var objFromDb = _db.Users.FirstOrDefault(u => u.Id == userId);
			if (objFromDb == null)
			{
				return NotFound();
			}
			var userRole = _db.UserRoles.ToList();
			var roles = _db.Roles.ToList();
			var role = userRole.FirstOrDefault(u => u.UserId == objFromDb.Id);
			if (role != null)
			{
				objFromDb.RoleId = roles.FirstOrDefault(u => u.Id == role.RoleId).Id;
			}
			objFromDb.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
			{
				Text = u.Name,
				Value = u.Id
			});
			return View(objFromDb);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		//[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Edit(ApplicationUser user)
		{
			if (ModelState.IsValid)
			{
				var objFromDb = _db.Users.FirstOrDefault(u => u.Id == user.Id);
				if (objFromDb == null)
				{
					return NotFound();
				}
				var userRole = _db.UserRoles.FirstOrDefault(u => u.UserId == objFromDb.Id);
				if (userRole != null)
				{
					var previousRoleName = _db.Roles.Where(u => u.Id == userRole.RoleId).Select(e => e.Name).FirstOrDefault();
					//removing the old role
					await _userManager.RemoveFromRoleAsync(objFromDb, previousRoleName);

				}

				//add new role
				await _userManager.AddToRoleAsync(objFromDb, _db.Roles.FirstOrDefault(u => u.Id == user.RoleId).Name);
				objFromDb.UserName = user.UserName;
				_db.SaveChanges();
				TempData[SD.Success] = "User has been edited successfully.";
				return RedirectToAction(nameof(GetUsers));
				// return Ok();
			}


			user.RoleList = _db.Roles.Select(u => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
			{
				Text = u.Name,
				Value = u.Id
			});
			return View(user);
		}

	}
}
