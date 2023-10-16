using Microsoft.AspNetCore.Mvc;

namespace IEAMicroservice.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
