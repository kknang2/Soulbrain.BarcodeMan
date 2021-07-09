using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soulbrain.BarcodeMan.Authenticate;
using Soulbrain.BarcodeMan.Repositories;

namespace Soulbrain.BarcodeMan.Test
{
    [TestClass]
    public class VendorPTest
    {
        [TestMethod]
        public void GetUserByCredentials()
        {
            DtoMapperConfig.Configure();
            IVendorPRepository repo = new VendorPRepository();
            User user = repo.GetUserByCredentials("leeys", "123qwe");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void ChangePassword()
        {
            IVendorPRepository repo = new VendorPRepository();
            var ret = repo.ChangePassword("leeys", "123123");
            Assert.AreEqual(ret, true);
        }
    }
}
