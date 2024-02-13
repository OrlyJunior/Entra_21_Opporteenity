using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você deve informar o nome de sua empresa!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Você deve informar o CNPJ de sua empresa!")]
        public string Cnpj { get; set; }
        public Local Local { get; set; }

        [Required(ErrorMessage = "Você deve informar o número para contato de sua empresa!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Você deve informar o email de sua empresa!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve informar a senha do perfil de sua empresa!")]
        public string Senha { get; set; }
    }
}
