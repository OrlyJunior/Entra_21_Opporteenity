using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dao;
using ProjetoE21.Ordenacao;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace ProjetoE21.Controllers
{
    public class PesquisarController : Controller
    {
        OrdenaJovens ordena = new();
        DaoCadastro DaoC = new();
        DaoCurriculo DaoCur = new();

        public IActionResult Index(string searchString, int? page)
        {
            Listas.cadastrosJ = DaoC.consultar();

            if (searchString != null)
            {
                page = 1;
            }

            ViewBag.CurrentFilter = searchString;

            ordena.Pesquisa(searchString);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(Listas.cadastrosJ.ToPagedList(pageNumber, pageSize));
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
