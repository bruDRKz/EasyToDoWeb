using System.Linq;
using EasyToDoWeb.Models;
namespace EasyToDoWeb.Repositories.Interfaces
{
    public interface ITarefasRepository
    {
        IEnumerable<Tasks> Tarefas { get; }
        Tasks BuscarId(int id);
        IEnumerable<Tasks> BuscarName(string name);
        void Adicionar(Tasks Tarefa);
        void Edit(Tasks Tarefa);
        void Delete(int id);
    }
}
