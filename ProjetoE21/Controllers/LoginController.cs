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
            DaoEmp.adicionar(empresa);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CadastroPessoal()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CadastroLocalizacao()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CadastroResponsavel()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CadastroSenha()
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
