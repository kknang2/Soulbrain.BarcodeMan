using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    public interface IWebBoardCommentRepository
    {
        WebBoardComment SaveComment(CommentInput input);

        void DeleteComment(CommentKey id);
    }
}
