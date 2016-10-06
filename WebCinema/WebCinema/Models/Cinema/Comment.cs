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
        public int CommentId { get; set; }

        public int? MovieId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date_ { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual UserAccount UserAccount { get; set; }
    }
}
