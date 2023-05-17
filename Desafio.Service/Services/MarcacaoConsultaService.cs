using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using Desafio.Infrastructure.Repository;
using FluentValidation;

namespace Desafio.Service.Services
{
    public class MarcacaoConsultaService : BaseService<MarcacaoConsulta>, IMarcacaoConsultaService
    {
        public MarcacaoConsultaService(IBaseRepository<MarcacaoConsulta> repository, IValidator<MarcacaoConsulta> validator) : base(repository, validator)
        {
        }
        
        public override MarcacaoConsulta Add<MarcacaoConsultaValidator>(MarcacaoConsulta obj)
        {
            this.Validate(obj, this._validator);
            obj.Protocolo = GetNumeroProtocolo(obj);
            obj.PacienteId = obj.Paciente.Id;
            obj.Paciente = null;
            _repository.Add(obj);
            return obj;
        }

        public IList<MarcacaoConsulta> ListByDataHora(DateTime dataHora)
        {
            return ((IMarcacaoConsultaRepository)this._repository).ListByDataHora(dataHora);
        }

        public IList<MarcacaoConsulta> ListByExameId(int exameId)
        {
            return ((IMarcacaoConsultaRepository)this._repository).ListByExameId(exameId);
        }
        public IList<MarcacaoConsulta> ListByPacienteId(int pacienteId)
        {
            return ((IMarcacaoConsultaRepository)this._repository).ListByPacienteId(pacienteId);
        }
        public IList<MarcacaoConsulta> ListByProtocolo(string protocolo)
        {
            return ((IMarcacaoConsultaRepository)this._repository).ListByProtocolo(protocolo);
        }
        public IList<MarcacaoConsulta> ListByTipoExameId(int tipoExameId)
        {
            return ((IMarcacaoConsultaRepository)this._repository).ListByTipoExameId(tipoExameId);
        }
        private string GetNumeroProtocolo(MarcacaoConsulta obj)
        {
            string protocolo = DateTime.Now.ToString("yyyyMMddHHmmss");
            protocolo += obj.PacienteId.ToString();
            protocolo += obj.ExameId.ToString();

            return protocolo;
        }
    }
}
