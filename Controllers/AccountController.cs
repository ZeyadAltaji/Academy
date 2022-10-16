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
        private readonly UserManager<MyIdentityUser> usermanager;
        public AccountController()
        {
            var DB = new AcademyIdentityDBContext();
            var userStore = new UserStore<MyIdentityUser>(DB);
            usermanager = new UserManager<MyIdentityUser>(userStore);
        }

        // GET: Account

        public ActionResult index()
        {
            return View();
        }
        public async Task<ActionResult> Login()
        {
            //var user = await usermanager.CreateAsync(new MyIdentityUser
            //{
            //    Email = "test@test.com",
            //    UserName = "Zeyad"
            //}, "opqw2011");
            //ViewBag.User = user.Succeeded;
            usermanager.AddToRole("ba91edd9-e98e-4efb-9dfc-173422fcab98", "Admin");
            var LoginAcc = usermanager.Find("Zeyad", "opqw2011");
            ViewBag.User = LoginAcc.Email;
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}