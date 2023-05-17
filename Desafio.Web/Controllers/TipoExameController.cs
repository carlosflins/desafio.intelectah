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

        protected override TipoExame CustomValidations(TipoExame obj, string action)
        {
            return obj;
        }

        protected override TipoExame LoadOptionalData(TipoExame obj)
        {
            return obj;
        }
    }
}
