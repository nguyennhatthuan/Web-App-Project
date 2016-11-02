namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Staff")]
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            News = new HashSet<News>();
        }

        [Display(Name = "Mã nhân viên")]
        public int StaffId { get; set; }

        [Display(Name = "Mã nhóm quyền")]
        public int? RGId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên user")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Tên User")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Mật khẩu")]
        public string Password_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên nhân viên")]
        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Display(Name = "Tên nhân viên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
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
        public virtual ICollection<News> News { get; set; }

        public virtual RoleGroup RoleGroup { get; set; }
    }
}
