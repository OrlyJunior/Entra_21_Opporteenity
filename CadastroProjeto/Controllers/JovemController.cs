using Microsoft.AspNetCore.Mvc;

namespace CadastroProjeto.Controllers
{
    public class JovemController : Controller
    {
        public IActionResult Index()
        {
            return View(Dados.Db.jovens);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Jovem jovem)
        {
            jovem.Id = Dados.Db.jovens.Count + 1;
            Dados.Db.jovens.Add(jovem);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            Models.Jovem jovem = Dados.Db.jovens.FirstOrDefault(jv => jv.Id == id);
            return View(jovem);
        }
                [HttpPost]
        public IActionResult Edit(Models.Jovem jovem)
        {
            Models.Jovem jov = Dados.Db.jovens.FirstOrDefault(jv => jv.Id == jovem.Id);
            jov.Nome = jovem.Nome;
            jov.Email = jovem.Email;
            jov.Telefone = jovem.Telefone;
            jov.DataNascimento = jovem.DataNascimento;
            jov.NomeLocal = jovem.NomeLocal;
            jov.Rua = jovem.Rua;
            jov.Numero = jovem.Numero;
            jov.Bairro = jovem.Bairro;
            jov.Cidade = jovem.Cidade;
            jov.CEP = jovem.CEP;
            jov.UF = jovem.UF;
            jov.Pais = jovem.Pais;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            Models.Jovem jovem = Dados.Db.jovens.FirstOrDefault(jv => jv.Id == id);
            return View(jovem);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            Models.Jovem jovem = Dados.Db.jovens.FirstOrDefault(jv => jv.Id == id);
            return View(jovem);
        }

        [HttpPost]
        public IActionResult Delete(Models.Jovem jovem)
        {
            Models.Jovem jovemParaRemover = Dados.Db.jovens.FirstOrDefault(jv => jv.Id == jovem.Id);
            Dados.Db.jovens.Remove(jovemParaRemover);          
            return RedirectToAction("Index");
        }

    }
}
