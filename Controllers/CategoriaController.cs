using AspNetCoreGeneratedDocument;
using EasyToDoWeb.Models;
using EasyToDoWeb.Repositories;
using EasyToDoWeb.Repositories.Interfaces;
using EasyToDoWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EasyToDoWeb.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ITarefasRepository _tarefasRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult Index()
        {
            var CategoriaViewModel = _categoriaRepository.GetAll().Select(c => new CategoriaViewModel
            {
                Id = c.CategoriaID,
                Name = c.NomeCategoria,
                Cor = c.Cor,
                Situacao = c.Situacao,

            }).ToList();

            return View(CategoriaViewModel);
        }

        [HttpPost]
        public IActionResult CadastrarCategoria(CategoriaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Dados inválidos.");
            }

            var novaCategoria = new Categoria
            {
                NomeCategoria = model.Name,
                Cor = model.Cor,
                Situacao = model.Situacao
            };

            _categoriaRepository.Add(novaCategoria);

            // Retorna sucesso para o AJAX
            return Ok();
        }

    }
}
