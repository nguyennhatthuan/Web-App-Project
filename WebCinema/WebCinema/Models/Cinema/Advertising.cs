namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Advertising")]
    public partial class Advertising
    {
        [Key]
        public int AdverId { get; set; }

        public int? MovieId { get; set; }

        public bool? Active { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
