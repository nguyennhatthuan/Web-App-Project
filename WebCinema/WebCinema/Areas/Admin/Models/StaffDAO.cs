using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models.Cinema;

namespace WebCinema.Areas.Admin.Models
{
    public class StaffDAO
    {
        private MovieDbContext db = new MovieDbContext();

        public Staff Login(string Username, string Password)
        {
            Staff User = db.Staffs.SingleOrDefault(u => u.UserName == Username && u.Password_ == Password);
            return User;
        }
    }
}