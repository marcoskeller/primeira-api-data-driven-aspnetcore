using System.ComponentModel.DataAnnotations;

namespace primeira_api_data_driven_asp
{
    public class Product
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres.")]

        public string Title { get; set; }

        [MaxLength(1024, ErrorMessage = "Este campo deve conter no m�ximo 1024 caracteres.")]
        
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [Range(1, int.MaxValue, ErrorMessage = "O pre�o deve ser maior que zero.")]

        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inv�lida.")]

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}