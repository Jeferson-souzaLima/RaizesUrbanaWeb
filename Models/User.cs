using System.ComponentModel.DataAnnotations;

namespace RaizesUrbanaWeb.Models
{
    public enum UserType { Regular, Administrator }
    public class User
    {
        public int Id { get; set; }  // Primary Key

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Por favor, insira um e-mail válido.")]
        [StringLength(100, ErrorMessage = "O e-mail não pode ter mais de 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "A senha deve ter pelo menos 6 caracteres.")]
        public string Password { get; set; }

        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;  

        public UserType Type { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
