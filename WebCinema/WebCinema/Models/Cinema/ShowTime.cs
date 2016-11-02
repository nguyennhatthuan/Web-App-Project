namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShowTime")]
    public partial class ShowTime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShowTime()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Display(Name = "Mã suất chiếu")]
        public int ShowTimeId { get; set; }

        [Display(Name = "Mã phim")]
        public int? MovieId { get; set; }

        [Display(Name = "Mã rạp")]
        public int? RoomId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giờ bắt đầu")]
        [Display(Name = "Giờ bắt đầu")]
        public TimeSpan? StartTime { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày chiếu")]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày chiếu")]
        public DateTime? Date { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Room Room { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
