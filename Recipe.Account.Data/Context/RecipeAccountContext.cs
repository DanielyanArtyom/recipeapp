using Microsoft.EntityFrameworkCore;
using Recipe.Account.Data.Entity;

namespace Recipe.Account.Data.Context
{
    public class RecipeAccountContext : DbContext
    {
        public RecipeAccountContext(DbContextOptions<RecipeAccountContext> options)
       : base(options) { }

        public DbSet<AccountEntity> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
