namespace ShopGiay.Model.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LIEN_HE
    {
        public int ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string NoiDung { get; set; }

        public DateTime? NgayTao { get; set; }
    }
}
