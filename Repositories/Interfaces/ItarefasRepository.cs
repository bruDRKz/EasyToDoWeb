using EasyToDoWeb.Models;
namespace EasyToDoWeb.Repositories.Interfaces
{
    public interface ItarefasRepository
    {
        List<Tasks> TodasTarefas();
        Tasks BuscarId(int id);
        void BuscarName(string name);
        void Adicionar(Tasks Tarefa);
        void Editar(Tasks Tarefa);
        void Delete(int id);
    }
}
