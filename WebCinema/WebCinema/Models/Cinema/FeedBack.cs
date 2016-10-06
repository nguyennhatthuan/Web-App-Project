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
        public int FeedBackId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }

        public TimeSpan? CreatedDate { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
