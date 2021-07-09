using Soulbrain.BarcodeMan.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Soulbrain.BarcodeMan.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IVendorPRepository, VendorPRepository>();
            container.RegisterType<IWebBoardRepository, WebBoardRepository>();
            container.RegisterType<IWebNoticeRepository, WebNoticeRepository>();
            container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterType<IMaterialGroupRepository, MaterialGroupRepository>();
            container.RegisterType<IMaterialTypeRepository, MaterialTypeRepository>();
            container.RegisterType<IWebBarCodeRepository, WebBarCodeRepository>();
            container.RegisterType<IWebBoardCommentRepository, WebBoardCommentRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}