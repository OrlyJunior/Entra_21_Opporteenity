using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Local
    {
        public int Id { get; set; }

        public string Cidade { get; set; }

        public string Rua { get; set; }

        public string Estado { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }
    }
}
