using Microsoft.AspNetCore.Mvc;

namespace Amazon.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
