using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StokYonetim.BL.Abstract;
using StokYonetim.Entites;
using System.Net;

namespace StokYonetimi.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StokController : ControllerBase
    {
        private readonly IStokManager stokManager;
        private readonly IValidator<Stok> validator;

        public StokController(IStokManager stokManager, IValidator<Stok> validator)
        {
            this.stokManager = stokManager;
            this.validator = validator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await stokManager.GetAllAsync();
            if (result == null)
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
            var result = await stokManager.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost()]
        public async Task<int> CreateStok(Stok stok)
        {
            ValidationResult valresult = await validator.ValidateAsync(stok);

            if (!valresult.IsValid)
            {

            }


            var result = await stokManager.CreateAsync(stok);
            if (result == null)
            {
                return (int)HttpStatusCode.NotFound;
            }
            else if (result == 0)
            {
                return (int)HttpStatusCode.NotImplemented;
            }
            return (int)HttpStatusCode.OK;
        }
    }
}

