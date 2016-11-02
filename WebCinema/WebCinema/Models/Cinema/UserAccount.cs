namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserAccount")]
    public partial class UserAccount
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserAccount()
        {
            Bills = new HashSet<Bill>();
            Comments = new HashSet<Comment>();
            FeedBacks = new HashSet<FeedBack>();
        }

        [Key]
        [Display(Name = "Mã User")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên user")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Tên User")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string Password_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Tên khách hàng")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên khách hàng")]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]
        public DateTime? Birth { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(15, ErrorMessage = "Không được quá 15 ký tự")]
        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeedBack> FeedBacks { get; set; }
    }
}
