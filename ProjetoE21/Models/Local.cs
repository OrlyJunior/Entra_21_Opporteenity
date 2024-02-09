using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Local
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você deve inserir a cidade de sua residência!")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Você deve inserir a sua de sua residência!")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "Você deve inserir o estado de sua residência!")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Você deve inserir o bairro de sua residência!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Você deve inserir o número do local de sua residência!")]
        public int Numero { get; set; }
    }
}
