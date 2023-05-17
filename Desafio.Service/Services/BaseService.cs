using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using FluentValidation;

namespace Desafio.Service.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity, new()
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IValidator<TEntity> _validator;
        public BaseService(IBaseRepository<TEntity> repository, IValidator<TEntity> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public virtual TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, this._validator);
            _repository.Add(obj);
            return obj;
        }
        public virtual void Delete(int id) => _repository.Delete(id);
        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public IList<TEntity> ListAll()
        {
            return _repository.ListAll();
        }       
        public virtual TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, this._validator);
            _repository.Update(obj);
            return obj;
        }
        protected virtual void Validate(TEntity obj, IValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
