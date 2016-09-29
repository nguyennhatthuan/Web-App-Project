namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [Display(Name = "Mã tin tức")]
        public int NewsId { get; set; }

        [Display(Name = "Mã loại tin tức")]
        public int? TypeId { get; set; }

        [Display(Name = "Mã nhân viên")]
        public int? StaffId { get; set; }

        [StringLength(100)]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người chỉnh sửa")]
        public string ModifiedBy { get; set; }

        public virtual Staff Staff { get; set; }

        public virtual TypeOfNew TypeOfNew { get; set; }
    }
}
