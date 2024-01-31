using Microsoft.AspNetCore.Mvc;
using ProjetoE21.Dados;
using ProjetoE21.Dao;
using ProjetoE21.Models;

namespace ProjetoE21.Controllers
{
    public class LoginController : Controller
    {
        DaoCadastro DaoC = new();
        DaoEmpresa DaoEmp = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Confirmar()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Empresa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Empresa(Empresa empresa)
        {
            DaoEmp.adicionar(empresa);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult CadastroPessoal()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CadastroLocalizacao(Jovem jovem)
        {
            UserTemp.LogadoTemp.Nome = jovem.Nome;
            UserTemp.LogadoTemp.DataNascimento = jovem.DataNascimento;
            UserTemp.LogadoTemp.Telefone = jovem.Telefone;

            return View();
        }

        [HttpGet]
        public IActionResult CadastroResponsavel(Jovem jovem)
        {
            UserTemp.LogadoTemp.Local = new();

            UserTemp.LogadoTemp.Local = jovem.Local;

            return View();
        }
        [HttpGet]
        public IActionResult CadastroSenha(Jovem jovem)
        {
            UserTemp.LogadoTemp.Responsavel = jovem.Responsavel;
            UserTemp.LogadoTemp.FoneResponsavel = jovem.FoneResponsavel;

            return View();
        }

        public IActionResult Cadastro(Jovem jovem)
        {
            UserTemp.LogadoTemp.Senha = jovem.Senha;

            Usuario.LogadoJ = UserTemp.LogadoTemp;

            DaoC.adicionar(Usuario.LogadoJ);

            DaoC.criaTbJovem(Usuario.LogadoJ);

            return RedirectToAction("Index");
        }
    }
}
