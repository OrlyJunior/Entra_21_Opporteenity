using ProjetoE21.Models;

namespace ProjetoE21.Dados
{
    public class Usuario
    {
        public static Jovem LogadoJ = new();

        public static Empresa LogadoE = new();

        public static Curriculo Curriculo { get; set; }
    }
}
