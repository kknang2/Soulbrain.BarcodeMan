using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Dtos.WebBarCode
{
    public class WebBarCodeListFilter : PagedResult
    {
        public string VendorCode { get; set; }

        public DateTime? ProductDateFrom { get; set; }

        public DateTime? ProductDateTo { get; set; }

        public string ProductName { get; set; }

        public string LotNo { get; set; }

        public string ProductDateFromString
        {
            get
            {
                if(ProductDateFrom.HasValue)
                {
                    //return ProductDateFrom.Value.ToShortDateString();
                    return ProductDateFrom.Value.ToString("yyyy-MM-dd");
                }

                return string.Empty;
            }
        }

        public string ProductDateToString
        {
            get
            {
                if (ProductDateTo.HasValue)
                {
                    //return ProductDateTo.Value.ToShortDateString();
                    return ProductDateTo.Value.ToString("yyyy-MM-dd");
                }

                return string.Empty;
            }
        }
    }
}
