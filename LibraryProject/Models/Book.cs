using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este deve possuir entre 2 a 100 caracteres")]
        [MinLength(2, ErrorMessage = "Este deve possuir entre 2 a 100 caracteres")]
        [Display(Name = "Nome do Livro")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Este Campo deve receber uma Url")]
        [Url(ErrorMessage = "Este Campo deve receber uma Url")]
        [Display(Name = "Link direto")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Este deve possuir data de lançamento do Livro")]
        [Display(Name = "Data de Lançamento")]
        [DataType(DataType.Date)]
        public DateTime Release { get; set; }
        [Required(ErrorMessage = "Este campo deve possuir o valor do livro")]
        [Display(Name = "Preço do Livro")]
        public double Price { get; set; }
        public int AuthorId { get; set; }
        [Display(Name = "Nome do Autor")]
        public Author Author { get; set; }
    }
}
