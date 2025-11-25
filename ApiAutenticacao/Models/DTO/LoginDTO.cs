using System.ComponentModel.DataAnnotations;

namespace apiAutenticacao.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage ="O email é obrigatório")]
        [EmailAddress(ErrorMessage ="O email é invalido")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="a Senha é obrigatória")]
        public string Senha { get; set; } = string.Empty;
    }
}
