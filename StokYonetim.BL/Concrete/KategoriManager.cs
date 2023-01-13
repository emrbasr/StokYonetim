using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;

namespace StokYonetim.BL.Concrete
{
    public class KategoriManager : ManagerBase<Kategori>, IKategoriManager
    {
        public KategoriManager(StokYonetimDbContext dbContext) : base(dbContext)
        {
        }
    }
}
