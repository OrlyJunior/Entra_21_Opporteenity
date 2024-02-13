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
        DaoCurriculo DaoCur = new();

        public IActionResult Index(string searchString)
        {
            Listas.cadastrosJ = DaoC.consultar();

            ViewBag.CurrentFilter = searchString;

            ordena.Pesquisa(searchString);

            return View(Listas.cadastrosJ);
        }

        public IActionResult Ver(int id)
        {
            List<Jovem> jovens = DaoC.consultar();

            List<Curriculo> curriculos = DaoCur.consultar();

            Jovem jovem = jovens.FirstOrDefault(jv => jv.Id == id);

            jovem.Curriculo = curriculos.FirstOrDefault(cr => cr.JovemId == id);

            return View(jovem);
        }
    }
}
