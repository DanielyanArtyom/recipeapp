using Recipe.Users.Data.Entity;
using Recipe.Users.Data.Interfaces;
using Recipe.Users.Data.Respository;

namespace Recipe.Users.Data.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly RecipeUserContext _context;
    private IRepository<User> _users;

    public UnitOfWork(RecipeUserContext context) 
    { 
        this._context = context; 
    }
    public IRepository<User> Users
    {
        get { 
            return this._users ??= new Repository<User>(_context);
        }
    }

    public int Complete()
    {
        return this._context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}