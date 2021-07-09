using Soulbrain.BarcodeMan.Helpers;

namespace Soulbrain.BarcodeMan.Authenticate
{
    public class User
    {
        public string VendorCode { get; set; }

        public string VendorNameKo { get; set; }

        public string VendorNameEn { get; set; }

        public int Seq { get; set; }

        public string PersonID { get; set; }

        public string PersonName { get; set; }

        public string VendorName
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(VendorNameEn))
                {
                    return VendorNameEn;
                }

                return VendorNameKo;
            }
        }
    }
}
