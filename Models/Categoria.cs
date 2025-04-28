using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToDoWeb.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }
        //---------------------------------------------------------------------------------------

        public string Cor { get; set; }

        //---------------------------------------------------------------------------------------

        public string NomeCategoria { get; set; }

        //---------------------------------------------------------------------------------------

        public int Situacao { get; set; }

        //---------------------------------------------------------------------------------------

        public List<Tasks> Tarefas { get; set; }
    }
}
