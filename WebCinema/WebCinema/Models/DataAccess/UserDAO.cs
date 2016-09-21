using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models.Cinema;

namespace WebCinema.Models.DataAccess
{
    public class UserDAO
    {
        private MovieDbContext db = new MovieDbContext();
        public UserAccount Login(string UserName, string Password)
        {
            UserAccount User = db.UserAccounts.SingleOrDefault(a => a.UserName == UserName && a.Password_ == Password);
            return User;
        }
    }
}