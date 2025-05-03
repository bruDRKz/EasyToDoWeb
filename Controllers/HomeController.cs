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
                Id = t.taskID,
                Name = t.Name,
                Situacao = t.Situacao,
                Prioridade = t.Prioridade,
                CategoriaID = t.CategoriaID,
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefaViewModel)
        {
            if (ModelState.IsValid)
            {
                var tarefa = new Tasks
                {
                    Name = tarefaViewModel.Name,
                    DescricaoDetalhada = tarefaViewModel.Detail,
                    Prioridade = tarefaViewModel.Prioridade,
                    CategoriaID = tarefaViewModel.CategoriaID,
                    Situacao = "Pendente",
                    DataPrevista = DateTime.Parse(tarefaViewModel.DataPrevista),
                    DataInclusao = DateTime.Now
                };

                _tarefasRepository.Adicionar(tarefa);
                return RedirectToAction("Index");
            }
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View(tarefaViewModel);
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            var tarefa = _tarefasRepository.Tarefas.FirstOrDefault(x => x.taskID == id);

            if (tarefa == null)
            {
                return NotFound();
            }


            var tarefaViewModel = new TarefaViewModel
            {
                Id = tarefa.taskID,
                Name = tarefa.Name,
                Detail = tarefa.DescricaoDetalhada,
                Prioridade = tarefa.Prioridade,
                DataPrevista = tarefa.DataPrevista.ToString("yyyy-MM-dd"),
                Situacao = tarefa.Situacao,
                CategoriaID = tarefa.CategoriaID
            };

            return View("Delete", tarefaViewModel);
            
                
        }
        [HttpPost]
        public IActionResult Delete(TarefaViewModel tarefa)
        {
            if (tarefa == null)
            {
                return NotFound();
            }

            _tarefasRepository.Delete(tarefa.Id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var tarefa = _tarefasRepository.Tarefas.FirstOrDefault(x => x.taskID == id);

            if (tarefa == null)
            {
                return NotFound();
            }


            var tarefaViewModel = new TarefaViewModel
            {
                Id = tarefa.taskID,
                Name = tarefa.Name,
                Detail = tarefa.DescricaoDetalhada,
                Prioridade = tarefa.Prioridade,
                DataPrevista = tarefa.DataPrevista.ToString("yyyy-MM-dd"),
                Situacao = tarefa.Situacao,
                CategoriaID = tarefa.CategoriaID
            };

            return View("Edit", tarefaViewModel);
        }

        [HttpPost]
        public IActionResult Edit(TarefaViewModel tarefaViewModel)
        {
            if (ModelState.IsValid)
            {
                var tarefa = new Tasks
                {
                    taskID = tarefaViewModel.Id,
                    Name = tarefaViewModel.Name,
                    DescricaoDetalhada = tarefaViewModel.Detail,
                    Prioridade = tarefaViewModel.Prioridade,
                    CategoriaID = tarefaViewModel.CategoriaID,
                    Situacao = tarefaViewModel.Situacao,
                    DataPrevista = DateTime.Parse(tarefaViewModel.DataPrevista),
                };

                _tarefasRepository.Edit(tarefa);
                return RedirectToAction("Index");
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            
            return View(tarefaViewModel);
        }
        
    }
}
