using Catalog.BLL.Services.gRPC;

namespace Catalog.API.Extensions
{
    public static class GrpcServicesExtension
    {
        public static WebApplication MapGrpcServices(this WebApplication webApplication) 
        {
            webApplication.MapGrpcService<CatalogItemsInfoService>();

            return webApplication;
        }
    }
}
