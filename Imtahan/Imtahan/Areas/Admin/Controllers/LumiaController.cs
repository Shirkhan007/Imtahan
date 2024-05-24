using Imtahan.DAL;
using Imtahan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Imtahan.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LumiaController : Controller
    {
        AppDbContext _db;

        public LumiaController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
           List<Lumia> lumias=_db.Lumias.ToList();
            return View(lumias);
        }
        public IActionResult Create(int? id)
        {
        return View();  
        }
        [HttpPost]
        public IActionResult Create(Lumia lumia)
        {
            string path = @"C:\\Users\\II novbe\\Desktop\\Imt\\Imtahan\\Imtahan\\wwwroot\\Upload\\slider\\";
            string filename = lumia.PhotoFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            { 
            lumia.PhotoFile.CopyTo(stream);
            
            }
            lumia.ImageUrl= filename;
                if (!ModelState.IsValid)
                {
                    return View();
                }
            _db.Lumias.Add(lumia);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id) 
        {
            var lumias = _db.Lumias.FirstOrDefault(x => x.Id == id);
            _db.Lumias.Remove(lumias);
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        }
        public IActionResult Update(int id)
        { 
        var lumias= _db.Lumias.FirstOrDefault(y => y.Id == id);
            if (lumias == null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Update(Lumia newLumia)
        { 
       
            string path = @"C:\\Users\\II novbe\\Desktop\\Imt\\Imtahan\\Imtahan\\wwwroot\\Upload\\slider\\";
            string filename = newLumia.PhotoFile.FileName;
            using (FileStream stream = new FileStream(path + filename, FileMode.Create))
            {
                newLumia.PhotoFile.CopyTo(stream);

            }
            var oldlumias = _db.Lumias.FirstOrDefault(y => y.Id == newLumia.Id);
            oldlumias.ImageUrl = filename;
            

            if (oldlumias == null)
            {
                return RedirectToAction("Index");
            
            }


            oldlumias.Name = newLumia.Name;
            oldlumias.Title = newLumia.Title;
            oldlumias.Description = newLumia.Description;
            oldlumias.PhotoFile = newLumia.PhotoFile;
            _db.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}
