using Microsoft.AspNetCore.Mvc;

namespace MVPSenai.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View("Register");
        }
    }
}
