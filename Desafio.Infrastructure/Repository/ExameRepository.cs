using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Repository
{
    public class ExameRepository : BaseRepository<Exame>, IExameRepository
    {
        public ExameRepository(AppDbContext context) : base(context)
        {
        }

        public override IList<Exame> ListAll()
        {
            return this._context.Set<Exame>()
                .Include(e => e.TipoExame)
                .ToList();
        }
        public IList<Exame> ListByNome(string nome)
        {
            return this._context.Set<Exame>()
                .Where(e => e.Nome.Contains(nome))
                .ToList();
        }
        public IList<Exame> ListByTipoExameId(int tipoExameId)
        {
            return this._context.Set<Exame>()
                .Where(e => e.TipoExameId == tipoExameId)
                .ToList();
        }
    }
}
