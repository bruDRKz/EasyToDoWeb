using System.Linq;
using EasyToDoWeb.Models;
namespace EasyToDoWeb.Repositories.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> GetAll();
        Categoria GetById(int id);
        void Add(Categoria categoria);
        void Update(Categoria categoria);
        void Delete(int id);
       
    }
}
