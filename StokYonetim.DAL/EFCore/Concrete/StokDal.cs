using StokYonetim.DAL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;

namespace StokYonetim.DAL.EFCore.Concrete
{
    public class StokDal : RepostoryBase<Stok>, IStokDal
    {
        public StokDal(StokYonetimDbContext dbContext) : base(dbContext)
        {
        }
    }
}
