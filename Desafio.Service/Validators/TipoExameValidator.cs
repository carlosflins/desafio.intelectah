using Desafio.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Validators
{
    public class TipoExameValidator : AbstractValidator<TipoExame>
    {
        public TipoExameValidator()
        {
            RuleFor(tipoExame => tipoExame.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O Nome não pode conter mais que 100 caracteres.")
                .MinimumLength(2)
                .WithMessage("O Nome deve conter ao menos 2 caracteres.");

            RuleFor(tipoDeExame => tipoDeExame.Descricao)
                .MaximumLength(256)
                .WithMessage("A Descrição não pode conter mais que 256 caracteres.");

        }
    }
}
