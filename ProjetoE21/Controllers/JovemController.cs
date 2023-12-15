using Microsoft.AspNetCore.Mvc;

namespace ProjetoE21.Controllers
{
    public class JovemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
