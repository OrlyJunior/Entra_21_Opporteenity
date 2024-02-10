using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Jovem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você deve inserir seu nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Você deve inserir seu email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você deve inserir seu número de telefone!")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Você deve inserir sua data de nascimento!")]
        public DateTime DataNascimento { get; set; }

        public Local Local { get; set; }

        [Required(ErrorMessage = "Você deve inserir o nome de seu responsável!")]
        public string Responsavel { get; set; }

        [Required(ErrorMessage = "Você deve inserir o telefone de seu responsável!")]
        public string FoneResponsavel { get; set; }

        [Required(ErrorMessage = "Você deve informar sua senha!")]
        public string Senha { get; set; }

        public Curriculo Curriculo { get; set; } = new Curriculo();
    }
}