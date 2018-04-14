namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        public ORDER()
        {
            ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }

        public int ID { get; set; }

        public DateTime? NgayTao { get; set; }

        public bool? TrangThai { get; set; }

        public int? KhachHangID { get; set; }

        public virtual KHACH_HANG KHACH_HANG { get; set; }

        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }
    }
}
