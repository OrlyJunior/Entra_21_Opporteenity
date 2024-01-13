using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dao;
using ProjetoE21.Models;

namespace ProjetoE21.Controllers
{
    public class LoginController : Controller
    {
        DaoCadastro DaoC = new();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Jovem jovem)
        {
            DaoC.adicionar(jovem);

            return RedirectToAction("Index");
        }
    }
}
