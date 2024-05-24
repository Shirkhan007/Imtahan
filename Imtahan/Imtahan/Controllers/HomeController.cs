using Imtahan.DAL;
using Imtahan.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Imtahan.Controllers
{
    public class HomeController : Controller
    {
        AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Lumia> lumias=_context.Lumias.ToList();
            return View(lumias);
        }

        
    }
}
