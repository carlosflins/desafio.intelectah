using Desafio.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Validators
{
    public class ExameValidator : AbstractValidator<Exame>
    {
        public ExameValidator()
        {
            RuleFor(exame => exame.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O Nome não pode conter mais que 100 caracteres.")
                .MinimumLength(2)
                .WithMessage("O Nome deve conter ao menos 2 caracteres.");

            RuleFor(exame => exame.Observacoes)
                .MaximumLength(1000)
                .WithMessage("A Observação não pode conter mais que 1000 caracteres.");

            RuleFor(exame => exame.TipoExameId)
                .NotEmpty()
                .WithMessage("O Tipo de Exame é obrigatório.");
        }
    }
}
