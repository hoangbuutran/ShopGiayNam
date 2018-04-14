namespace ShopGiay.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GIOI_THIEU",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NoiDung = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.KHACH_HANG",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenKhachHang = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        UserName = c.String(maxLength: 100),
                        Pass = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                        Sdt = c.String(maxLength: 100),
                        PhanQuyenID = c.Int(),
                        PHAN_QUYEN_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PHAN_QUYEN", t => t.PHAN_QUYEN_ID)
                .Index(t => t.PHAN_QUYEN_ID);
            
            CreateTable(
                "dbo.ORDERS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NgayTao = c.DateTime(),
                        TrangThai = c.Boolean(),
                        KhachHangID = c.Int(),
                        KHACH_HANG_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.KHACH_HANG", t => t.KHACH_HANG_ID)
                .Index(t => t.KHACH_HANG_ID);
            
            CreateTable(
                "dbo.ORDER_DETAIL",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TongTien = c.Double(),
                        SanPhamID = c.Int(),
                        OrderID = c.Int(),
                        SAN_PHAM_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ORDERS", t => t.OrderID)
                .ForeignKey("dbo.SAN_PHAM", t => t.SAN_PHAM_ID)
                .Index(t => t.OrderID)
                .Index(t => t.SAN_PHAM_ID);
            
            CreateTable(
                "dbo.SAN_PHAM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenSanPham = c.String(maxLength: 100),
                        ChiTiet = c.String(maxLength: 100),
                        HinhAnh = c.String(maxLength: 100),
                        PRICE = c.Double(),
                        SoLuotXem = c.Int(),
                        Size = c.Int(),
                        NgayTao = c.DateTime(),
                        SoLuongOrder = c.Int(),
                        XuatXu = c.String(maxLength: 100),
                        TrangThai = c.Boolean(),
                        ThuongHieuID = c.Int(),
                        LoaiSanPhamID = c.Int(),
                        LOAI_SAN_PHAM_ID = c.Int(),
                        THUONG_HIEU_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LOAI_SAN_PHAM", t => t.LOAI_SAN_PHAM_ID)
                .ForeignKey("dbo.THUONG_HIEU", t => t.THUONG_HIEU_ID)
                .Index(t => t.LOAI_SAN_PHAM_ID)
                .Index(t => t.THUONG_HIEU_ID);
            
            CreateTable(
                "dbo.LOAI_SAN_PHAM",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenLoaiSanPham = c.String(maxLength: 100),
                        TrangThai = c.Boolean(),
                        ThuTuSapXep = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.THUONG_HIEU",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenThuongHieu = c.String(maxLength: 100),
                        ThuTuSapXep = c.Int(),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PHAN_QUYEN",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TenQuyen = c.String(maxLength: 100),
                        TrangThai = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LIEN_HE",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 100),
                        NoiDung = c.String(unicode: false, storeType: "text"),
                        NgayTao = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KHACH_HANG", "PHAN_QUYEN_ID", "dbo.PHAN_QUYEN");
            DropForeignKey("dbo.SAN_PHAM", "THUONG_HIEU_ID", "dbo.THUONG_HIEU");
            DropForeignKey("dbo.ORDER_DETAIL", "SAN_PHAM_ID", "dbo.SAN_PHAM");
            DropForeignKey("dbo.SAN_PHAM", "LOAI_SAN_PHAM_ID", "dbo.LOAI_SAN_PHAM");
            DropForeignKey("dbo.ORDER_DETAIL", "OrderID", "dbo.ORDERS");
            DropForeignKey("dbo.ORDERS", "KHACH_HANG_ID", "dbo.KHACH_HANG");
            DropIndex("dbo.SAN_PHAM", new[] { "THUONG_HIEU_ID" });
            DropIndex("dbo.SAN_PHAM", new[] { "LOAI_SAN_PHAM_ID" });
            DropIndex("dbo.ORDER_DETAIL", new[] { "SAN_PHAM_ID" });
            DropIndex("dbo.ORDER_DETAIL", new[] { "OrderID" });
            DropIndex("dbo.ORDERS", new[] { "KHACH_HANG_ID" });
            DropIndex("dbo.KHACH_HANG", new[] { "PHAN_QUYEN_ID" });
            DropTable("dbo.LIEN_HE");
            DropTable("dbo.PHAN_QUYEN");
            DropTable("dbo.THUONG_HIEU");
            DropTable("dbo.LOAI_SAN_PHAM");
            DropTable("dbo.SAN_PHAM");
            DropTable("dbo.ORDER_DETAIL");
            DropTable("dbo.ORDERS");
            DropTable("dbo.KHACH_HANG");
            DropTable("dbo.GIOI_THIEU");
        }
    }
}
