﻿using Soulbrain.BarcodeMan.Helpers;
using Soulbrain.BarcodeMan.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace Soulbrain.BarcodeMan.Dtos.WebBoard
{
    public class WebBoardListItem
    {
        public string PlantCode { get; set; }

        public string DocCode { get; set; }

        public string TitleKor { get; set; }

        public string TitleEng { get; set; }

        public string WriteID { get; set; }

        public string WriteDate { get; set; }

        public string BoardType { get; set; }

        public bool HasAttachment { get; set; }

        public int Comments { get; set; }

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

        public string WriteDateString
        {
            get
            {
                if (!string.IsNullOrEmpty(WriteDate))
                {
                    //return WriteDate.Value.Date.ToShortDateString();
                    return WriteDate;
                }

                return string.Empty;
            }
        }

        public bool IsImportant
        {
            get
            {
                if (BoardType.Equals("!"))
                    return true;

                return false;
            }
        }
    }
}
