using ProjetoE21.Dados;
using System.ComponentModel.DataAnnotations;

namespace ProjetoE21.Models
{
    public class Servico
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Você deve informar a descrição!")]
        public string Descricao { get; set; }

        public Empresa EmpresaS { get; set; } = Usuario.LogadoE;

        public Local Local { get; set; }

        [Required(ErrorMessage = "Você deve informar o valor a ser pago pelo serviço!")]
        public decimal Pagamento { get; set; }

        [Required(ErrorMessage = "Você deve informar o horário do serviço!")]
        public DateTime Horario { get; set; }
        public string Dia { get; set; } = "";
        public string Hora { get; set; } = "";
    }
}
