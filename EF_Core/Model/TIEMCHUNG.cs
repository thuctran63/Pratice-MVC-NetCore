using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EF_Core.Validation;

namespace EF_Core.Model;

public class TIEMCHUNG
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaTC { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public int MaCD { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public int MaLieuVX { get; set; }
    
    [ValidateDate]
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public DateTime NgayTiemMui1 { get; set; }
    
    [ValidateDate]
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public DateTime NgayTiemMui2 { get; set; }
    
    [ValidateDate]
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public DateTime NgayDkTiemMui2 { get; set; }
    
    [Required(ErrorMessage = "Thông tin này không được để trống.")]
    public int TrangThai { get; set; }
    
    public string GhiChu { get; set; }
    

    [ForeignKey("MaCD")]
    public CONGDAN CONGDAN { get; set; }
    

    [ForeignKey("MaLieuVX")]
    public LIEUVACXIN LIEUVACXIN { get; set; }
}