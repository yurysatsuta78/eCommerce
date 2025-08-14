using Catalog.BLL.Services;

namespace Catalog.API.Extensions
{
    public static class GrpcServicesExtension
    {
        public static WebApplication MapGrpcServices(this WebApplication webApplication) 
        {
            webApplication.MapGrpcService<ProductsInfoService>();

            return webApplication;
        }
    }
}
