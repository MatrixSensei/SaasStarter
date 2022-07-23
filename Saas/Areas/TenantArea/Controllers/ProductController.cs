using Microsoft.AspNetCore.Mvc;
using TenantResources.Data;
using TenantResources.Models;

namespace Saas.Areas.TenantArea.Controllers
{
    [Area("TenantArea")]
    public class ProductController : Controller
    {
        private readonly TenantDbContext _db;

        public ProductController(TenantDbContext db)
        {
            _db = db;
        }

        // GET: TenantArea/Product/Index
        public IActionResult Index()
        {
            IEnumerable<Product>? objList = _db.Products;
            return View(objList);
        }

        // GET: Datalink/Upsert/{id}
        public IActionResult Upsert(string? id)
        {
            Product? obj;

            // If we don't have an ID, then create a new record
            // otherwise we're updating an existing record
            if (id == null)
            {
                //Create a new record

                ////getting error:
                ////    'Product.Product()' is inaccessible due to its protection level ???????
                //obj = new();
                //return View(obj);

                return Content("Upsert Request");
            }
            else
            {
                // Update the current record
                obj = _db.Products.Find(id);
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
        public IActionResult Upsert(Product obj)
        {
            if (ModelState.IsValid)
            {
                // If we don't have an ID, then create a new record
                // otherwise we're updating an existing record
                if (obj.Id == null || obj.Id == 0)
                {
                    _db.Products.Add(obj);
                    TempData["success"] = "Product created successfully";
                }
                else
                {
                    _db.Products.Update(obj);
                    TempData["success"] = "Product updated successfully";
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
            var objFromDb = _db.Products.Find(id);
            if (objFromDb == null)
            {
                return NotFound();
            }
            _db.Products.Remove(objFromDb);
            _db.SaveChanges();
            //return RedirectToAction("Index");
            return Json(new { success = true, message = "Deleted Successfully" });  // Using Json for Toastr notification
        }

        #endregion
    }
}