namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleGroup")]
    public partial class RoleGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleGroup()
        {
            Staffs = new HashSet<Staff>();
        }

        [Key]
        [Display(Name = "Mã nhóm quyền")]
        public int RGId { get; set; }

        [StringLength(30)]
        [Display(Name = "Tên nhóm quyền")]
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
