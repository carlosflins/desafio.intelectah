namespace Desafio.Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public DateTime? DataNascimento { get; set; }
        public SexoEnum? Sexo { get; set; }
        public string? Telefone{ get; set; }
        public string? Email{ get; set; }

        public IList<MarcacaoConsulta>? MarcacoesConsulta{ get; set;  }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                return base.ToString();
            }

            return Nome;
        }
    }

    public enum SexoEnum
    {
        Masculino = 1,
        Feminino = 2
    }
}
