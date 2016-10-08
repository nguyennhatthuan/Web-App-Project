using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models;
using WebCinema.Models.Cinema;

namespace WebCinema.Models.DataAccess
{
    public class MovieGenreDAO
    {
        MovieDbContext db = new MovieDbContext();
        private List<Movie> GetMovieTypes(int Id)
        {
            //return db.MovieTypes.Where(p => p.TypeId == Id).ToList();
            return db.Movies.Where(m => m.MovieTypes.Any(l=>l.TypeId==Id)).ToList();
        }

        public List<MovieGenre> GetMovieByGenre(int Id)
        {
            List<Movie> movieTypes = GetMovieTypes(Id);
            List<MovieGenre> Genre = new List<MovieGenre>();
            foreach (var item in movieTypes)
            {
                MovieGenre g = new MovieGenre();
                g.MovieName = item.Name;
                g.MoviePoster = item.Poster;
                g.ReleaseDate = item.ReleaseDate;
                Genre.Add(g);
            }
            return Genre;
        }

        public string GetGenreName(int Id)
        {
            return db.TypeOfMovies.FirstOrDefault(t => t.TypeId == Id).Name.ToString();
        }
    }
}