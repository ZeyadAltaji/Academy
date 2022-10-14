using Data_Access;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Academy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> userManager;
        public AccountController()
        {
            var DB = new AcademyIdentityDBContext();
            var userStore = new UserStore<MyIdentityUser>(DB);
            userManager = new UserManager<MyIdentityUser>(userStore);

        }
        // GET: Account
        public async Task<ActionResult> Login()
        {
            var user = await userManager.CreateAsync(new MyIdentityUser
            {
                Email = "Test@test.com",
                UserName = "Test"
            }, "123456");
            ViewBag.User = user.Succeeded;
            return View();
        }
    }
}