using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Soulbrain.BarcodeMan.Dtos.Product;
using Soulbrain.BarcodeMan.Repositories;
using Soulbrain.BarcodeMan.Web.Filters;
using System.Web.Mvc;

namespace Soulbrain.BarcodeMan.Web.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductRepository _productRepo;

        public ProductController(
            IProductRepository productRepo
            )
        {
            _productRepo = productRepo;
        }

        /// <summary>
        /// 팝업제품목록
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [CheckIfAuthenticated]
        public ContentResult PopupList(PopupProductListFilter filter)
        {
            if (filter == null)
            {
                filter = new PopupProductListFilter();
            }
            filter.VendorCode = _authProvider.User.VendorCode;

            var products = _productRepo.GetPopupProducts(filter);
            var totalCount = _productRepo.GetPopupProductsTotalCount(filter);

            string json = JsonConvert.SerializeObject(
                new
                {
                    items = products,
                    totalCount
                },
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            );
            return Content(json, "application/json");
        }
    }
}