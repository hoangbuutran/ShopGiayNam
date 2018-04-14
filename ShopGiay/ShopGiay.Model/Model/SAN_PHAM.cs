namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SAN_PHAM
    {
        public SAN_PHAM()
        {
            ORDER_DETAIL = new HashSet<ORDER_DETAIL>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string TenSanPham { get; set; }

        [StringLength(100)]
        public string ChiTiet { get; set; }

        [StringLength(100)]
        public string HinhAnh { get; set; }

        public double? PRICE { get; set; }

        public int? SoLuotXem { get; set; }

        public int? Size { get; set; }

        public DateTime? NgayTao { get; set; }

        public int? SoLuongOrder { get; set; }

        [StringLength(100)]
        public string XuatXu { get; set; }

        public bool? TrangThai { get; set; }

        public int? ThuongHieuID { get; set; }

        public int? LoaiSanPhamID { get; set; }

        public virtual LOAI_SAN_PHAM LOAI_SAN_PHAM { get; set; }

        public virtual ICollection<ORDER_DETAIL> ORDER_DETAIL { get; set; }

        public virtual THUONG_HIEU THUONG_HIEU { get; set; }
    }
}
