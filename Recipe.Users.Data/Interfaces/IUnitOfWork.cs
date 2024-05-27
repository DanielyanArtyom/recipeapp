namespace Recipe.Users.Data.Interfaces;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    Task SaveAsync();
}