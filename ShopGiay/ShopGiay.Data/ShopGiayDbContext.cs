namespace ShopGiay.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using ShopGiay.Model.Model;

    public class ShopGiayDbContext : DbContext
    {
        public ShopGiayDbContext()
            : base("ShopGiayDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<GIOI_THIEU> GIOI_THIEU { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<LIEN_HE> LIEN_HE { get; set; }
        public virtual DbSet<LOAI_SAN_PHAM> LOAI_SAN_PHAM { get; set; }
        public virtual DbSet<ORDER_DETAIL> ORDER_DETAIL { get; set; }
        public virtual DbSet<ORDER> ORDERS { get; set; }
        public virtual DbSet<PHAN_QUYEN> PHAN_QUYEN { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
        public virtual DbSet<THUONG_HIEU> THUONG_HIEU { get; set; }

        public static ShopGiayDbContext Create()
        {
            return new ShopGiayDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
