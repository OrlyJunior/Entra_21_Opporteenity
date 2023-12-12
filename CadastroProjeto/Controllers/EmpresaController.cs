using Microsoft.AspNetCore.Mvc;

namespace CadastroProjeto.Controllers
{
    public class EmpresaController : Controller
    {       
        public IActionResult Index()
        {
            return View(Dados.Db.empresas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Empresa empresa)
        {
            empresa.Id = Dados.Db.empresas.Count + 1;
            Dados.Db.empresas.Add(empresa);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Models.Empresa empresa = Dados.Db.empresas.FirstOrDefault(em => em.Id == id);
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Edit(Models.Empresa empresa)
        {
            Models.Empresa emp = Dados.Db.empresas.FirstOrDefault(em => em.Id == empresa.Id);
            emp.Nome = empresa.Nome;
            emp.Email = empresa.Email;
            emp.Telefone = empresa.Telefone;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Models.Empresa empresa = Dados.Db.empresas.FirstOrDefault(em => em.Id == id);
            return View(empresa);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Models.Empresa empresa = Dados.Db.empresas.FirstOrDefault(em => em.Id == id);
            return View(empresa);
        }

        [HttpPost]
        public IActionResult Delete(Models.Empresa empresa)
        {
            Models.Empresa EmpresaParaRemover = Dados.Db.empresas.FirstOrDefault(em => em.Id == empresa.Id);
            Dados.Db.empresas.Remove(EmpresaParaRemover);
            return RedirectToAction("Index");
        }

    }
}
