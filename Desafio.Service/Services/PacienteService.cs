using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using Desafio.Infrastructure.Repository;
using FluentValidation;

namespace Desafio.Service.Services
{
    public class PacienteService : BaseService<Paciente>, IPacienteService
    {
        public PacienteService(IBaseRepository<Paciente> repository, IValidator<Paciente> validator) : base(repository, validator)
        {
        }

        public IList<Paciente> ListByNome(string nome)
        {
            return ((IPacienteRepository)this._repository).ListByNome(nome);
        }

        public IList<Paciente> ListByCpf(string cpf)
        {
            return ((IPacienteRepository)this._repository).ListByCpf(cpf);
        }

        public IList<Paciente> ListByNomeAndCpf(string nome, string cpf)
        {
            return ((IPacienteRepository)this._repository).ListByNomeAndCpf(nome, cpf);
        }
    }
}
