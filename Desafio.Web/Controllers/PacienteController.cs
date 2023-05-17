using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using Desafio.Service.Services;
using Desafio.Service.Validators;
using FluentValidation;

namespace Desafio.Web.Controllers
{
    public class PacienteController : GenericController<Paciente>
    {
        private static IPacienteService _service;
        public PacienteController(IValidator<Paciente> validator, IBaseService<Paciente> service) : base(validator, service)
        {
            _service = (IPacienteService)service;
        }
        protected override Paciente CustomValidations(Paciente obj, string action)
        {
            if (obj != null && obj.CPF != null)
            {
                Paciente paciente = _service.FindByCpf(obj.CPF);
                if (paciente != null)
                {
                    if ((action == "update") && obj.Id == paciente.Id)
                        obj = paciente;
                    else
                    {
                        ModelState.AddModelError("CPF", "CPF já cadastrado");
                    }
                }
            }
            return obj;
        }
        protected override Paciente LoadOptionalData(Paciente obj)
        {
            return obj;
        }
    }
}
