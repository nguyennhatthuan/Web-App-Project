namespace WebCinema.Models.Cinema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BillDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã hóa đơn")]
        public int BillId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Mã vé")]
        public int TicketId { get; set; }

        [StringLength(50)]
        [Display(Name = "ghi chú")]
        public string Note { get; set; }

        public virtual Bill Bill { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
