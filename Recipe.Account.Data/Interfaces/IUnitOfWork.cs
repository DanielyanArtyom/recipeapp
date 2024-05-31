using Recipe.Account.Data.Entity;
using Recipe.Account.Data.Interfaces;

namespace Recipe.Account.Data.Context
{
    public interface IUnitOfWork
    {
        IRepository<AccountEntity> Accounts { get; }

        Task Complete();
        void Dispose();
    }
}