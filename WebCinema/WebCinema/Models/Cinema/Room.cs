namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            ShowTimes = new HashSet<ShowTime>();
        }
        [Display(Name = "Mã rạp")]
        public int RoomId { get; set; }

        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên rạp")]
        [Display(Name = "Tên rạp")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
