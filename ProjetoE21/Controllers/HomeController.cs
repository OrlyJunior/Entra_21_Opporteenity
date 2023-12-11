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



        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Listas.empregos = DaoE.consultar();
            Listas.servicos = DaoS.consultar();

            return View();
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