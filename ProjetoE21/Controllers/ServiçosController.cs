using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using Org.BouncyCastle.Asn1;

namespace ProjetoE21.Controllers
{
    public class ServiçosController : Controller
    {
        DaoServico DaoS = new();
        public IActionResult Index(string sorter, string searchString)
        {
            Listas.servicos = DaoS.consultar();

            ViewBag.descSort = "nome_desc";
            ViewBag.Sort = "nome";

            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.servicos = Listas.servicos.Where(s => s.Descricao.Contains(searchString)).ToList();
            }

            switch (sorter)
            {
                case "nome_desc":
                    Listas.servicos = Listas.servicos.OrderByDescending(n => n.Descricao).ToList();
                    break;
                case "nome":
                    Listas.servicos = Listas.servicos.OrderBy(n => n.Descricao).ToList();
                    break;
                default:
                    Listas.servicos = Listas.servicos.OrderBy(n => n.Id).ToList();
                    break;
            }

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

            servico.EmpresaS.Id = 1;
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
            DaoS.deletar(servico);

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
            servico.EmpresaS = new();

            servico.EmpresaS.Id = 1;
            servico.EmpresaS.Nome = "Empresa inventada";

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            DaoS.editar(servico);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Servico servico = Dados.Listas.servicos.FirstOrDefault(s => s.Id == id);

            return View(servico);
        }
    }
}
