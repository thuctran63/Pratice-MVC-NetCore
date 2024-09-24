using EF_Core.Model;

namespace EF_Core.Repositories;

public class MaLoaiVXRepos
{
    private readonly TiemChungContext _context;

    public MaLoaiVXRepos(TiemChungContext context)
    {
        _context = context;
    }

    public LOAIVACXIN GetLOAIVACXINByID(int id)
    {
        return _context.LOAIVACXINs.Find(id);
    }

    public List<LOAIVACXIN> GetAllLOAIVACXIN()
    {
        return _context.LOAIVACXINs.ToList();
    }
}