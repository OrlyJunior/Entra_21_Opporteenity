using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using ProjetoE21.Models;

namespace ProjetoE21.Controllers
{
    public class LoginController : Controller
    {
        DaoCadastro DaoC = new();
        DaoEmpresa DaoEmp = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Empresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Empresa(Empresa empresa)
        {
            if (!ModelState.IsValid)
            {
                return View(empresa);
            }

            DaoEmp.adicionar(empresa);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CadastroJovem()
        {
            return View();
        }

        public IActionResult Deslogar()
        {
            Usuario.LogadoJ = null;
            Usuario.LogadoE = null;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CadastroJovem(Jovem jovem)
        {
            if (!ModelState.IsValid)
            {
                return View(jovem);
            }

            DaoC.adicionar(jovem);

            return RedirectToAction("Index");

        }
    }
}