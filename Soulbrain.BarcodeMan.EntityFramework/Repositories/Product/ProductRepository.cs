using AutoMapper;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.Product;
using Soulbrain.BarcodeMan.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 자재정보
    /// </summary>
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        /// <summary>
        /// UseFlag="T" 레코드 조회
        /// </summary>
        public IQueryable<Product> ActiveEntities
        {
            get
            {
                return Entities.Where(p => p.UseFlag.Equals(StrBool.True));
            }
        }

        protected IQueryable<Product> GetPopupProductsQuery(PopupProductListFilter filter)
        {
            var query = ActiveEntities
                .Where(p => p.ProductVendors.Where(pv => pv.PrdVendorCode.Equals(filter.VendorCode)).FirstOrDefault() != null);

            if (!string.IsNullOrEmpty(filter.MaterialGroupCode))
            {
                query = query.Where(p => p.MaterialGroupCode.Equals(filter.MaterialGroupCode));
            }

            if (!string.IsNullOrEmpty(filter.MaterialTypeCode))
            {
                query = query.Where(p => p.MaterialTypeCode.Equals(filter.MaterialTypeCode));
            }

            if (!string.IsNullOrEmpty(filter.ProductCode))
            {
                query = query.Where(p => p.ProductCode.Contains(filter.ProductCode));
            }

            if (!string.IsNullOrEmpty(filter.ProductName))
            {
                query = query.Where(p => p.ProductName.Contains(filter.ProductName));
            }

            return query;
        }

        /// <summary>
        /// 제품정보검색
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<PopupProductListItem> GetPopupProducts(PopupProductListFilter filter)
        {
            var query = GetPopupProductsQuery(filter);

            IList<Product> products = query
                .OrderBy(p => p.ProductCode)
                .Skip(filter.Offset)
                .Take(AppConsts.DefaultPageSize)
                .ToList();

            return Mapper.Map<IList<PopupProductListItem>>(products);
        }

        /// <summary>
        /// 제품 총 개수
        /// </summary>
        public int GetPopupProductsTotalCount(PopupProductListFilter filter)
        {
            var query = GetPopupProductsQuery(filter);

            return query.Count();
        }
    }
}
