using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using Desafio.Service.Services;
using Desafio.Web.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Web.Controllers
{
    public class MarcacaoConsultaController : GenericController<MarcacaoConsulta>
    {
        private static IBaseService<TipoExame> _tipoExameService;
        private static IBaseService<Exame> _exameService;
        private static IBaseService<Paciente> _pacienteService;

        public MarcacaoConsultaController(IValidator<MarcacaoConsulta> validator, 
            IBaseService<MarcacaoConsulta> service, 
            IBaseService<TipoExame> tipoExameService,
            IBaseService<Exame> exameService,
            IBaseService<Paciente> pacienteService) : base(validator, service)
        {
            _tipoExameService = tipoExameService;
            _exameService = exameService;
            _pacienteService = pacienteService;
        }
        protected override void CustomValidations(MarcacaoConsulta obj)
        {
        }
        protected override void LoadOptionalData(MarcacaoConsulta obj)
        {
            ViewBag.TiposExame = BaseEntityExtensions.ToSelectListItems<TipoExame>(_tipoExameService.ListAll());
            if (obj != null && obj.TipoExameId != null)
                ViewBag.Exames = BaseEntityExtensions.ToSelectListItems<Exame>(((IExameService)_exameService).ListByTipoExameId(obj.TipoExameId));
        }
        public async Task<ActionResult> getExamesByTipoExameId(int tipoExameId)
        {
            IList<Exame> retorno = ((ExameService)_exameService).ListByTipoExameId(tipoExameId);
            return Json(retorno);
        }

        public ActionResult getPacientesByNomeAndCpf(string nome, string cpf, string action)
        {
            IEnumerable<Paciente> retorno = (((PacienteService)_pacienteService).ListByNomeAndCpf(nome, cpf));
            ViewBag.Pacientes = retorno;

            return Json(retorno);
        }
    }
}