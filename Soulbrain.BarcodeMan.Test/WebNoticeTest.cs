using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soulbrain.BarcodeMan.Dtos.WebNotice;
using Soulbrain.BarcodeMan.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Test
{
    [TestClass]
    public class WebNoticeTest
    {
        [TestMethod]
        public void GetRecentNoticeList()
        {
            DtoMapperConfig.Configure();
            IWebNoticeRepository repo = new WebNoticeRepository();
            IList<WebNoticeListItem> list = repo.GetRecentNoticeList();
            Assert.AreEqual(list.Count, 2);
        }
    }
}
