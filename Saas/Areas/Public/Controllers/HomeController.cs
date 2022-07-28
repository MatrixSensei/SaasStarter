using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saas.Data;
using Saas.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Saas.Areas.Public.Controllers
{
    [Area("Public")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;
        private HttpContext _httpContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IHttpContextAccessor contextAccessor)
        {
            _db = db;
            _logger = logger;
            _httpContext = contextAccessor.HttpContext;
        }

        public IActionResult Index()
        {
            if (User.Identity?.Name == null)
            {
                _httpContext.Session.SetObject("TenantIdOrName", "");
                _httpContext.Session.SetObject("TenantId", "");
                _httpContext.Session.SetObject("TenantName", "");
                return View();
            }
            else
            {
                IEnumerable<Saas.Models.TenantUser> objList = _db.SaasTenantUsers.Include(t => t.Tenant).Include(d => d.User).Where(w => w.User.UserName == User.Identity.Name);
                return View(objList);
            }
        }

        public IActionResult SelectTenant(string? id)
        {
            var tenantRequest = id;
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var userId = claims.Value;
            if (userId == null)
            {
                tenantRequest = null;
                _httpContext.Session.SetObject("TenantIdOrName", "");
                _httpContext.Session.SetObject("TenantId", "");
                _httpContext.Session.SetObject("TenantName", "");
            }
            else
            {
                if (id == null)
                {
                    tenantRequest = _httpContext.Session.GetObject<string>("TenantIdOrName");
                }
                else
                {
                    IEnumerable<Saas.Models.TenantUser> objList = _db.SaasTenantUsers
                        .Include(t => t.Tenant)
                        .Include(d => d.User)
                        .Where(w => w.UserId == userId)
                        .Where(w => w.TenantId == tenantRequest)
                        ;
                    if (objList.Count()>0)
                    {
                        _httpContext.Session.SetObject("TenantIdOrName", tenantRequest);
                        _httpContext.Session.SetObject("TenantId", userId);
                        _httpContext.Session.SetObject("TenantName", objList.FirstOrDefault().Tenant.Name);
                    }
                    else
                    {
                        tenantRequest = null;
                        //throw new Exception("Tenant does not belong to current user!");
                    }
                }
            }
            if (tenantRequest != null)
            {
                var result="User:" + userId + " Tenant:" + id;
                //return Content(result);
                return RedirectToAction("Index", "Product", new { area = "TenantArea" });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}