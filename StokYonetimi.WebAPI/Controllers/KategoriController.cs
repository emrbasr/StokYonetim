﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entites;

namespace StokYonetimi.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriManager kategoriManager;

        public KategoriController(IKategoriManager kategoriManager)
        {
            this.kategoriManager = kategoriManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await kategoriManager.GetAllAsync();
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
            Kategori kategori = await kategoriManager.GetByIdAsync(id);
            if (kategori == null)
            {
                return NotFound(id);
            }
            else
            {
                return Ok(kategori);
            }
        }


        [HttpPost()]
        public async Task<int> KategoriEkle(Kategori kategori)
        {
            var sonuc = await kategoriManager.CreateAsync(kategori);
            if (sonuc > 0)
            {
                return StatusCodes.Status201Created;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }
        [HttpPut()]
        public async Task<int> KategoriGuncelle(Kategori kategori)
        {
            var sonuc = await kategoriManager.UpdateAsync(kategori);
            if (sonuc > 0)
            {
                return StatusCodes.Status202Accepted;
            }
            else
            {
                return StatusCodes.Status501NotImplemented;
            }
        }
        [HttpDelete()]
        public async Task<int> KategoriSil(Kategori kategori)
        {
            var sonuc = await kategoriManager.DeleteAsync(kategori);
            if (sonuc > 0)
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
