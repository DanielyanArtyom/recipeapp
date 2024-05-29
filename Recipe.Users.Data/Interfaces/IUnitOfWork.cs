using Recipe.Users.Data.Entity;
namespace Recipe.Users.Data.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IRepository<User> Users { get; }
    Task Complete();
}