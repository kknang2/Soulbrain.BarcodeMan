using PagedList;
using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IWebBarCodeRepository
    {
        IPagedList<WebBarCodeListItem> GetWebBarCodePagedList(WebBarCodeListFilter filter);

        bool DeleteWebBarCodes(IList<WebBarCodeID> ids);

        void SaveWebBarCodes(IList<WebBarCodeInput> inputs);
    }
}
