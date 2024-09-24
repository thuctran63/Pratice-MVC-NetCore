using EF_Core.Repositories;
using Microsoft.AspNetCore.Mvc;
using TiemChungWeb.Models;

namespace TiemChungWeb.ViewComponents;

[ViewComponent(Name = "NavTiemChung")]
public class NavTiemChungViewComponent : ViewComponent
{
    private readonly MaLoaiVXRepos _maLoaiVXRepos;

    [ActivatorUtilitiesConstructor]
    public NavTiemChungViewComponent(MaLoaiVXRepos tiemChungRepository)
    {
        _maLoaiVXRepos = tiemChungRepository;
    }

    public IViewComponentResult Invoke()
    {
        var loaiVacxinList = _maLoaiVXRepos.GetAllLOAIVACXIN();
            
        // Khởi tạo view model
        var viewModel = new TimKiemViewModel
        {
            LoaiVacxinList = loaiVacxinList.ToList()
        };

        return View(viewModel); // Trả về view cho NavTiemChung
    }
}