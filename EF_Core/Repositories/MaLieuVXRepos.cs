using EF_Core.Model;

namespace EF_Core.Repositories;

public class MaLieuVXRepos
{
    private readonly TiemChungContext _tiemChungContext;

    public MaLieuVXRepos(TiemChungContext tiemChungContext)
    {
        _tiemChungContext = tiemChungContext;
    }

    public bool IsMaLieuVXExisted(int maLieuVXId)
    {
        var rs = _tiemChungContext.LIEUVACXINs.Find(maLieuVXId);
        return rs != null;
    }

    public LIEUVACXIN GetLIEUVACXIN(int maLieuVXId)
    {
        return _tiemChungContext.LIEUVACXINs.Find(maLieuVXId);
    }
}