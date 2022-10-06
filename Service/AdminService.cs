using Academy.Interfaces;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy.Service
{
    public class AdminService : IAdminService
    {
        public AcademyEntities context { get; set; }
        public AdminService()
        {
            context =new AcademyEntities();
        }
        public bool login(string Email, string Password)
        {
            return context.Admins.Where(X => X.Eamil == Email && X.Password == Password).Any();
             
        }
        public bool chnagePAssword(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string Email)
        {
            throw new NotImplementedException();
        }

       
    }
}