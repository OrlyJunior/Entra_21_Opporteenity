using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dao;
using ProjetoE21.Ordenacao;
using ProjetoE21.Models;
using ProjetoE21.Dados;

namespace ProjetoE21.Controllers
{
    public class PesquisarController : Controller
    {
        OrdenaJovens ordena = new();
        DaoCadastro DaoC = new();

        public IActionResult Index(string searchString)
        {
            Listas.cadastrosJ = DaoC.consultar();

            ViewBag.CurrentFilter = searchString;

            ordena.Pesquisa(searchString);

            return View(Listas.cadastrosJ);
        }
    }
}
