namespace Recipe.Users.Data.Entity;

public class User
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string password { get; set; }
}