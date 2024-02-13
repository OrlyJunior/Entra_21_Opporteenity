using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class EmpresaLogin
    {
        [Required(ErrorMessage = "Você deve informar o email de sua empresa!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve informar a senha do perfil de sua empresa!")]
        public string Senha { get; set; }
    }
}
