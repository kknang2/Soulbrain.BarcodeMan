using Soulbrain.BarcodeMan.Helpers;

namespace Soulbrain.BarcodeMan.Dtos.MaterialType
{
    public class MaterialTypeSelectItem
    {
        public string MaterialTypeCode { get; set; }

        public string MaterialTypeNameKo { get; set; }

        public string MaterialTypeNameCh { get; set; }

        public string MaterialTypeNameEn { get; set; }

        public string MaterialTypeName
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(MaterialTypeNameEn))
                {
                    return MaterialTypeNameEn;
                }

                return MaterialTypeNameKo;
            }
        }
    }
}
