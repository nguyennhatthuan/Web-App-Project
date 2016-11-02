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

        [StringLength(5, ErrorMessage = "Không được quá 5 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập mã ghế")]
        [Display(Name = "Mã ghế")]
        public string SeatId { get; set; }

        [Display(Name = "Mã loại ghế")]
        public int? TypeId { get; set; }

        [Display(Name = "Hàng ghế")]
        [Required(ErrorMessage = "Vui lòng nhập hàng ghế")]
        [Range(1, int.MaxValue, ErrorMessage = "Số hàng phải lớn hơn 0")]
        public int Row_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số ghế")]
        [Range(1, int.MaxValue, ErrorMessage = "Số ghế phải lớn hơn 0")]
        [Display(Name = "Số ghế")]
        public int Number_ { get; set; }

        public virtual TypeOfSeat TypeOfSeat { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
