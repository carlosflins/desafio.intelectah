namespace Desafio.Domain.Entities
{
    public class Exame : BaseEntity
    {
        public string? Nome { get; set; }
        public string? Observacoes { get; set; }

        public int TipoExameId { get; set; }
        public TipoExame? TipoExame { get; set; }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Nome))
            {
                return base.ToString();
            }

            return Nome;
        }
    }
}
