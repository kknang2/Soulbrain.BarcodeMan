using Soulbrain.BarcodeMan.Helpers;

namespace Soulbrain.BarcodeMan.Dtos.Product
{
    public class PopupProductListItem
    {
        public string PlantCode { get; set; }

        public string ProductCode { get; set; }

        public string VendorCode { get; set; }

        public string ProductNameKo { get; set; }

        public string ProductNameCh { get; set; }

        public string ProductNameEn { get; set; }

        public decimal PackingQty { get; set; }

        public string PackingUnitCode { get; set; }

        public string ProdQtyPerProduct { get; set; }

        public string ProductName
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(ProductNameEn))
                {
                    return ProductNameEn;
                }

                return ProductNameKo;
            }
        }
    }
}
