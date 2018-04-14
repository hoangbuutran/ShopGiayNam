namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_DETAIL
    {
        public int ID { get; set; }

        public double? TongTien { get; set; }

        public int? SanPhamID { get; set; }

        public int? OrderID { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual SAN_PHAM SAN_PHAM { get; set; }
    }
}
