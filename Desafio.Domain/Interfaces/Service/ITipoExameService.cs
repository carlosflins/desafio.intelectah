using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Service
{
    public interface ITipoExameService : IBaseService<TipoExame>
    {
        public IList<TipoExame> ListByNome(string nome);
        public IList<TipoExame> ListByDescricao(string descricao);
    }
}
