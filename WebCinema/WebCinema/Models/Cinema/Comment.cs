namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        [Display(Name = "Mã bình luận")]
        public int CommentId { get; set; }

        [Display(Name = "Mã phim")]
        public int? MovieId { get; set; }

        [Display(Name = "Mã người dùng")]
        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        public DateTime? Date_ { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Nội dung")]
        public string Content { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
