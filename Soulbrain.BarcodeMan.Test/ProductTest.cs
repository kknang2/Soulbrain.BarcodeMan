using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soulbrain.BarcodeMan.Repositories;
using Soulbrain.BarcodeMan.Dtos.Product;
using Soulbrain.BarcodeMan.Domain;

namespace Soulbrain.BarcodeMan.Test
{
    /// <summary>
    /// Summary description for ProductsTest
    /// </summary>
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void GetPopupProducts()
        {
            DtoMapperConfig.Configure();
            IProductRepository repo = new ProductRepository();
            IList<PopupProductListItem> list = repo.GetPopupProducts(new PopupProductListFilter
            {

            });
            Assert.IsTrue(list[0].ProductCode.Equals("40000001"));
        }
    }
}
