using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public void Add(TEntity obj);
        public void Update(TEntity obj);
        public void Delete(int id);
        public IList<TEntity> ListAll();
        public TEntity GetById(int id);
    }
}
