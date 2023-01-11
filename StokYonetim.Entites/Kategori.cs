using StokYonetim.Entites.Abstract;

namespace StokYonetim.Entites
{
    public class Kategori : BaseEntity
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        public ICollection<Stok> Stoklar { get; set; }

    }
}
