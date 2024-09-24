using EF_Core.Model;
using Microsoft.EntityFrameworkCore;
namespace EF_Core.Repositories;

public class TiemChungRepos
{
    private readonly TiemChungContext _context;

    public TiemChungRepos(TiemChungContext context)
    {
        _context = context;
    }

    public TIEMCHUNG AddTiemChung(TIEMCHUNG tiemchung)
    {
        _context.TIEMCHUNGs.Add(tiemchung);
        _context.SaveChanges();
        return tiemchung;
    }

    public List<TIEMCHUNG> ListTiemChung()
    {
        return _context.TIEMCHUNGs
            .Include(tc => tc.CONGDAN)
            .Include(tc => tc.LIEUVACXIN.LOAIVACXIN)
            .ToList();
    }


}