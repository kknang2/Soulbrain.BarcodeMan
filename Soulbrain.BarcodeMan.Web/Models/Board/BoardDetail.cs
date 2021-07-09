using Soulbrain.BarcodeMan.Dtos.Comment;
using Soulbrain.BarcodeMan.Dtos.WebBoard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Soulbrain.BarcodeMan.Web.Models.Board
{
    public class BoardDetail
    {
        public WebBoardDetail WebBoardDetail { get; set; }

        public CommentInput CommentInput { get; set; }
    }
}