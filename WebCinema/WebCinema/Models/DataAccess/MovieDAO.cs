using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models.Cinema;

namespace WebCinema.Models.DataAccess
{
    public class MovieDAO
    {
        private MovieDbContext db = new MovieDbContext();
        public List<Movie> GetMovies(int count = 0)
        {
            if (count == 0)
                return db.Movies.ToList();
            else
                return db.Movies.OrderByDescending(m => m.CreatedDate).Take(count).ToList();
        }

        public Movie GetOneMovie(int Id)
        {
            return db.Movies.SingleOrDefault(p => p.MovieId == Id);
        } 
    }
}