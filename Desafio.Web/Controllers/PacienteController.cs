using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using FluentValidation;

namespace Desafio.Web.Controllers
{
    public class PacienteController : GenericController<Paciente>
    {
        public PacienteController(IValidator<Paciente> validator, IBaseService<Paciente> service) : base(validator, service)
        {
        }
        protected override void CustomValidations(Paciente obj)
        {
            if (obj != null && obj.CPF != null)
            {
                if (((IPacienteService)service).ListByCpf(obj.CPF).ToList().Count > 0)
                    ModelState.AddModelError("CPF.", "CPF já cadastrado");
            }
        }
        protected override void LoadOptionalData(Paciente obj)
        {
        }
    }
}
