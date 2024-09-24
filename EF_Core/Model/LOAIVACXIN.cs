using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core.Model;

public class LOAIVACXIN
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaLoaiVX { get; set; }
    public string TenLoaiVX { get; set; }
    public string NuocSX { get; set; }
    public int SoNgayTiemNhac  { get; set; }
    
    public ICollection<LIEUVACXIN> LIEUVACXINs { get; set; }
}