namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PHAN_QUYEN
    {
        public PHAN_QUYEN()
        {
            KHACH_HANG = new HashSet<KHACH_HANG>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TenQuyen { get; set; }

        public bool? TrangThai { get; set; }

        public virtual ICollection<KHACH_HANG> KHACH_HANG { get; set; }
    }
}
