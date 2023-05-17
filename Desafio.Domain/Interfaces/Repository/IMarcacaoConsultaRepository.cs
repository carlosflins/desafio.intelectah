using Desafio.Domain.Entities;
using System.Data;

namespace Desafio.Domain.Interfaces.Repository
{
    public interface IMarcacaoConsultaRepository : IBaseRepository<MarcacaoConsulta>
    {
        public IList<MarcacaoConsulta> ListByPacienteId(int pacienteId);
        public IList<MarcacaoConsulta> ListByTipoExameId(int tipoExameId);
        public IList<MarcacaoConsulta> ListByExameId(int exameId);
        public IList<MarcacaoConsulta> ListByProtocolo(string protocolo);
        public IList<MarcacaoConsulta> ListByDataHora(DateTime dataHora);
    }
}
