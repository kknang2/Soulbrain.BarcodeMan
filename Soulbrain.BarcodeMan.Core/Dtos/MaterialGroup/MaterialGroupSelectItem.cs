using Soulbrain.BarcodeMan.Helpers;

namespace Soulbrain.BarcodeMan.Dtos.MaterialGroup
{
    public class MaterialGroupSelectItem
    {
        public string MaterialGroupCode { get; set; }

        public string MaterialGroupNameKo { get; set; }

        public string MaterialGroupNameCh { get; set; }

        public string MaterialGroupNameEn { get; set; }

        public string MaterialGroupName
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(MaterialGroupNameEn))
                {
                    return MaterialGroupNameEn;
                }

                return MaterialGroupNameKo;
            }
        }
    }
}
