using DEPTAT.Application.Profiles;
using DEPTAT.Application.Responses;

namespace DEPTAT.UI.Services
{
    public interface IAuthService
    {
        Task<BaseResponse<int>> Register(ApplicationUser user, string password);
        Task<bool> UserExists(string username);
        Task<BaseResponse<string>> Login(string username, string password);
        Task<BaseResponse<bool>> ChangePassword(int userId, string newPassword);
        int GetUserId();
        string GetUserEmail();
        Task<ApplicationUser> GetUserByUsername(string username);
	}
}
