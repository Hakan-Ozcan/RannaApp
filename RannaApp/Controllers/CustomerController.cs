using Microsoft.AspNetCore.Mvc;

namespace RannaUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
