using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            _context.Set<TEntity>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public virtual IList<TEntity> ListAll() =>
            _context.Set<TEntity>().ToList();
        
        public virtual TEntity GetById(int id) =>
            _context.Set<TEntity>().Find(id);
    }
}
