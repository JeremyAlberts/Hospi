using Hospi.Core.Models;

namespace Hopsi.Api.Interfaces
{
    public interface IAuthService
    {
        Task<string> Register(RegisterUserModel registerUserModel);
        Task<string> Login(LoginUserModel loginUserModel);
    }
}
