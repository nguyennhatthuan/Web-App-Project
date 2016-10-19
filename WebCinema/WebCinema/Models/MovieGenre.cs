using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCinema.Models.Cinema;
namespace WebCinema.Models
{
    public class MovieGenre
    {
        public int  MovieId { get; set; }
        public string MovieName { get; set; }
        public string MoviePoster { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}