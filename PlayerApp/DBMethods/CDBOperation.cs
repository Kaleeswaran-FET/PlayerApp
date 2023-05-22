using Microsoft.EntityFrameworkCore;

namespace PlayerApp.DBMethods
{
    public class CDBOperation<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _entities;
        private readonly GeneralDbContext _context;

        public CDBOperation(GeneralDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Insert(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
    }
}
