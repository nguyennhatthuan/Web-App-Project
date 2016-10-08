namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TypeOfMovie")]
    public partial class TypeOfMovie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfMovie()
        {
            MovieTypes = new HashSet<MovieType>();
        }

        [Key]
        [Display(Name = "Mã thể loại")]
        public int TypeId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tên thể loại")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieType> MovieTypes { get; set; }
    }
}
