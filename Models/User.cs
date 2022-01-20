using System.ComponentModel.DataAnnotations;

namespace primeira_api_data_driven_asp
{
    public class User
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]

        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo � obrigat�rio.")]
        [MaxLength(20, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 20 caracteres.")]

        public string Password { get; set; }

        public string Role { get; set; }
    }
}