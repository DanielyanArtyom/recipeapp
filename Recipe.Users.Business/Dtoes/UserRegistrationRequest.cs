namespace Recipe.Users.Business.Dtoes;

public class UserRegistrationRequest
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

}