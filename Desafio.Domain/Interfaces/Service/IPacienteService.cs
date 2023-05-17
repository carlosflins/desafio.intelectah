using Desafio.Domain.Entities;

namespace Desafio.Domain.Interfaces.Service
{
    public interface IPacienteService : IBaseService<Paciente>
    {
        public IList<Paciente> ListByNome(string nome);
        public IList<Paciente> ListByCpf(string cpf);
        public Paciente FindByCpf(string cpf);
        public IList<Paciente> ListByNomeAndCpf(string nome, string cpf);
    }
}
