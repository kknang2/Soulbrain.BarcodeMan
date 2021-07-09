using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Dtos.WebBoard
{
    public class WebBoardListFilter : PagedResult
    {
        public string Title { get; set; }

        public string VendorCode { get; set; }
    }
}
