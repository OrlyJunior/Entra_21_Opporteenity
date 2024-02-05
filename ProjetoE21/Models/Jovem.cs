namespace ProjetoE21.Models
{
    public class Jovem
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public Local Local { get; set; }
        public string Responsavel { get; set; }
        public string FoneResponsavel { get; set; }
        public string Senha { get; set; }
        public Curriculo Curriculo { get; set; } = null;
    }
}

