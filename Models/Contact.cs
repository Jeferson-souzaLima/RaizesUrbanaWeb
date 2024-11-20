using System.ComponentModel.DataAnnotations;

namespace RaizesUrbanaWeb.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um e-mail válido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode exceder 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A mensagem é obrigatória.")]
        [StringLength(500, ErrorMessage = "A mensagem não pode exceder 500 caracteres.")]
        public string Message { get; set; } = string.Empty;
    }
}
