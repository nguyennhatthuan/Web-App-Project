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
            MovieTypes = new HashSet<MovieType>();
            ShowTimes = new HashSet<ShowTime>();
        }

        [Display(Name = "Mã phim")]
        public int MovieId { get; set; }

        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên phim")]

        [Display(Name = "Tên phim")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập thơi lượng")]
        [Display(Name = "Thời lượng")]
        public int? Length_ { get; set; }

        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên đạo diễn")]
        [Display(Name = "Đạo diễn")]
        public string Director { get; set; }

        [StringLength(100, ErrorMessage = "Không được quá 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên diễn viên")]
        [Display(Name = "Diễn viên")]
        public string Stars { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Description_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày công chiếu")]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày công chiếu")]
        public DateTime? ReleaseDate { get; set; }

        [StringLength(5, ErrorMessage = "Không được quá 5 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập định dạng phim")]
        [Display(Name = "Định dạng")]
        public string Format_ { get; set; }

        [StringLength(100, ErrorMessage = "Không được quá 100 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập link trailer")]
        public string Trailer { get; set; }

        [StringLength(50)]
        public string Poster { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh nhỏ")]
        public string Thumbnail { get; set; }

        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập ngôn ngữ")]
        [Display(Name = "Ngôn ngữ")]
        public string Language_ { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày tạo")]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime? CreatedDate { get; set; }

        [StringLength(50, ErrorMessage = "Không được quá 50 ký tự")]
        [Required(ErrorMessage = "Vui lòng nhập tên người tạo")]
        [Display(Name = "Người tạo")]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày chỉnh sửa")]
        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Người chỉnh sửa")]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(250)]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tình trạng")]
        [Display(Name = "Tình trạng")]
        public bool? Status_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Advertising> Advertisings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovieType> MovieTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShowTime> ShowTimes { get; set; }
    }
}
