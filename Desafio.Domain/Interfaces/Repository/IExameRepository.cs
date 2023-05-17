using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repository
{
    public interface IExameRepository : IBaseRepository<Exame>
    {
        public IList<Exame> ListByNome(string nome);
        public IList<Exame> ListByTipoExameId(int tipoExameId);
    }
}
