using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este deve possuir entre 2 a 100 caracteres")]
        [MinLength(2, ErrorMessage = "Este deve possuir entre 2 a 100 caracteres")]
        public string Name { get; set; }
        [Url(ErrorMessage = "Este Campo deve receber uma Url")]
        public string Image { get; set; }
    }
}
