using System.ComponentModel.DataAnnotations;

namespace EF_Core.Model;

public class LOAIVACXIN
{
    [Key]
    public string MaLoaiVX { get; set; }
    public string TenLoaiVX { get; set; }
    public string NuocSX { get; set; }
    public int SoNgayTiemNhac  { get; set; }
    
    public ICollection<LIEUVACXIN> LIEUVACXINs { get; set; }
}