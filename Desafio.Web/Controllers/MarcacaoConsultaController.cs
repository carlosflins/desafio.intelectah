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
        private static ITipoExameService _tipoExameService;
        private static IExameService _exameService;
        private static IPacienteService _pacienteService;
        private static IMarcacaoConsultaService _service;

        public MarcacaoConsultaController(IValidator<MarcacaoConsulta> validator, 
            IBaseService<MarcacaoConsulta> service, 
            IBaseService<TipoExame> tipoExameService,
            IBaseService<Exame> exameService,
            IBaseService<Paciente> pacienteService) : base(validator, service)
        {
            _service = (IMarcacaoConsultaService)service;
            _tipoExameService = (ITipoExameService)tipoExameService;
            _exameService = (IExameService)exameService;
            _pacienteService = (IPacienteService)pacienteService;
        }
        protected override MarcacaoConsulta CustomValidations(MarcacaoConsulta obj, string action)
        {
            if (obj != null && obj.DataHoraMarcacao != null)
            {
                IList<MarcacaoConsulta> marcacoes = _service.ListByDataHora(obj.DataHoraMarcacao);
                if (marcacoes.Count > 0)
                {
                    if ((action == "update") && obj.Id == marcacoes[0].Id)
                        obj = marcacoes[0];
                    else
                    {
                        ModelState.AddModelError("DataHoraMarcacao", "Já existe exame agendado para essa data.");
                    }
                }
            }
            return obj;
        }
        
        protected override MarcacaoConsulta LoadOptionalData(MarcacaoConsulta obj)
        {
            ViewBag.TiposExame = BaseEntityExtensions.ToSelectListItems<TipoExame>(_tipoExameService.ListAll());
            if (obj != null && obj.TipoExameId != null)
                ViewBag.Exames = BaseEntityExtensions.ToSelectListItems<Exame>(((IExameService)_exameService).ListByTipoExameId(obj.TipoExameId));
            return obj;
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