using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_Core.Model;

public class LIEUVACXIN
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MaLieuVX { get; set; }
    public int SoLo { get; set; }
    public int MaLoaiVX { get; set; }
    public DateTime NgaySanXuat { get; set; }
    public DateTime NgayHetHan { get; set; }
    
    [ForeignKey("MaLoaiVX")]
    public LOAIVACXIN LOAIVACXIN { get; set; }
}