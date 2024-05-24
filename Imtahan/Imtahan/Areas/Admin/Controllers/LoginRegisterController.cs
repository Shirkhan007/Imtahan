using Microsoft.AspNetCore.Mvc;

namespace Imtahan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
