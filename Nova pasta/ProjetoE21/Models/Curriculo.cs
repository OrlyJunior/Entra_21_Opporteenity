namespace ProjetoE21.Models
{
    public class Curriculo
    {
        public string PerfilProfissional { get; set; }
        public string Cidade { get; set; }
        public DateTime InicioEscola { get; set; }
        public string Idioma1 { get; set; }
        public string NivelIdioma1 { get; set; }
        public string EscolaCidade { get; set; }
        public string? Idioma2 { get; set; }
        public string Ensino { get; set; }
        public string? NivelIdioma2 { get; set; }
        public int ValorIdioma1 { get; set; }
        public int ValorIdioma2 { get; set; }
        public int ValorIdioma3 { get; set; }
        public string Status { get; set; }
        public string? Idioma3 { get; set; }
        public string? NivelIdioma3 { get; set; }
        public string? Cursos { get; set; }
        public string? Outros1 { get; set; }
        public string? Outros2 { get; set; }
        public string? Outros3 { get; set; }
        public string? Outros4 { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public Local Local { get; set; }
        public string Telefone { get; set; } 
        public string Email { get; set; } 
        public string RedeSocial { get; set; } 
        public string Objetivo { get; set; } 
        public string Escola { get; set; }
        public string Experiencia { get; set; }
        public int JovemId { get; set; } 
    }
}