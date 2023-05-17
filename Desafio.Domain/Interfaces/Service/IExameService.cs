using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Service
{
    public interface IExameService : IBaseService<Exame>
    {
        public IList<Exame> ListByNome(string nome);
        public IList<Exame> ListByTipoExameId(int tipoExameId);
    }
}
