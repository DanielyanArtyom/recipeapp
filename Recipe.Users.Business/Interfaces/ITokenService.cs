using Recipe.Users.Business.Dtoes;

namespace Recipe.Users.Business.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(UserDTO user);
    }
}