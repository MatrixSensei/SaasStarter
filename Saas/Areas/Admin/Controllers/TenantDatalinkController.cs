using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;  // For SelectListItem
using Microsoft.EntityFrameworkCore;
using Saas.Data;
using Saas.Models;
using Saas.Models.ViewModels;

namespace Saas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TenantDatalinkController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TenantDatalinkController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: TenantDatalink/Index
        public IActionResult Index()
        {
            var objList = _db.SaasTenantDatalinks.Include(t => t.Tenant).Include(d => d.Datalink);
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            TenantDatalinkViewModel obj = new TenantDatalinkViewModel()
            {
                TenantList = _db.SaasTenants.Select(d => new SelectListItem
                {
                    Value = d.Id,
                    Text = d.Name
                }),

                DatalinkList = _db.SaasDatalinks.Select(s => new SelectListItem
                {
                    Value = s.Id,
                    Text = s.Name
                })
            };

            if (id == null || id == 0)
            {
                //Create a new record
                obj.TenantDatalink = new Models.TenantDatalink();
            }
            else
            {
                obj.TenantDatalink = _db.SaasTenantDatalinks.SingleOrDefault(w => w.Id == id);
                if (obj.TenantDatalink == null)
                {
                    return NotFound();
                }
            }
            return View(obj);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TenantDatalinkViewModel obj)
        {
            if (ModelState.IsValid)
            {
                // If we don't have an ID, then create a new record
                // otherwise we're updating an existing record
                if (obj.TenantDatalink.Id == null || obj.TenantDatalink.Id == 0)
                {
                    //New
                    _db.SaasTenantDatalinks.Add(obj.TenantDatalink);
                    TempData["success"] = "Tenant/Datalink created successfully";
                }
                else
                {
                    //Edit
                    var objFromDb = _db.SaasTenantDatalinks.FirstOrDefault(u => u.Id == obj.TenantDatalink.Id);
                    if (objFromDb != null)
                    {
                        objFromDb.TenantId = obj.TenantDatalink.TenantId;
                        objFromDb.DatalinkId = obj.TenantDatalink.DatalinkId;
                    }
                    TempData["success"] = "Tenant/Datalink updated successfully";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Invalid");
            //return View(obj);
        }
        #region API CALLS

        //POST
        [HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var objFromDb = _db.SaasTenantDatalinks.SingleOrDefault(w => w.Id == id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _db.SaasTenantDatalinks.Remove(objFromDb);
            _db.SaveChanges();
            //return RedirectToAction("Index");
            return Json(new { success = true, message = "Deleted Successfully" });  // Using Json for Toastr notification
        }

        #endregion
    }
}
