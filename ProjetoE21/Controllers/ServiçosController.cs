using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;

namespace ProjetoE21.Controllers
{
    
    public class ServiçosController : Controller
    {
        DaoServico DaoS = new();
        public IActionResult Index()
        {
            Listas.servicos = DaoS.consultar();

            return View(Listas.servicos);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Servico servico)
        {
            servico.EmpresaS = new();

            servico.EmpresaS.Nome = "Empresa inventada";

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            DaoS.adicionar(servico);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Servico servico = Listas.servicos.FirstOrDefault(sc => sc.Id == id);

            return View(servico);
        }

        [HttpPost]
        public IActionResult Delete(Servico servico)
        {
            Listas.servicos.RemoveAt(servico.Id - 1);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Servico servico = Listas.servicos.FirstOrDefault(sc => sc.Id == id);

            return View(servico);
        }

        [HttpPost]
        public IActionResult Edit(Servico servico)
        {
            Empresa empresa = new();
            empresa.Nome = "Empresa inventada";
            empresa.Id = 1;

            servico.EmpresaS = new();

            servico.EmpresaS.Id = empresa.Id;
            servico.EmpresaS.Nome = empresa.Nome;

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            servico.Id = Listas.servicos.Count + 1;

            return RedirectToAction("Index");
        }
    }
}
