using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using System.Diagnostics;
using ProjetoE21.Dao;
using ProjetoE21.Dados;

namespace ProjetoE21.Controllers
{
    public class HomeController : Controller
    {
        
        DaoServico DaoS = new();
        DaoCadastro DaoC = new();
        DaoEmpresa DaoEmp = new();
        DaoEmprego DaoE = new();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginEmpresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginEmpresa(Empresa empresa)
        {
            if (empresa == null)
            {
                return RedirectToAction("Error");
            }

            Listas.cadastrosE = DaoEmp.consultar();

            foreach (var i in Listas.cadastrosE)
            {
                if (i.Email == empresa.Email && i.Senha == empresa.Senha)
                {
                    Usuario.LogadoJ = null;
                    Usuario.LogadoE = i;
                    Listas.empregos = DaoE.consultar();
                    Listas.servicos = DaoS.consultar();

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        public IActionResult LoginJovem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginJovem(Jovem jovem)
        {
            if (jovem == null)
            {
                return RedirectToAction("Error");
            }

            Listas.cadastrosJ = DaoC.consultar();

            foreach (var i in Listas.cadastrosJ)
            {
                if (i.Email == jovem.Email && i.Senha == jovem.Senha)
                {
                    Usuario.LogadoE = null;
                    Usuario.LogadoJ = i;
                    Listas.empregos = DaoE.consultar();
                    Listas.servicos = DaoS.consultar();

                    return RedirectToAction("Index");


                }
            }

            return RedirectToAction("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}