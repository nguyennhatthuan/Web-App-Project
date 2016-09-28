namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Verifies = new HashSet<Verify>();
        }
        [Display(Name = "Mã vé")]
        public int TicketId { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? UserId { get; set; }

        [StringLength(5)]
        [Display(Name = "Mã ghế")]
        public string SeatId { get; set; }

        [Display(Name = "Mã suất chiếu")]
        public int? ShowTimeId { get; set; }

        [Display(Name = "Ngày đặt vé")]
        public DateTime? BookingDate { get; set; }

        [Display(Name = "Tình trạng")]
        public bool? Status_ { get; set; }

        [Display(Name = "Tổng tiền")]
        public decimal? TotalPrice { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual ShowTime ShowTime { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Verify> Verifies { get; set; }
    }
}
