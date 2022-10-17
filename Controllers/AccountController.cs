using Academy.Models;
using Academy.Service;
using Data_Access;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Academy.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> usermanager;
        private readonly TraineeService Traineeservice;
        public AccountController()
        {
            var DB = new AcademyIdentityDBContext();
            var userStore = new UserStore<MyIdentityUser>(DB);
            usermanager = new UserManager<MyIdentityUser>(userStore);
            Traineeservice = new TraineeService();
        }

        // GET: Account

        public ActionResult index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login(string ReturnUrl = "")
        {
            //var user = await usermanager.CreateAsync(new MyIdentityUser
            //{
            //    Email = "test@test.com",
            //    UserName = "Zeyad"
            //}, "opqw2011");
            //ViewBag.User = user.Succeeded;
            //usermanager.AddToRole("ba91edd9-e98e-4efb-9dfc-173422fcab98", "Admin");
            //var LoginAcc = usermanager.Find("Zeyad", "opqw2011");
            //ViewBag.User = LoginAcc.Email;
            return View(new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel logindata)
        {
            if (ModelState.IsValid)
            { 
                  var Exitlogin =await usermanager.FindAsync(logindata.Email, logindata.Password);
                 if(Exitlogin != null)
                 {
                     await SignIn(Exitlogin);
                    // Business //
                    if (!string.IsNullOrEmpty(logindata.ReturnUrl))
                    {
                        return Redirect(logindata.ReturnUrl);
                    }
                      var userRole=  usermanager.GetRoles(Exitlogin.Id);
                      var role = userRole.FirstOrDefault();
                    if(role == "Admin")
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                
                    return RedirectToAction("Index", "Dashboard");
                 }
            logindata.Message = "Email or Password is Incorrect !";
            }
            return View(logindata);
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel resUser)
        {
            if(ModelState.IsValid)
            {
                var IdentityUser = new MyIdentityUser
                {
                    Email = resUser.Email,
                    UserName = resUser.Email
                };
                var createdUser = await usermanager.CreateAsync(IdentityUser,resUser.Password);
                //user created 
                if (createdUser.Succeeded)
                {
                    var userid = IdentityUser.Id;
                    usermanager.AddToRole(userid, "Trainee");
                    // Role created
                    if (createdUser.Succeeded)
                    {
                        // Save to Trainee table
                        var saveingres = Traineeservice.Create(new Trainee
                        {
                            Email = resUser.Email,
                            Name = resUser.Name,
                            IS_Active = true,
                            Creation_Date = DateTime.Now

                        });
                        if (saveingres == null)
                        {
                            resUser.Message = "An Error while Creatung Your Account !!";
                            return View(resUser);
                        }
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });

                    }
                }
              
                var message = createdUser.Errors.FirstOrDefault();
                resUser.Message = message;
            }

            return View(resUser);
        }
        private async Task SignIn(MyIdentityUser myIdentityUser)
        {
            var Identity =await usermanager.CreateIdentityAsync(myIdentityUser,DefaultAuthenticationTypes.ApplicationCookie);
            var owinContext = Request.GetOwinContext();
            var authmanager = owinContext.Authentication;
            authmanager.SignIn(Identity);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            var owinContext = Request.GetOwinContext();
            var authManager = owinContext.Authentication;
            authManager.SignOut("ApplicationCookie");
            Session.Abandon();
            return RedirectToAction("Index", "Default");

        }
    }
}