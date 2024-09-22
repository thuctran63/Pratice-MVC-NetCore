using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core.Model;

public class TIEMCHUNG
{
    [Key]
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public string MaTC { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public string MaCD { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public string MaLieuVX { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public DateTime NgayTiemMui1 { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public DateTime NgayTiemMui2 { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public string NgayDkTiemMui2 { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public int TrangThai { get; set; }
    
    public string GhiChu { get; set; }
    
    [ForeignKey("MaCD")]
    public CONGDAN CONGDAN { get; set; }
    
    [ForeignKey("MaLieuVX")]
    public LIEUVACXIN LIEUVACXIN { get; set; }
}