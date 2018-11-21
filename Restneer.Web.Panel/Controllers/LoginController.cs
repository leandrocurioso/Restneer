using Microsoft.AspNetCore.Mvc;

namespace Restneer.Web.Panel.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
