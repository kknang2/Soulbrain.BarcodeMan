using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

namespace Soulbrain.BarcodeMan.Migrations.SeedData
{
    public class WebNoticesCreator
    {
        private readonly AppDbContext _context;

        public WebNoticesCreator(AppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var notices = new List<WebNotice>
            {
                new WebNotice {PlantCode = "1100", DocCode = "181019001", NoticeType = "!", TitleKor = @"솔브레인 바코드 발행 등록 시스템관련 공지사항입니다.", TitleEng="This is a notice about the registration system of Solbrain bar code issuance.", WriteID="hongkd", WriteDate=DateTime.Now.ToString("yyyy-MM-dd") },
                new WebNotice {PlantCode = "1100", DocCode = "181019003", NoticeType = "A", TitleKor = @"솔브레인 바코드 발행 등록 시스템관련 공지사항입니다.", TitleEng="This is a notice about the registration system of Solbrain bar code issuance.", WriteID="hongkd", WriteDate=DateTime.Now.ToString("yyyy-MM-dd") },
            };

            notices.ForEach(s => _context.WebNotices.AddOrUpdate(s));

            var attachments = new List<WebNoticeFile>
            {
                new WebNoticeFile {PlantCode = "1100", DocCode = "181019003", Seq = 1, FileName = "File 1.txt", EtcDescKor = @"공지사항 파일 1", EtcDescEng = "Notice File 1"}
            };
            attachments.ForEach(s => _context.WebNoticeFiles.AddOrUpdate(s));

            _context.SaveChanges();
        }
    }
}
