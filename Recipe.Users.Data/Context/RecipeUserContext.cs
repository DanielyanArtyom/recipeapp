using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipe.Users.Data.Entity;

namespace Recipe.Users.Data.Context;

public class RecipeUserContext : DbContext
{
    public RecipeUserContext(DbContextOptions<RecipeUserContext> options)
        : base(options){}
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}