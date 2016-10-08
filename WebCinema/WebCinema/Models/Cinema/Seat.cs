namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seat()
        {
            Tickets = new HashSet<Ticket>();
        }

        [StringLength(5)]
        [Display(Name = "Mã ghế")]
        public string SeatId { get; set; }

        [Display(Name = "Mã loại ghế")]
        public int? TypeId { get; set; }

        [Display(Name = "Hàng ghế")]
        public int Row_ { get; set; }

        [Display(Name = "Số ghế")]
        public int Number_ { get; set; }

        public virtual TypeOfSeat TypeOfSeat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
