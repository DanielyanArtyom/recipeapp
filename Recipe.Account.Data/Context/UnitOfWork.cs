using Recipe.Account.Data.Entity;
using Recipe.Account.Data.Interfaces;
using Recipe.Account.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Account.Data.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RecipeAccountContext _context;
        private IRepository<AccountEntity> _accounts;

        public UnitOfWork(RecipeAccountContext context)
        {
            this._context = context;
        }
        public IRepository<AccountEntity> Accounts
        {
            get
            {
                return this._accounts ??= new Repository<AccountEntity>(_context);
            }
        }

        public Task Complete()
        {
            return this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
