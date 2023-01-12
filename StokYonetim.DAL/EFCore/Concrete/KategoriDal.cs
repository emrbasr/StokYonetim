using StokYonetim.DAL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class KategoriDal : RepostoryBase<Kategori>, IKategoriDal
    {
        public KategoriDal(StokYonetimDbContext dbContext) : base(dbContext)
        {
        }
    }
}
