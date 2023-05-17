using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using FluentValidation;

namespace Desafio.Web.Controllers
{
    public class TipoExameController : GenericController<TipoExame>
    {
        public TipoExameController(IValidator<TipoExame> validator, IBaseService<TipoExame> service) : base(validator, service)
        {
        }

        protected override void CustomValidations(TipoExame obj)
        {
        }

        protected override void LoadOptionalData(TipoExame obj)
        {
        }
    }
}
