using StokYonetim.BL.Abstract;
using StokYonetim.BL.Concrete;
namespace StokYonetimi.WebAPI.Extention
{
    public static class StokYonetimExtension
    {

        public static IServiceCollection AddStokExtensions(this IServiceCollection services)
        {
            services.AddScoped<IKategoriManager, KategoriManager>();
            services.AddScoped<IStokManager, StokManager>();

            return services;
        }
    }
}
