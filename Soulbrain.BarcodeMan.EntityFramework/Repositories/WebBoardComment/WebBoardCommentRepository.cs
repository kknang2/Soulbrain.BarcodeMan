using AutoMapper;
using Soulbrain.BarcodeMan.Domain;
using Soulbrain.BarcodeMan.Dtos.Comment;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soulbrain.BarcodeMan.Repositories
{
    /// <summary>
    /// 업무게시판 댓글
    /// </summary>
    public class WebBoardCommentRepository : BaseRepository<WebBoardComment>, IWebBoardCommentRepository
    {
        /// <summary>
        /// 업무게시판 댓글 삭제
        /// </summary>
        /// <param name="id"></param>
        public void DeleteComment(CommentKey id)
        {
            var entity = Entities
                    .Where(c => c.PlantCode.Equals(id.PlantCode))
                    .Where(c => c.DocCode.Equals(id.DocCode))
                    .Where(c => c.Seq.Equals(id.Seq))
                    .FirstOrDefault();

            Entities.Remove(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// 댓글 저장/변경
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public WebBoardComment SaveComment(CommentInput input)
        {
            if(input.Seq.HasValue)
            {
                var entity = Entities
                    .Where(c => c.PlantCode == input.PlantCode)
                    .Where(c => c.DocCode == input.DocCode)
                    .Where(c => c.Seq == input.Seq)
                    .FirstOrDefault();
                entity.Comment = input.Comment;
                Save(entity);
                return entity;
            }
            var newEntity = Mapper.Map<WebBoardComment>(input);
            var lastEntity = FindLastEntity(input);
            if(lastEntity == null)
            {
                newEntity.Seq = 1;
            }
            else
            {
                newEntity.Seq = lastEntity.Seq + 1;
            }
            newEntity.WriteID = AuditInfo.PersonID;
            newEntity.WriteDatetime = DateTime.Now;
            Entities.Add(newEntity);
            Save(newEntity);

            return newEntity;
        }

        /// <summary>
        /// Seq생성정보
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private WebBoardComment FindLastEntity(CommentInput input)
        {
            return Entities
                .Where(c => c.PlantCode.Equals(input.PlantCode))
                .Where(c => c.DocCode.Equals(input.DocCode))
                .OrderByDescending(c => c.Seq)
                .FirstOrDefault();
        }
    }
}
