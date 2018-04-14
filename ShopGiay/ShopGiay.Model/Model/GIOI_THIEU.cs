namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GIOI_THIEU
    {
        public int ID { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }
    }
}
