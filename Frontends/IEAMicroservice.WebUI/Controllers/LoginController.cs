using Microsoft.AspNetCore.Mvc;

namespace IEAMicroservice.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
