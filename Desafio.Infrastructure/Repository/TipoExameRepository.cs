using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Repository
{
    public class TipoExameRepository : BaseRepository<TipoExame>, ITipoExameRepository
    {
        public TipoExameRepository(AppDbContext context) : base(context)
        {
        }

        public IList<TipoExame> ListByDescricao(string descricao)
        {
            if (descricao == null) descricao = "";

            return this._context.Set<TipoExame>()
                .Where(te => te.Descricao.Contains(descricao))
                .ToList();
        }

        public IList<TipoExame> ListByNome(string nome)
        {
            if (nome == null) nome = "";

            return this._context.Set<TipoExame>()
                .Where(te => te.Nome.Contains(nome))
                .ToList();
        }
    }
}
