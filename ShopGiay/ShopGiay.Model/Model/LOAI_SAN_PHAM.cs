namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOAI_SAN_PHAM
    {
        public LOAI_SAN_PHAM()
        {
            SAN_PHAM = new HashSet<SAN_PHAM>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TenLoaiSanPham { get; set; }

        public bool? TrangThai { get; set; }

        public int? ThuTuSapXep { get; set; }

        public virtual ICollection<SAN_PHAM> SAN_PHAM { get; set; }
    }
}
