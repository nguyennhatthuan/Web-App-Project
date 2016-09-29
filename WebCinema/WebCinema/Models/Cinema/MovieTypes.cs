using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebCinema.Models.Cinema
{
    public class MovieTypes
    {
        [Display(Name = "Diễn viên")]
        public int MovieId { get; set; }
        [Display(Name = "Diễn viên")]
        public int TypeId { get; set; }

    }
}