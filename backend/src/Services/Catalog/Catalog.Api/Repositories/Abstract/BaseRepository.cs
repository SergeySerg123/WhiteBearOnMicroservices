using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WhiteBear.Services.Catalog.Api.Data.Context;
using WhiteBear.Services.Catalog.Api.Data.Entities;
using WhiteBear.Services.Catalog.Api.Data.Entities.Abstraction;

namespace WhiteBear.Services.Catalog.Api.Repositories.Abstract
{
    public abstract class BaseRepository<T> where T : BaseEntity
    {
        private protected readonly CatalogContext _context;

        protected BaseRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<T> CreateEntity(T entity) 
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<T> UpdateEntity(T entity)
        {
            var result = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<T> DeleteEntity(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
