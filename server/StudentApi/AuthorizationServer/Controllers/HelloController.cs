using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationServer.Controllers
{
    public class HelloController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
