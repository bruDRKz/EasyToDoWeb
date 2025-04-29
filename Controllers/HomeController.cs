using EasyToDoWeb.Repositories;
using EasyToDoWeb.Repositories.Interfaces;
using EasyToDoWeb.Models;
using EasyToDoWeb.ViewModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace EasyToDoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITarefasRepository _tarefasRepository;

        public HomeController(ITarefasRepository tarefasRepository) //DI do meu repo
        {
            _tarefasRepository = tarefasRepository;
        }

        public IActionResult Index()
        {
            var TarefaViewModel = _tarefasRepository.Tarefas.Select(t => new TarefaViewModel
            {
                Name = t.Name,
                Situacao = t.Situacao,
                Prioridade = t.Prioridade,
                CategoriaID = t.CategoriaID,
                CategoriaNome = t.Categoria != null ? t.Categoria.NomeCategoria : "Sem Categoria", 
                Detail = t.DescricaoDetalhada,
                DataPrevista = t.DataPrevista.ToString("dd/MM/yyyy"),
            }).ToList();

            Console.WriteLine($"Número de tarefas encontradas: {TarefaViewModel.Count}");

            if (!TarefaViewModel.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("O repository de tarefas retornou nulo");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return View(TarefaViewModel);
        }
    }
}
