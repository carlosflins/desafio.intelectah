using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Infrastructure.Repository
{
    public class PacienteRepository : BaseRepository<Paciente>, IPacienteRepository
    {
        public PacienteRepository(AppDbContext context) : base(context)
        {
        }

        public override void Add(Paciente obj)
        {
            if (obj != null && obj.CPF != null)
            { 
                if (ListByCpf(obj.CPF).ToList().Count <= 0)
                    base.Add(obj);
            }
        }
        public IList<Paciente> ListByNome(string nome)
        {
            if (nome == null) nome = "";

            IList<Paciente> pacientes = this._context.Set<Paciente>()
                .Where(p => p.Nome.Contains(nome))
                .ToList();

            return pacientes;
        }
        public IList<Paciente> ListByCpf(string cpf)
        {
            if (cpf == null) cpf = "";

            IList<Paciente> pacientes = this._context.Set<Paciente>()
                .Where(p => p.CPF.Contains(cpf))
                .ToList();

            return pacientes;
        }
        public IList<Paciente> ListByNomeAndCpf(string nome, string cpf)
        {
            if (nome == null) nome = "";
            if (cpf == null) cpf = "";

            IList<Paciente> pacientes = this._context.Set<Paciente>()
                .Where(p => p.Nome.Contains(nome) && p.CPF.Contains(cpf))
                .ToList();

            return pacientes;
        }
    }
}
