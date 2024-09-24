using EF_Core.Model;
using EF_Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using TiemChungWeb.Models;
using X.PagedList;

namespace TiemChungWeb.Controllers;

public class TiemChungController : Controller
{
    private readonly TiemChungRepos _tiemChungRepos;
    private readonly MaLieuVXRepos _maLieuVXRepos;
    private readonly MaLoaiVXRepos _maLoaiVXRepos;

    public TiemChungController(TiemChungRepos tiemChungRepos, MaLieuVXRepos maLieuVXRepos, MaLoaiVXRepos maLoaiVXRepos)
    {
        _tiemChungRepos = tiemChungRepos;
        _maLieuVXRepos = maLieuVXRepos;
        _maLoaiVXRepos = maLoaiVXRepos;
    }
    
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult AddTiemChung()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddTiemChung(TIEMCHUNG tiemchung)
    {
        // Loại bỏ các thuộc tính không cần thiết khỏi ModelState
        ModelState.Remove("CONGDAN");
        ModelState.Remove("LIEUVACXIN");
        ModelState.Remove("MaTC");

        if (!ModelState.IsValid)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View("AddTiemChung", tiemchung);
        }

        if (_maLieuVXRepos.IsMaLieuVXExisted(tiemchung.MaLieuVX))
        {
           
            // Lưu thông báo thành công vào TempData
            TempData["SuccessMessage"] = "Thêm tiêm chủng thành công!";
        
            _tiemChungRepos.AddTiemChung(tiemchung);
            return RedirectToAction("AddTiemChung", controllerName: "TiemChung");
        }
        else
        {
            TempData["Failed"] = "Không tìm thấy mã liều vacxin";
            return View("AddTiemChung", tiemchung);
        }
        
        
    }
    
    [Route("{maCD:int}/{maLoaiVX:int}")]
    public IActionResult ListTiemChung(int? maCD, int? maLoaiVX, int page = 1)
    {
        int pageSize = 12;

        // Lấy danh sách tiêm chủng từ repository
        var list = _tiemChungRepos.ListTiemChung();

        // Lọc danh sách theo MaCD và MaLoaiVX nếu có
        if (maCD.HasValue)
        {
            list = list.Where(item => item.MaCD == maCD.Value).ToList();
        }

        if (maLoaiVX.HasValue)
        {
            list = list.Where(item => item.LIEUVACXIN.LOAIVACXIN.MaLoaiVX == maLoaiVX.Value).ToList();
        }

        // Chuyển đổi sang danh sách ViewModel
        var viewModels = list.Select(item => new TiemChungViewModel()
        {
            MaCD = item.MaCD,
            TenCD = item.CONGDAN.HoTen,
            MaLieuVX = item.MaLieuVX,
            NgayTiemMui1 = item.NgayTiemMui1,
            NgayTiemMui2 = item.NgayTiemMui2,
            NgayDkTiemMui2 = item.NgayDkTiemMui2,
            GhiChu = item.GhiChu,
            TenLoaiVacxin = item.LIEUVACXIN.LOAIVACXIN.TenLoaiVX,
            TrangThai = item.TrangThai
        }).ToPagedList(page, pageSize); // Phân trang

        return View(viewModels); // Trả về view với danh sách ViewModel
    }

    
    
    [HttpGet]
    public IActionResult ListTiemChung(int page = 1)
    {
        int pageSize = 12;
        var list = _tiemChungRepos.ListTiemChung();

        var viewModels = list.Select(item => new TiemChungViewModel()
        {
            MaCD = item.MaCD,
            TenCD = item.CONGDAN.HoTen,
            MaLieuVX = item.MaLieuVX,
            NgayTiemMui1 = item.NgayTiemMui1,
            NgayTiemMui2 = item.NgayTiemMui2,
            NgayDkTiemMui2 = item.NgayDkTiemMui2,
            GhiChu = item.GhiChu,
            TenLoaiVacxin = item.LIEUVACXIN.LOAIVACXIN.TenLoaiVX,
            TrangThai = item.TrangThai
        }).ToPagedList(page, pageSize);

        return View(viewModels);
    }

    
    [HttpGet]
    public IActionResult GetSoNgayTiemNhac(int maLieuVX)
    {
        var lieuVX = _maLieuVXRepos.GetLIEUVACXIN(maLieuVX);
        if (lieuVX != null)
        {
            var loaiVacxin = _maLoaiVXRepos.GetLOAIVACXINByID(lieuVX.MaLoaiVX);
            return Json(loaiVacxin.SoNgayTiemNhac);
        }
        return Json(new { error = "Không tìm thấy loại vắc xin." });

    }


}