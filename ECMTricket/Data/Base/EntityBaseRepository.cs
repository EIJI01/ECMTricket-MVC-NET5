using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading.Tasks;

namespace ECMTricket.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;

        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync(); 
        }

        public async Task Delete(T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<System.Collections.Generic.IEnumerable<T>> GetAll() => await _context.Set<T>().ToListAsync();

        public async Task<T> GetById(int id) => await _context.Set<T>().FirstOrDefaultAsync<T>(t => t.Id == id);

        public async Task Update(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
