using CoffeeShopWeb.Data;
using CoffeeShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopWeb.Controllers
{
    public class CafeController : Controller
    {
        private readonly CoffeeShopDbContext _db;

        public CafeController(CoffeeShopDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Cafe> objCafeList = _db.Cafes;
            return View(objCafeList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cafe obj)
        {
            if (obj.Name.Length < 4 || obj.Name.Length > 15)
            {
                ModelState.AddModelError("name", "The Name must be more than 3 and less than 16 characters long");
            }
            if (ModelState.IsValid)
            {
                _db.Cafes.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Cafe created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var cafeFromDb = _db.Cafes.Find(id);
            if(cafeFromDb == null)
            {
                return NotFound();
            }
            return View(cafeFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Cafe obj)
        {
            if (obj.Name.Length < 4 || obj.Name.Length > 15)
            {
                ModelState.AddModelError("name", "The Name must be more than 3 and less than 16 characters long");
            }
            if (ModelState.IsValid)
            {
                _db.Cafes.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Cafe updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cafeFromDb = _db.Cafes.Find(id);
            if (cafeFromDb == null)
            {
                return NotFound();
            }
            return View(cafeFromDb);
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var cafeFromDb = _db.Cafes.Find(id);
            if (cafeFromDb == null)
            {
                return NotFound();
            }
            _db.Cafes.Remove(cafeFromDb);
            _db.SaveChanges();
            TempData["success"] = "Cafe removed successfully";
            return RedirectToAction("Index");
        }
    }
}
