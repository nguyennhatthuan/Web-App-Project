namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MovieType
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã phim")]
        public int MovieId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã thể loại")]
        public int TypeId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? Date { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual TypeOfMovie TypeOfMovie { get; set; }
    }
}
