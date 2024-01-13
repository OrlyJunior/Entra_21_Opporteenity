using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using System.Diagnostics;
using ProjetoE21.Dao;
using ProjetoE21.Dados;

namespace ProjetoE21.Controllers
{
    public class HomeController : Controller
    {
        DaoEmprego DaoE = new();
        DaoServico DaoS = new();
        DaoCadastro DaoC = new();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(Jovem jovem)
        {
            List<Jovem> jovens = DaoC.consultar();

            foreach(var i in jovens)
            {
                if (i.Email == jovem.Email && i.Senha == jovem.Senha)
                {
                    Listas.empregos = DaoE.consultar();
                    Listas.servicos = DaoS.consultar();

                    return View(jovem);
                }
            }

            return RedirectToAction("Privacy");
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