using Soulbrain.BarcodeMan.Helpers;
using Soulbrain.BarcodeMan.Resources;
using System;

namespace Soulbrain.BarcodeMan.Dtos.WebBarCode
{
    public class WebBarCodeListItem
    {
        public string PlantCode { get; set; }

        public string DocCode { get; set; }

        public string ProductCode { get; set; }

        public string VendorCode { get; set; }

        public string ProductNameKo { get; set; }

        public string ProductNameCh { get; set; }

        public string ProductNameEn { get; set; }

        public decimal? SupplyQty { get; set; }

        public decimal? PackingQty { get; set; }

        public string PackingUnitCode { get; set; }

        public string LotNo { get; set; }

        public string ProductDate { get; set; }

        public string ExpDateCode { get; set; }

        public string SupplyDate { get; set; }

        public int? PrintQty { get; set; }

        public DateTime? PrintDatetime { get; set; }

        public string PrintType { get; set; }

        public string PrintTypeString
        {
            get
            {
                if (PrintType.Equals(Enums.PrintType.StockTable))
                {
                    return Message.Text_StockTable;
                }

                return Message.Text_BarcodeLabel;
            }
        }

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

        public string PrintDateString
        {
            get
            {
                if (PrintDatetime.HasValue)
                {
                    //return PrintDatetime.Value.ToShortDateString();
                    return PrintDatetime.Value.ToString("yyyy-MM-dd");
                }

                return string.Empty;
            }
        }

        public string ProductDateString
        {
            get
            {
                if (!string.IsNullOrEmpty(ProductDate))
                {
                    //return ProductDate.Value.ToShortDateString();
                    return ProductDate;
                }

                return string.Empty;
            }
        }

        public string SupplyDateString
        {
            get
            {
                if (!string.IsNullOrEmpty(SupplyDate))
                {
                    //return SupplyDate.Value.ToShortDateString();
                    //return SupplyDate.Value.ToString("yyyy-MM-dd");
                    return SupplyDate;
                }

                return string.Empty;
            }
        }

        public string ExpiryDate
        {
            get
            {
                if (string.IsNullOrEmpty(ExpDateCode))
                    return string.Empty;

                return string.Format(Message.Text_ExpDateValue, ExpDateCode);
            }
        }

        public string FormattedPackingQty
        {
            get
            {
                if (PackingQty.HasValue)
                {
                    //return PackingQty.Value.ToString("G29");
                    return string.Format("{0:#,##0}", PackingQty.Value);
                }

                return string.Empty;
            }
        }

        public string FormattedSupplyQty
        {
            get
            {
                if (SupplyQty.HasValue)
                {
                    //return SupplyQty.Value.ToString("G29");
                    return string.Format("{0:#,##0}", SupplyQty.Value);
                }

                return string.Empty;
            }
        }
    }
}
