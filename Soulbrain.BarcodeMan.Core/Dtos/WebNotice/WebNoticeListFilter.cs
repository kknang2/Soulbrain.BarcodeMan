using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Dtos.WebNotice
{
    public class WebNoticeListFilter : PagedResult
    {
        public string Title { get; set; }
    }
}
