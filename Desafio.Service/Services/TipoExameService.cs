using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using FluentValidation;

namespace Desafio.Service.Services
{
    public class TipoExameService : BaseService<TipoExame>, ITipoExameService
    {
        public TipoExameService(IBaseRepository<TipoExame> repository, IValidator<TipoExame> validator) : base(repository, validator)
        {
        }
        
        public IList<TipoExame> ListByDescricao(string descricao)
        {
            return ((ITipoExameRepository)this._repository).ListByDescricao(descricao);
        }
        public IList<TipoExame> ListByNome(string nome)
        {
            return ((ITipoExameRepository)this._repository).ListByNome(nome);
        }
    }
}
