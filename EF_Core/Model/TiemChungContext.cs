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
                MaLoaiVX = 1,
                TenLoaiVX = "AstraZeneca",
                NuocSX = "Anh",
                SoNgayTiemNhac = 84
            },
            new LOAIVACXIN
            {
                MaLoaiVX = 2,
                TenLoaiVX = "Pfizer",
                NuocSX = "Mỹ",
                SoNgayTiemNhac = 21
            },
            new LOAIVACXIN
            {
                MaLoaiVX = 3,
                TenLoaiVX = "Sputnik V",
                NuocSX = "Nga",
                SoNgayTiemNhac = 21
            }
        );
        
        modelBuilder.Entity<LIEUVACXIN>().HasData(
            new LIEUVACXIN
            {
                MaLieuVX = 1,
                MaLoaiVX = 1,
                SoLo = 1,
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            },
            new LIEUVACXIN
            {
                MaLieuVX = 2,
                MaLoaiVX = 1,
                SoLo = 1,
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            },
            new LIEUVACXIN
            {
                MaLieuVX = 3,
                MaLoaiVX = 2,
                SoLo = 1,
                NgaySanXuat = new DateTime(2021, 1, 1),
                NgayHetHan = new DateTime(2022, 1, 1)
            }
        );

        modelBuilder.Entity<CONGDAN>().HasData(
            new CONGDAN
            {
                MaCD = 1,
                HoTen = "Nguyễn Văn A",
                NgaySinh = new DateTime(1990, 1, 1),
                CMND = "123456789",
                SoDienThoai = "0987654321",
                DiaChi = "Hà Nội",
                Email = ""
            });
    }
}