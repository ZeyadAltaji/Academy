using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Interfaces
{
    public interface IAdminService
    {
        bool login(string Email, string Password);
        bool chnagePAssword(string Email, string Password);
        bool ForgotPassword(string Email);
    }
}
