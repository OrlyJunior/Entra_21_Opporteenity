using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Models;
using ProjetoE21.Dados;
using ProjetoE21.Dao;

namespace ProjetoE21.Controllers
{
    public class PerfilController : Controller
    {
        DaoCadastro DaoC = new();
        DaoCurriculo DaoCur = new();
        DaoEmpresa DaoEmp = new();
        DaoFavoritos DaoF = new();
        DaoEmprego DaoE = new();

        public IActionResult Index()
        {
            if (Usuario.LogadoE == null)
            {
                return RedirectToAction("Jovem");
            }
            else
            {
                return RedirectToAction("Empresa");
            }
        }

        public IActionResult Desfavoritar(int id)
        {
            List<Emprego> empregos = DaoE.consultar();

            Emprego emprego = empregos.FirstOrDefault(em => em.Id == id);

            DaoF.deletar(emprego);

            return RedirectToAction("Jovem");
        }

        public IActionResult Jovem()
        {
            Listas.favoritos = DaoF.consultar();

            return View();
        }

        public IActionResult Empresa()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Editar()
        {
            Jovem jovem = Listas.cadastrosJ.FirstOrDefault(sc => sc.Id == Usuario.LogadoJ.Id);

            return View(jovem);
        }

        [HttpPost]
        public IActionResult Editar(Jovem jovem)
        {
            jovem.Id = Usuario.LogadoJ.Id;

            if (!ModelState.IsValid)
            {
                return View(jovem);
            }

            DaoC.editar(jovem);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditarEmpresa()
        {
            Empresa empresa = Listas.cadastrosE.FirstOrDefault(sc => sc.Id == Usuario.LogadoE.Id);

            return View(empresa);
        }

        [HttpPost]
        public IActionResult EditarEmpresa(Empresa empresa)
        {
            empresa.Id = Usuario.LogadoE.Id;

            if (!ModelState.IsValid)
            {
                return View(empresa);
            }

            DaoEmp.editar(empresa);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Curriculo()
        {
            if(Usuario.LogadoJ.Curriculo != null)
            {
                return View(Usuario.LogadoJ.Curriculo);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Curriculo(Curriculo curriculo)
        {
            if(Usuario.LogadoJ.Curriculo != null)
            {
                DaoCur.editar(curriculo);

                List<Curriculo> curriculosEditados = DaoCur.consultar();

                Usuario.LogadoJ.Curriculo = curriculosEditados.FirstOrDefault(cr => cr.JovemId == Usuario.LogadoJ.Id);
            }

            curriculo.Nome = Usuario.LogadoJ.Nome;

            curriculo.Local = new();

            curriculo.Local = Usuario.LogadoJ.Local;
            curriculo.Telefone = Usuario.LogadoJ.Telefone;
            curriculo.Email = Usuario.LogadoJ.Email;

            DaoCur.adicionar(curriculo);

            List<Curriculo> curriculos = DaoCur.consultar();

            Usuario.LogadoJ.Curriculo = curriculos.FirstOrDefault(cr => cr.JovemId == Usuario.LogadoJ.Id);

            return RedirectToAction("Index");
        }
    }
}
