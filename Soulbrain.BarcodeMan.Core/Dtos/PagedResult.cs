using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Dtos
{
    public class PagedResult
    {
        public PagedResult()
        {
            PageNumber = 1;
            PageSize = AppConsts.DefaultPageSize;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string OrderBy { get; set; }
    }
}
