using Soulbrain.BarcodeMan.Dtos.Product;
using System.Collections.Generic;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IProductRepository
    {
        IList<PopupProductListItem> GetPopupProducts(PopupProductListFilter filter);

        int GetPopupProductsTotalCount(PopupProductListFilter filter);
    }
}
