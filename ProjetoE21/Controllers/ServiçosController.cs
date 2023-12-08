using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;

namespace ProjetoE21.Controllers
{
    public class ServiçosController : Controller
    {
        static List<Servico> servicos = new();
        public IActionResult Index()
        {
            return View(servicos);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Servico servico)
        {
            Empresa empresa = new();
            empresa.Nome = "Empresa inventada";
            empresa.Id = 1;

            servico.EmpresaS = new();

            servico.EmpresaS.Id = empresa.Id;
            servico.EmpresaS.Nome = empresa.Nome;

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            servico.Id = servicos.Count + 1;

            servicos.Add(servico);

            return RedirectToAction("Index");
        }
    }
}
