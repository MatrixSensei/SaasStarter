using Microsoft.AspNetCore.Mvc;
using TenantResources.Data;
using TenantResources.Models;

namespace Saas.Areas.TenantArea.Controllers
{
    [Area("Product")]
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
            return Content("Test");
            //IEnumerable<Product>? objList = _db.Products;
            //return View(objList);
        }
    }
}