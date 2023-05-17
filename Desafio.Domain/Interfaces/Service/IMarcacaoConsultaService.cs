using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Service
{
    public interface IMarcacaoConsultaService : IBaseService<MarcacaoConsulta>
    {
        public IList<MarcacaoConsulta> ListByPacienteId(int pacienteId);
        public IList<MarcacaoConsulta> ListByTipoExameId(int tipoExameId);
        public IList<MarcacaoConsulta> ListByExameId(int exameId);
        public IList<MarcacaoConsulta> ListByProtocolo(string protocolo);
        public IList<MarcacaoConsulta> ListByDataHora(DateTime dataHora);
    }
}
