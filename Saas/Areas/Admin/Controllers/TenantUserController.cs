using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;  // For SelectListItem
using Microsoft.EntityFrameworkCore;
using Saas.Data;
using Saas.Models;
using Saas.Models.ViewModels;

namespace Saas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TenantUserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TenantUserController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: TenantUser/Index
        public IActionResult Index()
        {
            var objList = _db.SaasTenantUsers.Include(t => t.Tenant).Include(d => d.User);
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            TenantUserViewModel obj = new TenantUserViewModel()
            {
                TenantList = _db.SaasTenants.Select(d => new SelectListItem
                {
                    Value = d.Id,
                    Text = d.Name
                }),

                //UserList = _db.ApplicationUsers.Select(s => new SelectListItem
                UserList = _db.Users.Select(s => new SelectListItem
                {
                    Value = s.Id,
                    Text = s.UserName
                })
            };

            if (id == null || id == 0)
            {
                obj.TenantUser = new TenantUser();
                //Create a new record
                obj = new();
            }
            else
            {
                obj.TenantUser = _db.SaasTenantUsers.SingleOrDefault(w => w.Id == id);
                if (obj.TenantUser == null)
                {
                    return NotFound();
                }
            }
            return View(obj);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(TenantUserViewModel obj)
        {
            if (ModelState.IsValid)
            {
                // If we don't have an ID, then create a new record
                // otherwise we're updating an existing record
                if (obj.TenantUser.Id == null || obj.TenantUser.Id == 0)
                {
                    //New
                    _db.SaasTenantUsers.Add(obj.TenantUser);
                    TempData["success"] = "Tenant/User created successfully";
                }
                else
                {
                    //Edit
                    var objFromDb = _db.SaasTenantUsers.FirstOrDefault(u => u.Id == obj.TenantUser.Id);
                    if (objFromDb != null)
                    {
                        objFromDb.TenantId = obj.TenantUser.TenantId;
                        objFromDb.UserId = obj.TenantUser.UserId;
                    }
                    TempData["success"] = "Tenant/User updated successfully";
                }
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return Content("Invalid");
            //return View(obj);
        }
    }
}
