namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class KHACH_HANG
    {
        public KHACH_HANG()
        {
            ORDERS = new HashSet<ORDER>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Pass { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Sdt { get; set; }

        public int? PhanQuyenID { get; set; }

        public virtual PHAN_QUYEN PHAN_QUYEN { get; set; }

        public virtual ICollection<ORDER> ORDERS { get; set; }
    }
}
