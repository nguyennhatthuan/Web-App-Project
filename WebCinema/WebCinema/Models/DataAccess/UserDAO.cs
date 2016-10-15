using System;
using System.Collections.Generic;
using System.Data;
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

        public int Register(string Username, string Password, string Email, string Phone)
        {
            try
            {
                UserAccount User = new UserAccount();
                User.UserName = Username;
                User.Password_ = Password;
                User.Email = Email;
                User.Phone = Phone;
                db.UserAccounts.Add(User);
                db.SaveChanges();
                return 1;
            }
            catch(DataException)
            {
                return 0;
            }
        }

        public int AddFeedback(FeedBack fb)
        {
            try
            {
                db.FeedBacks.Add(fb);
                db.SaveChanges();
                return 1;
            }
            catch(DataException)
            {
                return 0;
            }
        }
    }
}