using Org.BouncyCastle.Asn1.Cms;
using ProjetoE21.Dados;
using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Emprego
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Você deve informar a descrição!")]
        public string Descricao { get; set; }

        public Empresa Empresa { get; set; } = Usuario.LogadoE;

        [Required(ErrorMessage = "Você deve informar o salário!")]
        public decimal Salario { get; set; }

        public Local Local { get; set; }

        [Required(ErrorMessage = "Você deve informar o horário de início!")]
        public DateTime HoraDeInicio { get; set; }

        [Required(ErrorMessage = "Você deve informar o horário de término!")]
        public DateTime HoraDeFim { get; set; }

        [Required(ErrorMessage = "Você deve informar quantos dias serão trabalhados!")]
        public int DiasTrabalhados { get; set; }
    }
}