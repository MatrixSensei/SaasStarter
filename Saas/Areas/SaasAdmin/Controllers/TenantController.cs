using Microsoft.AspNetCore.Mvc;
using Saas.Data;
using Saas.Models;

namespace Saas.Areas.SaasAdmin.Controllers
{
    [Area("SaasAdmin")]
    public class TenantController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TenantController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Tenant/Index
        public IActionResult Index()
        {
            IEnumerable<Tenant>? objList = _db.SaasTenants;
            return View(objList);
        }

        // GET: Tenant/Upsert/{id}
        public IActionResult Upsert(string? id)
        {
            Tenant? obj;

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
                obj = _db.SaasTenants.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
        }

        // POST: Tenant/Upsert/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Tenant obj)
        {
            if (ModelState.IsValid)
            {
                // If we don't have an ID, then create a new record
                // otherwise we're updating an existing record
                if (obj.Id == null || obj.Id == "new")
                {
                    obj.Id = Guid.NewGuid().ToString();
                    obj.Created = DateTime.Now;
                    obj.Updated = DateTime.Now;
                    _db.SaasTenants.Add(obj);
                    TempData["success"] = "Tenant created successfully";
                }
                else
                {
                    obj.Updated = DateTime.Now;
                    _db.SaasTenants.Update(obj);
                    TempData["success"] = "Tenant updated successfully";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IEnumerable<Tenant> GetTenants()
        {
            return _db.SaasTenants.ToList();
        }

        #region API CALLS

        //POST
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(string id)
        {
            var objFromDb = _db.SaasTenants.Find(id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _db.SaasTenants.Remove(objFromDb);
            _db.SaveChanges();
            //return RedirectToAction("Index");
            return Json(new { success = true, message = "Deleted Successfully" });  // Using Json for Toastr notification
        }

        #endregion
    }
}
