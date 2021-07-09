using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class WebBoardsCreator
    {
        private readonly AppDbContext _context;

        public WebBoardsCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var boards = new List<WebBoard>
            {
                new WebBoard {PlantCode = "1100", DocCode = "181019001", VendorCode="10000", BoardType = "!", TitleKor = @"솔브레인 바코드 발행 등록 시스템관련 공지사항입니다.", TitleEng="This is a notice about the registration system of Solbrain bar code issuance.", WriteID="hongkd", WriteDate=DateTime.Now.ToString("yyyy-MM-dd") },
                new WebBoard {PlantCode = "1100", DocCode = "181019003", VendorCode="10000", BoardType = "!", TitleKor = @"솔브레인 바코드 발행 등록 시스템관련 공지사항입니다.", TitleEng="This is a notice about the registration system of Solbrain bar code issuance.", WriteID="hongkd", WriteDate=DateTime.Now.ToString("yyyy-MM-dd") },
            };

            boards.ForEach(s => _context.WebBoards.AddOrUpdate(s));
            _context.SaveChanges();
        }
    }
}
