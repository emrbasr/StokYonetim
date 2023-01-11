using StokYonetim.Entites.Abstract;

namespace StokYonetim.Entites
{
    public class Stok : BaseEntity
    {
        public int Id { get; set; }
        public string StakAdi { get; set; }
        public string Birim { get; set; }
        public int Fiyat { get; set; }
        public int Adet { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }

    }
}