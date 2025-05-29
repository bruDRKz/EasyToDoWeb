using AspNetCoreGeneratedDocument;
using EasyToDoWeb.Models;
using EasyToDoWeb.Repositories;
using EasyToDoWeb.Repositories.Interfaces;
using EasyToDoWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

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
        [HttpGet]
        public IActionResult EditarCategoria(int id)
        {
            var categoria = _categoriaRepository.GetById(id);

            if (categoria == null)
                Console.WriteLine("Achou porra nenhuma"); ;

            var viewModel = new CategoriaViewModel
            {
                Id = categoria.CategoriaID,
                Name = categoria.NomeCategoria,
                Cor = categoria.Cor,
                Situacao = categoria.Situacao,
            };
            return Json(viewModel);
        }


        [HttpPost]
        public IActionResult EditarCategoria( CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    CategoriaID = categoriaViewModel.Id,
                    NomeCategoria = categoriaViewModel.Name,
                    Cor = categoriaViewModel.Cor,
                    Situacao = categoriaViewModel.Situacao
                };
                _categoriaRepository.Update(categoria);

                return Ok();
            };

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(error.ErrorMessage);
                Console.ForegroundColor = ConsoleColor.White;
            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var categoria = _categoriaRepository;
            if (categoria == null)
            {
                return NotFound();
            }
            else
            {
                categoria.Delete(id);
                TempData["Mensagem"] = "Categoria excluída com sucesso!";

                return RedirectToAction("Index");
            }
        }

    }
}
