using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using Soulbrain.BarcodeMan.Repositories;
using System.Collections.Generic;

namespace Soulbrain.BarcodeMan.Test
{
    [TestClass]
    public class WebBoardTest
    {
        [TestMethod]
        public void GetRecentBoardList()
        {
            DtoMapperConfig.Configure();
            IWebBoardRepository repo = new WebBoardRepository();
            IList<WebBoardListItem> list = repo.GetRecentBoardList("10000");
            Assert.AreEqual(list.Count, 2);
        }
    }
}
