using Microsoft.AspNetCore.Mvc;
using Saas.Data;
using Saas.Models;

namespace Saas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DatalinkController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DatalinkController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Datalink/Index
        public IActionResult Index()
        {
            IEnumerable<Datalink>? objList = _db.SaasDatalinks;
            return View(objList);
        }

        // GET: Datalink/Upsert/{id}
        public IActionResult Upsert(string? id)
        {
            Datalink? obj;

            // If we don't have an ID, then create a new record
            // otherwise we're updating an existing record
            if (id == null)
            {
                //Create a new record
                obj = new();
                return View(obj);
            }
            else
            {
                // Update the current record
                obj = _db.SaasDatalinks.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
        }

        // POST: Datalink/Upsert/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Datalink obj)
        {
            if (ModelState.IsValid)
            {
                // If we don't have an ID, then create a new record
                // otherwise we're updating an existing record
                if (obj.Id == null || obj.Id == "new")
                {
                    obj.Id = Guid.NewGuid().ToString();
                    _db.SaasDatalinks.Add(obj);
                    TempData["success"] = "Datalink created successfully";
                }
                else
                {
                    _db.SaasDatalinks.Update(obj);
                    TempData["success"] = "Datalink updated successfully";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS

        //POST
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            var objFromDb = _db.SaasDatalinks.Find(id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _db.SaasDatalinks.Remove(objFromDb);
            _db.SaveChanges();
            //return RedirectToAction("Index");
            return Json(new { success = true, message = "Deleted Successfully" });  // Using Json for Toastr notification
        }

        #endregion
    }
}
