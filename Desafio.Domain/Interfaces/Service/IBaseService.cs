using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Domain.Interfaces.Service
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
        public void Delete(int id);
        public IList<TEntity> ListAll();
        public TEntity GetById(int id);
    }
}
