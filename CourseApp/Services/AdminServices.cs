using CourseApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseApp.Services
{
    public interface IAdminService
    {
        bool Login(string email, string password);
        bool ChangePassword(string email, string password);
        bool ForgotPassword(string email);

    }
    public class AdminServices : IAdminService
    {
        CousesAppContext context;
        public AdminServices()
        {
            context = new CousesAppContext();
        }

        public bool Login(string email, string password)
        {
           return  context.Admins.
                Where(a => a.Email == email && a.Password == password).
                Any();
        }
        public bool ChangePassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public bool ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        
    }
}