using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core.Model;

public class TIEMCHUNG
{
    [Key]
    public string MaTC { get; set; }
    public string MaCD { get; set; }
    public string MaLieuVX { get; set; }
    public DateTime NgayTiemMui1 { get; set; }
    public DateTime NgayTiemMui2 { get; set; }
    public string NgayDkTiemMui2 { get; set; }
    public int TrangThai { get; set; }
    public string GhiChu { get; set; }
    
    [ForeignKey("MaCD")]
    public CONGDAN CONGDAN { get; set; }
    
    [ForeignKey("MaLieuVX")]
    public LIEUVACXIN LIEUVACXIN { get; set; }
}