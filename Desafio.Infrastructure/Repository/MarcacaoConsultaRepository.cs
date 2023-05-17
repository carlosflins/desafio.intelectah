using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Repository
{
    public class MarcacaoConsultaRepository : BaseRepository<MarcacaoConsulta>, IMarcacaoConsultaRepository
    {
        public MarcacaoConsultaRepository(AppDbContext context) : base(context)
        {
        }
        public override IList<MarcacaoConsulta> ListAll()
        {
            return this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .ToList();
        }
        public override MarcacaoConsulta GetById(int id)
        {
            IList<MarcacaoConsulta> marcacoes = this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.Id == id).ToList();

            if (marcacoes.Count > 0)
                return marcacoes[0];
            else
                return null;
        }
        public IList<MarcacaoConsulta> ListByDataHora(DateTime dataHora)
        {
            return this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.DataHoraMarcacao == dataHora)
                .ToList();
        }

        public IList<MarcacaoConsulta> ListByExameId(int exameId)
        {
            return this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.ExameId == exameId)
                .ToList();
        }
        public IList<MarcacaoConsulta> ListByPacienteId(int pacienteId)
        {
            IList<MarcacaoConsulta> marcacoes = this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.PacienteId == pacienteId).ToList()
                .ToList();

            return marcacoes;
        }

        public IList<MarcacaoConsulta> ListByProtocolo(string protocolo)
        {
            IList<MarcacaoConsulta> marcacoes = this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.Protocolo == protocolo)
                .ToList();

            return marcacoes;
        }

        public IList<MarcacaoConsulta> ListByTipoExameId(int tipoExameId)
        {
            IList<MarcacaoConsulta> marcacoes = this._context.Set<MarcacaoConsulta>()
                .Include(mc => mc.TipoExame)
                .Include(mc => mc.Exame)
                .Include(mc => mc.Paciente)
                .Where(mc => mc.TipoExameId == tipoExameId).ToList();

            return marcacoes;
        }
    }
}
