using AutoMapper;
using PagedList;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.WebBarCode;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 협력사 바코드 발행정보
    /// </summary>
    public class WebBarCodeRepository : BaseRepository<WebBarCode>, IWebBarCodeRepository
    {
        /// <summary>
        /// 바코드발행이력 삭제
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool DeleteWebBarCodes(IList<WebBarCodeID> ids)
        {
            foreach (var id in ids)
            {
                var entity = Entities.Where(b => b.PlantCode.Equals(id.PlantCode) && b.DocCode.Equals(id.DocCode)).FirstOrDefault();
                if (entity != null)
                    Entities.Remove(entity);
            }

            return _context.SaveChanges() > 0;
        }

        /// <summary>
        /// 바코드발행이력 페이지별 정보
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IPagedList<WebBarCodeListItem> GetWebBarCodePagedList(WebBarCodeListFilter filter)
        {
            var query = Entities
                .Where(b => b.Product.ProductVendors.Select(vp => vp.PrdVendorCode.Equals(filter.VendorCode)).FirstOrDefault() != false)
                .Where(b =>
                        string.IsNullOrEmpty(filter.ProductName) ||
                        b.Product.ProductName.Contains(filter.ProductName) ||
                        b.Product.ProductNameCh.Contains(filter.ProductName) ||
                        b.Product.ProductNameEn.Contains(filter.ProductName)
                    )
                .Where(b =>
                        string.IsNullOrEmpty(filter.LotNo) ||
                        b.LotNo.Contains(filter.LotNo)
                    )
                .Where(b =>
                        !filter.ProductDateFrom.HasValue ||
                        b.ProductDate.CompareTo(filter.ProductDateFromString) >= 0
                    )
                .Where(b =>
                        !filter.ProductDateTo.HasValue ||
                        b.ProductDate.CompareTo(filter.ProductDateToString) <= 0
                    )
                ;

            switch (filter.OrderBy)
            {
                case "PrintDatetime":
                    query = query.OrderBy(b => b.PrintDatetime);
                    break;
                case "-PrintDatetime":
                    query = query.OrderByDescending(b => b.PrintDatetime);
                    break;
                case "PrintType":
                    query = query.OrderBy(b => b.PrintType);
                    break;
                case "-PrintType":
                    query = query.OrderByDescending(b => b.PrintType);
                    break;
                case "ProductName":
                    query = query.OrderBy(b => b.Product.ProductName);
                    break;
                case "-ProductName":
                    query = query.OrderByDescending(b => b.Product.ProductName);
                    break;
                case "SupplyQty":
                    query = query.OrderBy(b => b.SupplyQty);
                    break;
                case "-SupplyQty":
                    query = query.OrderByDescending(b => b.SupplyQty);
                    break;
                case "PackingQty":
                    query = query.OrderBy(b => b.Product.ProductVendors.FirstOrDefault().PackingQty);
                    break;
                case "-PackingQty":
                    query = query.OrderByDescending(b => b.Product.ProductVendors.FirstOrDefault().PackingQty);
                    break;
                case "PackingUnitCode":
                    query = query.OrderBy(b => b.PackingUnitCode);
                    break;
                case "-PackingUnitCode":
                    query = query.OrderByDescending(b => b.PackingUnitCode);
                    break;
                case "LotNo":
                    query = query.OrderBy(b => b.LotNo);
                    break;
                case "-LotNo":
                    query = query.OrderByDescending(b => b.LotNo);
                    break;
                case "ProductDate":
                    query = query.OrderBy(b => b.ProductDate);
                    break;
                case "-ProductDate":
                    query = query.OrderByDescending(b => b.ProductDate);
                    break;
                case "ExpDateCode":
                    query = query.OrderBy(b => b.ExpDateCode);
                    break;
                case "-ExpDateCode":
                    query = query.OrderByDescending(b => b.ExpDateCode);
                    break;
                case "SupplyDate":
                    query = query.OrderBy(b => b.SupplyDate);
                    break;
                case "-SupplyDate":
                    query = query.OrderByDescending(b => b.SupplyDate);
                    break;
                case "PrintQty":
                    query = query.OrderBy(b => b.PrintQty);
                    break;
                case "-PrintQty":
                    query = query.OrderByDescending(b => b.PrintQty);
                    break;
                default:
                    query = query.OrderByDescending(b => b.CreateDate);
                    break;
            }

            return query.Select(b => new WebBarCodeListItem()
            {
                PlantCode = b.PlantCode,
                DocCode = b.DocCode,
                VendorCode = b.Product.ProductVendors.FirstOrDefault().PrdVendorCode,
                ProductCode = b.ProductCode,
                ProductNameKo = b.Product.ProductName,
                ProductNameEn = b.Product.ProductNameEn,
                ProductNameCh = b.Product.ProductNameCh,
                LotNo = b.LotNo,
                ExpDateCode = b.ExpDateCode,
                PackingUnitCode = b.PackingUnitCode,
                PackingQty = b.Product.ProductVendors.FirstOrDefault().PackingQty,
                ProductDate = b.ProductDate,
                SupplyDate = b.SupplyDate,
                SupplyQty = b.SupplyQty,
                PrintDatetime = b.PrintDatetime,
                PrintType = b.PrintType,
                PrintQty = b.PrintQty
            }).ToPagedList(filter.PageNumber, filter.PageSize);
        }

        /// <summary>
        /// 바코드발행등록 저장
        /// </summary>
        /// <param name="inputs"></param>
        public void SaveWebBarCodes(IList<WebBarCodeInput> inputs)
        {
            foreach (var input in inputs)
            {
                var entity = Mapper.Map<WebBarCode>(input);
                entity.PrintDatetime = DateTime.Now;
                entity.PlantCode = AppConsts.DefaultPlantCode;

                var lastEntity = FindLastEntity();
                if (lastEntity == null)
                {
                    entity.DocCode = DocCodeHelper.GetNextDocCode();
                }
                else
                {
                    entity.DocCode = DocCodeHelper.GetNextDocCode(lastEntity.DocCode);
                }

                Save(entity);
            }
        }

        /// <summary>
        /// DocCode생성을 위한 정보
        /// </summary>
        /// <returns></returns>
        private WebBarCode FindLastEntity()
        {
            return Entities.OrderByDescending(b => b.CreateDate).OrderByDescending(b => b.DocCode).FirstOrDefault();
        }
    }
}
