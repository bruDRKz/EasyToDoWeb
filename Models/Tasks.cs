using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyToDoWeb.Models
{
    public class Tasks
    {
        [Key]
        public int taskID { get; set; }
        //---------------------------------------------------------------------------------------
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O tamano minímo é de 5 caracteres")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Display(Name = "Nome da Tarefa")]
        public string Name { get; set; }
        //---------------------------------------------------------------------------------------
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "O tamanho do nome é de no minímo 20 e no máximo 1000 caracteres.")]
        [Display(Name = "Detalhamento da Tarefa")]
        public string DescricaoDetalhada { get; set; }
        //---------------------------------------------------------------------------------------
        [Required]
        public int Prioridade { get; set; }
        //---------------------------------------------------------------------------------------
        public DateTime DataPrevista { get; set; }

        //---------------------------------------------------------------------------------------
        public DateTime DataInclusao { get; set; }

        //---------------------------------------------------------------------------------------

        public String Situacao { get; set; }

        //---------------------------------------------------------------------------------------
        [Required]
        public int CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }
    }
}
