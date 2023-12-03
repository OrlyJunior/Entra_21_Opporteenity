namespace Protótipo_Projeto.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Estoque { get; set; }
        public int IdCateg { get; set; }
        public string NomeCateg { get; set; }
    }
}
