using Microsoft.EntityFrameworkCore;
using Recipe.Users.Data.Context;
using Recipe.Users.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Users.Data.Respository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly RecipeUserContext _context;
        private readonly DbSet<T> _dbSet;


        public Repository(RecipeUserContext context)
        {
            _context = context; _dbSet = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T? GetBy(Func<T, bool> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
