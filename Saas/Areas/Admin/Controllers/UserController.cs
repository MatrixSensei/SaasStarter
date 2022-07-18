using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Saas.Models;

namespace Saas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        //private UserManager<ApplicationUser> _userManager;
        private UserManager<IdentityUser> _userManager;

        //===== For User Update password management =========================
        //public UserController(UserManager<ApplicationUser> usrMgr)
        //{
        //    userManager = usrMgr;
        //}

        //private IPasswordHasher<ApplicationUser> _passwordHasher;
        private IPasswordHasher<IdentityUser> _passwordHasher;

        //public UserController(UserManager<ApplicationUser> usrMgr, IPasswordHasher<ApplicationUser> passwordHash)
        public UserController(UserManager<IdentityUser> usrMgr, IPasswordHasher<IdentityUser> passwordHash)
        {
            _userManager = usrMgr;
            _passwordHasher = passwordHash;
        }
        //===================================================================

        public IActionResult Index()
        {
            return View(_userManager.Users);
        }

        [HttpPost]
        //public async Task<IActionResult> Create(ApplicationUser user)
        public async Task<IActionResult> Create(IdentityUser user)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser appUser = new ApplicationUser
                IdentityUser appUser = new IdentityUser
                {
                    Email = user.Email
                };
                //IdentityResult result = await userManager.CreateAsync(appUser, user.Password);
                //if (result.Succeeded)
                //    return RedirectToAction("Index");
                //else
                //{
                //    foreach (IdentityError error in result.Errors)
                //        ModelState.AddModelError("", error.Description);
                //}
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            //ApplicationUser user = await _userManager.FindByIdAsync(id);
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            //ApplicationUser user = await _userManager.FindByIdAsync(id);
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(password))
                    user.PasswordHash = _passwordHasher.HashPassword(user, password);
                else
                    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View(user);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            //ApplicationUser user = await _userManager.FindByIdAsync(id);
            IdentityUser user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", _userManager.Users);
        }

    }
}
