using Desafio.Domain.Entities;
using Desafio.Domain.Interfaces.Service;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Web.Controllers
{
    /// <summary>
	/// Classe <c>GenericController</c> facilita todas as operações CRUD 
	/// para os Controllers.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public abstract class GenericController<TEntity> : Controller
        where TEntity : BaseEntity
    {
        protected IValidator<TEntity> validator;
        protected IBaseService<TEntity> service;

        /// <summary>
        /// Método <c>GenericController</c> construtor utilizado para a injeção de
        /// dependências.
        /// </summary>
        /// <param name="validator"></param>
        /// <param name="service"></param>
        public GenericController(IValidator<TEntity> validator, IBaseService<TEntity> service)
        {
            this.validator = validator;
            this.service = service;
        }

        /// <summary>
        /// Método <c>CustomValidations</c> para realizar validações personalizadas
        /// antes do (CREATE) e (UPDATE)
        /// </summary>
        abstract protected void CustomValidations(TEntity obj);

        /// <summary>
        /// Método <c>LoadOptionalData</c> para enviar dados pela ViewData ou ViewBag
        /// </summary>
        abstract protected void LoadOptionalData(TEntity obj);

        /// <summary>
        /// Método <c>Index</c> gerencia a requisição 'GET' (READ) do Controller.
        /// </summary>
        /// <returns>
        /// Uma lista com os objetos armazenados no banco da Entidade especificada.
        /// </returns>
        public IActionResult Index()
        {
            IEnumerable<TEntity> objEntityList = service.ListAll();
            return View(objEntityList);
        }

        /// <summary>
        /// Método <c>Create</c> gerencia a requisição 'GET' (CREATE), retornando a
        /// View.
        /// </summary>
        /// <returns>
        /// o View da página de Cadastro (CREATE).
        /// </returns>
        public IActionResult Create()
        {
            LoadOptionalData(null);

            return View();
        }

        /// <summary>
        /// Método <c>Create</c> gerencia a requisição 'POST' (CREATE), persiste
        /// o obj e redireciona para o Index View.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Redireciona para o Index View.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TEntity obj)
        {
            LoadOptionalData(obj);
            CustomValidations(obj);

            ValidationResult result = validator.Validate(obj);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(obj);
            }

            if (ModelState.IsValid)
            {
                service.Add<AbstractValidator<TEntity>>(obj);

                TempData["success"] = $"{typeof(TEntity).Name} cadastrado com sucesso.";
                return RedirectToAction("Index");
            }
            else
            {
                return View(obj);
            }
        }

        /// <summary>
        /// Método <c>Update</c> gerencia a requisição 'GET' (UPDATE), recebe
        /// o id da entidade, consulta no banco de dados e retorna a view de 
        /// edição.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Caso encontre, retorna a entidade na view de edição, caso contrário,
        /// retorna NotFound() 404.
        /// </returns>
        public IActionResult Update(int id)
        {
            var entityFromDb = CheckAndFindEntityById(id);
            LoadOptionalData(entityFromDb);

            if (entityFromDb == null)
            {
                return NotFound();
            }

            return View(entityFromDb);
        }

        /// <summary>
        /// Método <c>Details</c> gerencia a requisição 'GET' (DETAILS), recebe
        /// o id da entidade, consulta no banco de dados e retorna a view de 
        /// detalhes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Caso encontre, retorna a entidade na view de detalhes, caso contrário,
        /// retorna NotFound() 404.
        /// </returns>
        public IActionResult Details(int id)
        {
            var entityFromDb = CheckAndFindEntityById(id);
            LoadOptionalData(entityFromDb);

            if (entityFromDb == null)
            {
                return NotFound();
            }

            return View(entityFromDb);
        }

        /// <summary>
        /// Método <c>Update</c> gerencia a requisição 'POST' (UPDATE), recebe
        /// o obj entidade alterado, valida, persiste e redireciona para o Index
        /// View.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Se não houver erro de validação persiste as alterações e redireciona 
        /// para o Index, caso contrário, retorna a View do Edit para exibir os
        /// erros de validação.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(TEntity obj)
        {
            LoadOptionalData(obj);

            CustomValidations(obj);

            ValidationResult result = validator.Validate(obj);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View(obj);
            }

            service.Update<AbstractValidator<TEntity>>(obj);
            TempData["success"] = $"{typeof(TEntity).Name} atualizado com sucesso!";
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Método <c>Delete</c> gerencia a requisição 'GET' (DELETE), recebe
        /// o id da entidade, consulta no banco de dados e retorna a view de 
        /// confirmação da deleção.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Caso encontre, retorna a entidade na view de deleção, caso 
        /// contrário, retorna NotFound() 404.
        /// </returns>
        public IActionResult Delete(int id)
        {

            var entityFromDb = CheckAndFindEntityById(id);
            LoadOptionalData(entityFromDb);

            if (entityFromDb == null)
            {
                return NotFound();
            }

            return View(entityFromDb);

        }

        /// <summary>
        /// Método <c>DeleteById</c> gerencia a requisição 'POST' (DELETE), recebe
        /// o id da entidade, consulta no banco de dados, executa a deleção e 
        /// redireciona para o Index View.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// Se encontar a entidade pelo id, executa a deleção e redireciona para o
        /// Index View, caso contrário, retorna NotFound() 404.
        /// </returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteById(int id)
        {
            var entityFromDb = CheckAndFindEntityById(id);
            LoadOptionalData(entityFromDb);

            if (entityFromDb == null)
            {
                return NotFound();
            }

            service.Delete(id);
            TempData["success"] = $"{typeof(TEntity).Name} removido com sucesso!";
            return RedirectToAction("Index");
        }
        protected virtual TEntity CheckAndFindEntityById(int id)
        {
            if (id <= 0)
            {
                return null;
            }

            var objFromDb = service.GetById(id);
            return objFromDb;
        }
    }
}
