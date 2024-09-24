using EF_Core.Model;

namespace EF_Core.Repositories;

public class CongDanRepos
{
    private readonly TiemChungContext _context;
    
    public CongDanRepos(TiemChungContext context)
    {
        _context = context;
    }
    
    public IEnumerable<CONGDAN> GetAll()
    {
        return _context.CONGDANs.ToList();
    }
    
    public CONGDAN GetByMaCD(int maCD)
    {
        return _context.CONGDANs.Find(maCD);
    }
    
    public void Add(CONGDAN congdan)
    {
        _context.CONGDANs.Add(congdan);
        _context.SaveChanges();
    }
    
    public void Update(CONGDAN congdan)
    {
        _context.CONGDANs.Update(congdan);
        _context.SaveChanges();
    }
    
    public void Delete(CONGDAN congdan)
    {
        _context.CONGDANs.Remove(congdan);
        _context.SaveChanges();
    }
    
    public void Delete(int maCD)
    {
        var congdan = GetByMaCD(maCD);
        if (congdan != null)
        {
            Delete(congdan);
        }
    }
    
    public bool Exists(int maCD)
    {
        return _context.CONGDANs.Any(e => e.MaCD == maCD);
    }
}