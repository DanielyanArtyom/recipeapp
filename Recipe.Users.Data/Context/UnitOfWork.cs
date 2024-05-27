using Recipe.Users.Data.Interfaces;
using Recipe.Users.Data.Respository;

namespace Recipe.Users.Data.Context;

public class UnitOfWork
{
    private readonly RecipeUserContext _context;
    private readonly IUserRepository _userRepository;
    
    public UnitOfWork(RecipeUserContext context)
    {
        this._context = context;
        this._userRepository = new UserRepository(this._context);
    }
    public IUserRepository UserRepository => this._userRepository;
    
    public async Task SaveAsync()
    {
        await this._context.SaveChangesAsync();
    }
}