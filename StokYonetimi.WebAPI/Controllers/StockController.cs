using Microsoft.AspNetCore.Mvc;
using StokYonetim.DAL.Abstract;
using StokYonetim.Entites;

namespace StokYonetimi.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StokController : ControllerBase
    {
        private readonly IStokDal stokDal;

        public StokController(IStokDal stokDal)
        {
            this.stokDal = stokDal;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var result = await stokDal.GetAllAsync();
            if (result.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);

            }
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            Stok stok = await stokDal.GetByIdAsync(id);
            if (stok == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(stok);
            }
        }

        [HttpPost()]

        public async Task<int> StokEkle(Stok stok)
        {
            var sonuc = await stokDal.CreateAsync(stok);
            if (sonuc == 0)
            {
                return StatusCodes.Status201Created;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }

        [HttpPut()]

        public async Task<int> StokGuncelle(Stok stok)
        {
            var sonuc = await stokDal.UpdateAsync(stok);
            if (sonuc == 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }

        [HttpDelete()]

        public async Task<int> StokSil(Stok stok)
        {
            var sonuc = await stokDal.DeleteAsync(stok);
            if (sonuc == 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status204NoContent;
            }
        }


    }
}

