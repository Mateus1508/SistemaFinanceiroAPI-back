using Microsoft.AspNetCore.Mvc;

namespace SistemaFinanceiroAPI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
