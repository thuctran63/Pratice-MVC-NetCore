using Microsoft.EntityFrameworkCore;

namespace EF_Core.Model;

public class TiemChungContext : DbContext
{
    public DbSet<TIEMCHUNG> TIEMCHUNGs { get; set; }
    public DbSet<CONGDAN> CONGDANs { get; set; }
    public DbSet<LIEUVACXIN> LIEUVACXINs { get; set; }
    public DbSet<LOAIVACXIN> LOAIVACXINs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-KAS2D8H;Initial Catalog=TiemChung;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data
        
        modelBuilder.Entity<LOAIVACXIN>().HasData(
            new LOAIVACXIN
            {
                MaLoaiVX = "VX001",
                TenLoaiVX = "AstraZeneca",
                NuocSX = "Anh",
                SoNgayTiemNhac = 84
            },
            new LOAIVACXIN
            {
                MaLoaiVX = "VX002",
                TenLoaiVX = "Pfizer",
                NuocSX = "Mỹ",
                SoNgayTiemNhac = 21
            },
            new LOAIVACXIN
            {
                MaLoaiVX = "VX003",
                TenLoaiVX = "Sputnik V",
                NuocSX = "Nga",
                SoNgayTiemNhac = 21
            }
        );
        
        modelBuilder.Entity<LIEUVACXIN>().HasData(
            new LIEUVACXIN
            {
                MaLieuVX = "VX001-001",
                SoLo = 1,
                MaLoaiVX = "VX001",
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            },
            new LIEUVACXIN
            {
                MaLieuVX = "VX002-001",
                SoLo = 1,
                MaLoaiVX = "VX002",
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            },
            new LIEUVACXIN
            {
                MaLieuVX = "VX003-001",
                SoLo = 1,
                MaLoaiVX = "VX003",
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            }
        );

        modelBuilder.Entity<CONGDAN>().HasData(
            new CONGDAN
            {
                MaCD = "CD001",
                HoTen = "Nguyễn Văn A",
                NgaySinh = new DateTime(1990, 1, 1),
                CMND = "123456789",
                SoDienThoai = "0987654321",
                DiaChi = "Hà Nội",
                Email = ""
            });
    }
}