using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Repository
{
    public interface IPacienteRepository : IBaseRepository<Paciente>
    {
        public IList<Paciente> ListByNome(string nome);
        public IList<Paciente> ListByCpf(string cpf);
        public IList<Paciente> ListByNomeAndCpf(string nome, string cpf);
    }
}
