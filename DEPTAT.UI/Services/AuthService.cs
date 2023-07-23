using System.Security.Claims;
using DEPTAT.Application.Profiles;
using DEPTAT.Application.Responses;
using DEPTAT.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DEPTAT.UI.Services
{
	public class AuthService : IAuthService
	{
		private readonly DeptatDbContext _context;
		private readonly IHttpContextAccessor _httpContextAccessor;
		public AuthService(DeptatDbContext context, IHttpContextAccessor httpContextAccessor)
		{
			_context = context;
			_httpContextAccessor = httpContextAccessor;
		}


		public Task<BaseResponse<bool>> ChangePassword(int userId, string newPassword)
		{
			throw new System.NotImplementedException();
		}

		public Task<ApplicationUser> GetUserByUsername(string username)
		{
			throw new System.NotImplementedException();
		}

		public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);

		public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

		public async Task<BaseResponse<string>> Login(string username, string password)
		{
			var response = new BaseResponse<string>();
			var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()));
			if (user == null)
			{
				response.IsSuccess = false;
				response.Message = "Wrong Password.";
			}
			return response;
		}

		public Task<BaseResponse<int>> Register(ApplicationUser user, string password)
		{
			throw new System.NotImplementedException();
		}

		public Task<bool> UserExists(string username)
		{
			throw new System.NotImplementedException();
		}
	}
}
