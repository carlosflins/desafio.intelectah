using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Domain.Entities
{
    public class MarcacaoConsulta : BaseEntity
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int TipoExameId { get; set; }
        public TipoExame TipoExame { get; set; }

        public int ExameId { get; set; }
        public Exame Exame { get; set; }

        public DateTime DataHoraMarcacao { get; set; }
        public string Protocolo { get; set; }
    }
}
