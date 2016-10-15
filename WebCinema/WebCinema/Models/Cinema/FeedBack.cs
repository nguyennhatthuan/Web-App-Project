namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FeedBack")]
    public partial class FeedBack
    {
        [Display(Name = "Mã phản hồi")]
        public int FeedBackId { get; set; }

        [Display(Name = "Mã User")]
        public int? UserId { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        [Display(Name = "Ngày phản hồi")]
        public DateTime? CreatedDate { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
