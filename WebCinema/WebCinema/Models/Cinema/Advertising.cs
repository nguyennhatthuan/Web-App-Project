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
        [Display(Name ="Mã Quảng cáo")]
        public int AdverId { get; set; }

        [Display(Name = "Mã phim")]
        public int? MovieId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tình trạng")]
        [Display(Name = "Tình trạng")]
        public bool? Active { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
