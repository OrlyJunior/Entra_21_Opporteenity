using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using X.PagedList;
using ProjetoE21.Ordenacao;

namespace ProjetoE21.Controllers
{
    public class ServiçosController : Controller
    {
        OrdenarServicos ordenar = new();
        DaoServico DaoS = new();
        public IActionResult Index(string sorter, string currentFilter, string searchString, int? page)
        {
            Listas.servicos = DaoS.consultar();

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

            ordenar.Pesquisa(searchString);

            ViewBag.CurrentFilter = searchString;

            ordenar.Ordena(sorter);

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            return View(Listas.servicos.ToPagedList(pageNumber, pageSize));
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

            servico.EmpresaS = Usuario.LogadoE;

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            if (!ModelState.IsValid)
            {
                return View(servico);
            }

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

            servico.EmpresaS = Usuario.LogadoE;

            servico.Dia = $"{servico.Horario.Day}/{servico.Horario.Month}/{servico.Horario.Year}";
            servico.Hora = $"{servico.Horario.TimeOfDay}";

            if (!ModelState.IsValid)
            {
                return View(servico);
            }

            DaoS.editar(servico);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Servico servico = Listas.servicos.FirstOrDefault(s => s.Id == id);

            return View(servico);
        }
    }
}
