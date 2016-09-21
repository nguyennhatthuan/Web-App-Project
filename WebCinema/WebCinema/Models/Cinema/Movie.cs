namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            Advertisings = new HashSet<Advertising>();
            Comments = new HashSet<Comment>();
            ShowTimes = new HashSet<ShowTime>();
            TypeOfMovies = new HashSet<TypeOfMovie>();
        }

        public int MovieId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? Length_ { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        [StringLength(100)]
        public string Stars { get; set; }

        [Column(TypeName = "ntext")]
        public string Description_ { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(5)]
        public string Format_ { get; set; }

        [StringLength(100)]
        public string Trailer { get; set; }

        [StringLength(50)]
        public string Poster { get; set; }

        [StringLength(50)]
        public string Thumbnail { get; set; }

        [StringLength(50)]
        public string Language_ { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        public bool? Status_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertising> Advertisings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShowTime> ShowTimes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TypeOfMovie> TypeOfMovies { get; set; }
    }
}
