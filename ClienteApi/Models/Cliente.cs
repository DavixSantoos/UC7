using Microsoft.OpenApi.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ClienteApi.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required(ErrorMessage ="O nome é um dado obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome ter entre 3 e 200 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage ="Email em formato inválido")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracter")]
        public string Email { get; set; } = string.Empty;

        
            public string Telefone { get; set; } = string.Empty;

           [DataType(DataType.DateTime)]
            public DateTime DataCadastro { get; set; } = DateTime.Now;
            
            
    }
}
