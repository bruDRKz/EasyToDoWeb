using EasyToDoWeb.Repositories.Interfaces;
using EasyToDoWeb.Context;
using EasyToDoWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace EasyToDoWeb.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly AppDbContext _context;

        public TarefasRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tasks> Tarefas => _context.Tarefas.Include(t => t.Categoria).ToList();

        public void Adicionar(Tasks Tarefa)
        {
            _context.Tarefas.Add(Tarefa);
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Tarefa >>> {Tarefa.Name} <<< foi salva com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Tasks BuscarId(int id) => _context.Tarefas.FirstOrDefault(t => t.taskID == id);

        public IEnumerable<Tasks> BuscarName(string name)
        {
           return _context.Tarefas.Where(t => t.Name.Contains(name));
        }

        public void Delete(int id)
        {
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.taskID == id);
            if (tarefa != null)
            {
                _context.Tarefas.Remove(tarefa);
                _context.SaveChanges();
            }
        }

        public void Edit(Tasks Tarefa)
        {
            _context.Tarefas.Update(Tarefa);
            _context.SaveChanges();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Tarefa >>>> {Tarefa.Name} <<<< foi alterada com sucesso!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
