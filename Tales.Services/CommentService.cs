using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Data.Repositories;
using Tales.Modal;


namespace Tales.Services
{
    public interface ICommentService
    {
        void CreateComment(Comment c);

        int GetCommentCount();
        void SaveChanges();

        void DenyComment(int commentId);

        void AllowComment(int commentId);
    }
    public class CommentService : ICommentService
    {
        private IUnitOfWork unitOfWork;
        private ICommentRepository commentRepository;
        private IPostRepository postRepository;
        public CommentService(IUnitOfWork unitOfWork, ICommentRepository commentRepository, IPostRepository post)
        {
            this.commentRepository = commentRepository;
            this.postRepository = post;
            this.unitOfWork = unitOfWork;

        }
        public void CreateComment(Comment c)
        {
            commentRepository.SaveComment(c);         
        }

        public void SaveChanges()
        {
            unitOfWork.Commit();
        }

        public void DenyComment(int commentId)
        {
            commentRepository.DenyComment(commentId);
        }

        public void AllowComment(int commentId)
        {
            commentRepository.AllowComment(commentId);
        }

        public int GetCommentCount()
        {
            int commentCount = 0;
            var comments = commentRepository.GetComments();
            if(comments.Any())
            {
                commentCount = comments.Where(a => a.IsValid == true).Count();
            }

            return commentCount;
        }
    }
}
