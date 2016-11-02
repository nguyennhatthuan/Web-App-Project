namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bill")]
    public partial class Bill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            BillDetails = new HashSet<BillDetail>();
        }

        [Display(Name ="Mã hóa đơn")]
        public int BillId { get; set; }

        [Column(TypeName = "date")]
        [Required(ErrorMessage = "Vui lòng nhập ngày")]
        [Display(Name = "Ngày lập hóa đơn")]
        public DateTime? Date_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số tiền")]
        [Range(1, int.MaxValue, ErrorMessage = "Giá tiền phải lớn hơn 0")]
        [Display(Name = "Thành tiền")]
        public decimal? Price { get; set; }

        [Display(Name = "Mã User")]
        public int? UserId { get; set; }

        public virtual UserAccount UserAccount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
