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
            BillDetails = new HashSet<BillDetail>();
        }

        public int TicketId { get; set; }

        [StringLength(5)]
        public string SeatId { get; set; }

        public int? ShowTimeId { get; set; }

        public DateTime? BookingDate { get; set; }

        public bool? Status_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }

        public virtual Seat Seat { get; set; }

        public virtual ShowTime ShowTime { get; set; }
    }
}
