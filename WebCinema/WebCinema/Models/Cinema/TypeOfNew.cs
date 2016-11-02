namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TypeOfNew
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypeOfNew()
        {
            News = new HashSet<News>();
        }

        [Key]
        [Display(Name = "Mã loại tin tức")]
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thể loại tin")]
        [StringLength(30, ErrorMessage = "Không được quá 30 ký tự")]
        [Display(Name = "Tên loại tin tức")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<News> News { get; set; }
    }
}
