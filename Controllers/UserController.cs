using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace ROSARIOAPP.Controllers
{
    [Authorize]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        UserManager<IdentityUser> userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        
        public IActionResult Index()
        {
            var users = userManager.Users.ToList();
            return View(users);
        }

       
        public IActionResult Create()
        {
            return View(new IdentityUser());
        }

        [HttpPost]
        public async Task<IActionResult> Create(IdentityUser user)
        {
            await userManager.CreateAsync(user);
            return RedirectToAction("Index");

        }
           [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
               
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index", userManager.Users);
        }
    }
}
       

