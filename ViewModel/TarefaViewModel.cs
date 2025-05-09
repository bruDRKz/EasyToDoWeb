using EasyToDoWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace EasyToDoWeb.ViewModel
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Situacao { get; set; }
        public string DataPrevista { get; set; }
        public string Detail { get; set; }
        public int Prioridade { get; set; }
        public int CategoriaID { get; set; }
        public string? NomeCategoria { get; set; }
        public string? CorCategoria { get; set; }
        public IEnumerable<SelectListItem>? Categorias { get; set; }
    }

}
