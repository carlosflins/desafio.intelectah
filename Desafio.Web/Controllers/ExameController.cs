using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using Desafio.Web.Utils;
using FluentValidation;

namespace Desafio.Web.Controllers
{
    public class ExameController : GenericController<Exame>
    {
        protected static IBaseService<TipoExame> _tipoExameService;

        public ExameController(IValidator<Exame> validator, IBaseService<Exame> service, IBaseService<TipoExame> tipoExameService) : base(validator, service)
        {
            _tipoExameService = tipoExameService;
        }
        protected override void CustomValidations(Exame obj)
        {
        }
        protected override void LoadOptionalData(Exame obj)
        {
            ViewBag.TiposExame = BaseEntityExtensions.ToSelectListItems<TipoExame>(_tipoExameService.ListAll().ToList());
        }
    }
}
