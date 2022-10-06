using Academy.Areas.Admin.Models;
using Academy.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Academy.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            var adminService = new AdminService();
            var isLoggedin = adminService.login(loginModel.Email, loginModel.Passsword);
            if(isLoggedin)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                loginModel.Message = "Email or Password is incorrect !";
                return View(loginModel);    
            }
        }
    }
}