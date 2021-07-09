using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Collections.Generic;

namespace Soulbrain.BarcodeMan.Dtos.WebNotice
{
    public class WebNoticeDetail
    {
        public string TitleKor { get; set; }

        public string TitleEng { get; set; }

        public string WriteID { get; set; }

        public DateTime? WriteDate { get; set; }

        public string NoticeType { get; set; }

        public string ContentsKor { get; set; }

        public string ContentsEng { get; set; }

        public ICollection<WebNoticeFile> Attachments { get; set; }

        public string Title
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(TitleEng))
                {
                    return TitleEng;
                }

                return TitleKor;
            }
        }

        public string Contents
        {
            get
            {
                if (CultureHelper.GetCurrentNeutralCulture().Equals("en") &&
                    !string.IsNullOrEmpty(TitleEng))
                {
                    return ContentsEng;
                }

                return ContentsKor;
            }
        }

        public string WriteDateString
        {
            get
            {
                if (WriteDate.HasValue)
                {
                    //return WriteDate.Value.Date.ToShortDateString();
                    return WriteDate.Value.Date.ToString("yyyy-MM-dd");
                }

                return string.Empty;
            }
        }

        public bool IsImportant
        {
            get
            {
                if (NoticeType.Equals("!"))
                    return true;

                return false;
            }
        }
    }
}
