using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using ProjetoE21.Models;

namespace ProjetoE21.Controllers
{
    public class EmpregosController : Controller
    {
        DaoEmprego DaoS = new();
        public IActionResult Index(string sorter, string searchString)
        {
            Listas.empregos = DaoS.consultar();

            ViewBag.descSort = "nome_desc";
            ViewBag.Sort = "nome";

            if (!String.IsNullOrEmpty(searchString))
            {
                Listas.empregos = Listas.empregos.Where(s => s.Descricao.Contains(searchString)).ToList();
            }

            switch (sorter)
            {
                case "nome_desc":
                    Listas.empregos = Listas.empregos.OrderByDescending(n => n.Descricao).ToList();
                    break;
                case "nome":
                    Listas.empregos = Listas.empregos.OrderBy(n => n.Descricao).ToList();
                    break;
                default:
                    Listas.empregos = Listas.empregos.OrderBy(n => n.Id).ToList();
                    break;
            }

            return View(Listas.empregos);
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Adicionar(Emprego emprego)
        {
            emprego.Empresa = new();

            emprego.Empresa.Id = 1;
            emprego.Empresa.Nome = "Empresa inventada";

            DaoS.adicionar(emprego);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Emprego emprego = Listas.empregos.FirstOrDefault(sc => sc.Id == id);

            return View(emprego);
        }

        [HttpPost]
        public IActionResult Delete(Emprego emprego)
        {
            DaoS.deletar(emprego);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Emprego emprego = Listas.empregos.FirstOrDefault(sc => sc.Id == id);

            return View(emprego);
        }

        [HttpPost]
        public IActionResult Edit(Emprego emprego)
        {
            emprego.Empresa = new();

            emprego.Empresa.Id = 1;
            emprego.Empresa.Nome = "Empresa inventada";

            DaoS.editar(emprego);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Emprego emprego = Listas.empregos.FirstOrDefault(s => s.Id == id);

            return View(emprego);
        }
    }
}
