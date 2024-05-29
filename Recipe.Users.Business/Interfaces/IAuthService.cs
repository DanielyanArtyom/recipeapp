using Recipe.Users.Business.Dtoes;

namespace Recipe.Users.Business.Interfaces
{
    public interface IAuthService
    {
        UserResponse Login(UserLoginRequest request);
        Task<UserResponse> Registration(UserRegistrationRequest requestedUser);
    }
}