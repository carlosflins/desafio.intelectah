using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Repository;
using Desafio.Domain.Interfaces.Service;
using Desafio.Service.Utils;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Service.Validators
{
    public class PacienteValidator : AbstractValidator<Paciente>
    {
       
        public PacienteValidator()
        {
            RuleFor(paciente => paciente.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .MaximumLength(100)
                .WithMessage("O Nome não pode conter mais que 100 caracteres");

            RuleFor(paciente => paciente.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(Utils.RegexUtils.GetCPFValidationRegex())
                .WithMessage("CPF inválido.")
                .Must(Validation.IsCpf)
                .WithMessage("CPF inválido.");
                

            RuleFor(paciente => paciente.DataNascimento)
                .NotEmpty().WithMessage("A Data de Nascimento é obrigatória.")
                .GreaterThan(paciente => DateTime.Now.AddYears(-130))
                .WithMessage("Data de Nascimento inválida (Maior que 130 anos).")
                .LessThan(paciente => DateTime.Now)
                .WithMessage("Data de Nascimento (Não pode ser data futura).");

            RuleFor(paciente => paciente.Sexo)
                .NotEmpty().WithMessage("O Sexo é obrigatório.");

            RuleFor(paciente => paciente.Telefone)
                .NotEmpty().WithMessage("O Telefone é obrigatório.")
                .Matches(Utils.RegexUtils.GetTelefoneValidationRegex())
                .WithMessage("Telefone inválido.");

            RuleFor(paciente => paciente.Email)
                .NotEmpty().WithMessage("O E-mail é obrigatório.")
                .Matches(Utils.RegexUtils.GetEmailValidationRegex())
                .WithMessage("E-mail inválido.");
        }
    }
}
