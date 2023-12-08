namespace ProjetoE21.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Empresa EmpresaS { get; set; }
        public decimal Pagamento { get; set; }
        public DateTime Horario { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
    }
}
