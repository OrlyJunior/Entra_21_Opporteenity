using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using ProjetoE21.Models;
using ProjetoE21.Ordenacao;

namespace ProjetoE21.Controllers
{
    public class EmpregosController : Controller
    {
        OrdenarEmpregos ordena = new();
        DaoEmprego DaoS = new();
        DaoCurriculo DaoCur = new();

        public IActionResult Index(string sorter, string currentFilter, string searchString, int? page)
        {
            Listas.empregos = DaoS.consultar();

            ViewBag.CurrentSort = sorter;
            ViewBag.descSort = "nome_desc";
            ViewBag.Sort = "nome";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            ordena.Pesquisa(searchString);

            ViewBag.CurrentFilter = searchString;

            ordena.Ordena(sorter);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(Listas.empregos.ToPagedList(pageNumber, pageSize));
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

            emprego.Empresa.Id = Usuario.LogadoE.Id;
            emprego.Empresa.Nome = Usuario.LogadoE.Nome;

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

        public IActionResult Candidatos(int id)
        {
            Emprego emprego = Listas.empregos.FirstOrDefault(s => s.Id == id);

            List<Curriculo> candidatos = DaoCur.consultarCandidatos(id);

            return View(candidatos);
        }
    }
}
