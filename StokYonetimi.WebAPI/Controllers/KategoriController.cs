using Microsoft.AspNetCore.Mvc;
using StokYonetim.DAL.EFCore.Concrete;

namespace StokYonetimi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly KategoriDal kategoriDal;

        public KategoriController(KategoriDal kategoriDal)
        {
            this.kategoriDal = kategoriDal;
        }

        public IActionResult Index()
        {

        }
    }
}
