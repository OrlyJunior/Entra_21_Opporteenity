using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;

namespace ProjetoE21.Dados
{
    public class Listas
    {
        public static List<Servico> servicos = new();

        public static List<Emprego> empregos = new();

        public static List<Jovem> cadastros = new();
    }
}
