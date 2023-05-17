using Desafio.Domain.Entities;
using FluentValidation;

namespace Desafio.Service.Validators
{
    public class MarcacaoConsultaValidator : AbstractValidator<MarcacaoConsulta>
    {
        public MarcacaoConsultaValidator()
        {
            RuleFor(marcacaoConsulta => marcacaoConsulta.PacienteId)
                .NotEmpty()
                .WithMessage("O Paciente é obrigatório.");

            RuleFor(marcacaoConsulta => marcacaoConsulta.TipoExameId)
                .NotEmpty()
                .WithMessage("O Tipo de Exame é obrigatório.");

            RuleFor(marcacaoConsulta => marcacaoConsulta.ExameId)
                .NotEmpty()
                .WithMessage("O Exame é obrigatório.");

            RuleFor(marcacaoConsulta => marcacaoConsulta.DataHoraMarcacao)
                .NotEmpty()
                .WithMessage("A Data e Hora é obrigatório.")
                .GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Data selecionada é inválida.");
        }
    }
}
