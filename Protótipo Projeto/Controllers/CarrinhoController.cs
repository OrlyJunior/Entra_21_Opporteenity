using Microsoft.AspNetCore.Mvc;

namespace Protótipo_Projeto.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Carrinho()
        {
            return View();
        }

        public IActionResult Adicionar()
        {
            return View();
        }
    }
}
