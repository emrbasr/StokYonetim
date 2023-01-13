using StokYonetim.BL.Abstract;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;

namespace StokYonetim.BL.Concrete
{
    public class StokManager : ManagerBase<Stok>, IStokManager
    {
        private readonly StokYonetimDbContext dbContext;

        public StokManager(StokYonetimDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public override async Task<int> CreateAsync(Stok entity)
        {
            var kategori = dbContext.Kategoriler.FirstOrDefault(p => p.Id == entity.KategoriId);
            if (kategori == null)
            {
                return 0;
            }

            return await base.CreateAsync(entity);
        }
    }
}
