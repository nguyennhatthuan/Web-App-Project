namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfSeat")]
    public partial class TypeOfSeat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfSeat()
        {
            Seats = new HashSet<Seat>();
        }

        [Key]
        [Display(Name = "Mã loại ghế")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập loại ghế")]
        [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
        [Display(Name = "Tên loại ghế")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập đơn giá")]
        [Range(1, int.MaxValue, ErrorMessage = "Số tiền phải lớn hơn 0")]
        [Display(Name = "Đơn giá")]
        public decimal? Price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
