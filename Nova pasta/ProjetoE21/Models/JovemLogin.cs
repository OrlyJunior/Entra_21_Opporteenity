using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class JovemLogin
    {
        [Required(ErrorMessage = "Você deve inserir seu email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve informar sua senha!")]
        public string Senha { get; set; }
    }
}
