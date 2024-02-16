using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Curriculo
    {
        [Required(ErrorMessage = "Você deve inserir informações de seu perfil profissional!")]
        public string PerfilProfissional { get; set; }

        [Required(ErrorMessage = "Você deve inserir a data que começou a escola!")]
        public DateTime InicioEscola { get; set; }

        [Required(ErrorMessage = "Você deve inserir pelo menos um idioma!")]
        public string Idioma1 { get; set; }
        public string? NivelIdioma1 { get; set; }

        [Required(ErrorMessage = "Você deve inserir a escola em que sua cidade se localiza!")]
        public string EscolaCidade { get; set; }
        public string? Idioma2 { get; set; }

        [Required(ErrorMessage = "Você deve inserir seu grau de ensino!")]
        public string Ensino { get; set; }
        public string? NivelIdioma2 { get; set; }
        public int ValorIdioma1 { get; set; }
        public int? ValorIdioma2 { get; set; }
        public int? ValorIdioma3 { get; set; }

        [Required(ErrorMessage = "Você deve inserir o status de sua educação!")]
        public string Status { get; set; }
        public string? Idioma3 { get; set; }
        public string? NivelIdioma3 { get; set; }
        public string? Cursos { get; set; }
        public string? Outros1 { get; set; }
        public string? Outros2 { get; set; }
        public string? Outros3 { get; set; }
        public string? Outros4 { get; set; }
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Local? Local { get; set; }
        public string? Telefone { get; set; } 
        public string? Email { get; set; } 
        public string Escola { get; set; }
        public int JovemId { get; set; } 
    }
}