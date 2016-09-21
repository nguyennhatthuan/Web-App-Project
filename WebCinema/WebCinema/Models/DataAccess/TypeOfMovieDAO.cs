using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models.Cinema;

namespace WebCinema.Models.DataAccess
{
    public class TypeOfMovieDAO
    {
        private MovieDbContext db = new MovieDbContext();
        public List<TypeOfMovie> GetMovieGenre()
        {
            return db.TypeOfMovies.OrderByDescending(g => g.Name).ToList();
        }
    }
}