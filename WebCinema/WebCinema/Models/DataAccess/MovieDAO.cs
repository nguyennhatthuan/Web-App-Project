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

        public List<TypeOfMovie> GetGenreofMovie(int Id)
        {
            return db.TypeOfMovies.Where(t => t.MovieTypes.Any(m => m.MovieId == Id)).ToList();
        }

        public Movie GetOneMovie(int Id)
        {
            return db.Movies.SingleOrDefault(p => p.MovieId == Id);
        } 

        public List<Movie> GetRandomMovies(int count=0)
        {
            return db.Movies.GetRandomItems(count).ToList();
        }

        public List<ShowTime> GetShowTimeMovie(int Id)
        {
            return db.ShowTimes.Where(m => m.MovieId == Id && m.Date.Value.Year >= DateTime.Now.Year
                            && m.Date.Value.Month >= DateTime.Now.Month
                            && m.Date.Value.Day >= DateTime.Now.Day).ToList();
        }
    }
}