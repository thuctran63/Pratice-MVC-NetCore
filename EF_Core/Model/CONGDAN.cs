using System.ComponentModel.DataAnnotations;

namespace EF_Core.Model;

public class CONGDAN
{
    [Key]
    public string MaCD { get; set; }
    public string HoTen { get; set; }
    public DateTime NgaySinh { get; set; }
    public string CMND { get; set; }
    public string SoDienThoai { get; set; }
    public string DiaChi { get; set; }
    public string Email { get; set; }
    
    public ICollection<TIEMCHUNG> TIEMCHUNGs { get; set; }
}