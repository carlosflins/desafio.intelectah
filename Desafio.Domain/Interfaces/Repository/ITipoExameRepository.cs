using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repository
{
    public interface ITipoExameRepository : IBaseRepository<TipoExame>
    {
        public IList<TipoExame> ListByNome(string nome);
        public IList<TipoExame> ListByDescricao(string descricao);
    }
}
