using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokYonetim.DAL.EFCore.Context;
using StokYonetim.Entites;
using StokYonetimi.WebAPI.Models;

namespace StokYonetimi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly StokYonetimDbContext dbContext;
        private readonly IConfiguration configuration;

        public LoginController(StokYonetimDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        /// <summary>
        /// Login icin Email ve Sifre Gerekli
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>

        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = await dbContext.Users
                                .Include(u => u.UserRoles)
                                .ThenInclude(p => p.Role)
                                .FirstOrDefaultAsync(p => p.Email == loginModel.Email && p.Password == loginModel.Password);
            if (user != null)
            {
                //Token Uretme asamasina gecelim.
                TokenHandler tokenHandler = new(configuration);
                Token token = tokenHandler.CreateAccessToken(user);

                //refresh toke'i User Tablosuna ekleyelim
                user.RefreshToken = token.RefreshToken;
                user.RefreshTokenEndTime = token.Expiration.AddMinutes(3);
                await dbContext.SaveChangesAsync();
                return Ok(token);
            }
            return NotFound();
        }


    }
}
