using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using Desafio.Infrastructure.Repository;
using FluentValidation;

namespace Desafio.Service.Services
{
    public class ExameService : BaseService<Exame>, IExameService
    {
        public ExameService(IBaseRepository<Exame> repository, IValidator<Exame> validator) : base(repository, validator)
        {
        }

        public IList<Exame> ListByNome(string nome)
        {
            return ((IExameRepository)this._repository).ListByNome(nome);
        }
        public IList<Exame> ListByTipoExameId(int tipoExameId)
        {
            return ((IExameRepository)this._repository).ListByTipoExameId(tipoExameId);
        }
    }
}
