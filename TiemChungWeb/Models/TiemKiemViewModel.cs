using EF_Core.Model;

namespace TiemChungWeb.Models
{
    public class TimKiemViewModel
    {
        public string MaCD { get; set; }
        public List<LOAIVACXIN> LoaiVacxinList { get; set; } // danh sách loại vắc-xin để hiển thị trong combobox
    }
}