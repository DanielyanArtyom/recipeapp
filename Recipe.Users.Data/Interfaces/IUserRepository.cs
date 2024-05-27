using Recipe.Users.Data.Entity;

namespace Recipe.Users.Data.Interfaces;

public interface IUserRepository
{
    public  void AddUser(User newUser);
    public User? GetUserById(Guid userId);
    
    public User? GetUserByEmail(string email);

    public  void UpdateUser(User user);
    public void RemoveUserById(Guid userId);
}