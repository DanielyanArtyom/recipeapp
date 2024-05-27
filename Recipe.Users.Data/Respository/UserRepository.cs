using Microsoft.EntityFrameworkCore;
using Recipe.Users.Data.Context;
using Recipe.Users.Data.Entity;
using Recipe.Users.Data.Interfaces;

namespace Recipe.Users.Data.Respository;

public class UserRepository : IUserRepository
{
    private readonly RecipeUserContext _context;

    public UserRepository(RecipeUserContext context)
    {
        this._context = context;
    }

    public  void AddUser(User newUser)
    {
         this._context.Users.Add(newUser);
    }

    public User? GetUserById(Guid userId)
    {
        return  this._context.Users.Find(userId);
    }

    public User? GetUserByEmail(string email)
    {
        return this._context.Users.FirstOrDefault(u => u.Email == email);
    }

    public void UpdateUser(User user)
    {
        this._context.Users.Update(user);
    }

    public void RemoveUserById(Guid userId)
    {
        var user =  this.GetUserById(userId);

        if (user != null)
        {
            this._context.Users.Remove(user);
        }
    }

}