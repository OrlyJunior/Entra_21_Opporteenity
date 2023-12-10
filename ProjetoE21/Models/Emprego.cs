using Org.BouncyCastle.Asn1.Cms;

namespace ProjetoE21.Models
{
    public class Emprego
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Empresa Empresa { get; set; }
        public decimal Salario { get; set; }
        public Local Local { get; set; }
        public DateTime HoraDeInicio { get; set; }
        public DateTime HoraDeFim { get; set; }
        public int DiasTrabalhados { get; set; }
    }
}