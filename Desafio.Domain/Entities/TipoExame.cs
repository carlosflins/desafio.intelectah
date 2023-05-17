namespace Desafio.Domain.Entities
{
    public class TipoExame : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public IList<Exame> Exames { get; set; }
        public IList<MarcacaoConsulta> MarcacoesConsulta { get; set; }

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
