using Microsoft.EntityFrameworkCore;
using ShopWebApp.Core.Interfaces;
using ShopWebApp.Infrastrcuture.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopWebApp.Infrastrcuture.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ShopContext _context;

        public GenericRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return (await _context.Set<T>().FindAsync(id))!;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }
    }
}
