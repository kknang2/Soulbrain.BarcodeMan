using Soulbrain.BarcodeMan.Resources;
using System.ComponentModel.DataAnnotations;

namespace Soulbrain.BarcodeMan.Dtos.Product
{
    public class PopupProductListFilter
    {

        [Display(Name = "Product_MaterialGroup", ResourceType = typeof(Message))]
        public string MaterialGroupCode { get; set; }

        [Display(Name = "Product_MaterialType", ResourceType = typeof(Message))]
        public string MaterialTypeCode { get; set; }

        [Display(Name = "Product_ItemCode", ResourceType = typeof(Message))]
        public string ProductCode { get; set; }

        [Display(Name = "Product_ItemName", ResourceType = typeof(Message))]
        public string ProductName { get; set; }

        public string VendorCode { get; set; }

        public int Offset { get; set; }
    }
}
