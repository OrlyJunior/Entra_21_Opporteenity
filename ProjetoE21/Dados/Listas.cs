using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;

namespace ProjetoE21.Dados
{
    public class Listas
    {
        public static List<Servico> servicos { get; set; }

        public static List<Emprego> empregos { get; set; }

        public static List<Jovem> cadastrosJ { get; set; }

        public static List<Empresa> cadastrosE { get; set; }

        public static List<Emprego> favoritos { get; set; }
    }
}
