using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;

namespace ProjetoE21.Controllers
{
    public class PerfilController : Controller
    {
        DaoCadastro DaoC = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar()
        {
            Jovem jovem = Listas.cadastros.FirstOrDefault(sc => sc.Id == Usuario.logado.Id);

            return View(jovem);
        }

        [HttpPost]
        public IActionResult Editar(Jovem jovem)
        {
            jovem.Id = Usuario.logado.Id;

            DaoC.editar(jovem);

            return RedirectToAction("Index");
        }
    }
}
