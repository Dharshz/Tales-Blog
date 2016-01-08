using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tales.Data.Infrastructure;
using Tales.Model;

namespace Tales.Data.Repositories
{
    public interface ICommentRepository
    {
        void SaveComment(Comment c);

        void DenyComment(int commentId);

        void AllowComment(int commentId);

        IEnumerable<Comment> GetComments();
    }
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IDbFactory factory):base(factory)
        {
            
                
        }

        public void AllowComment(int commentId)
        {
            Comment comment = DbContext.Comments.Where(a => a.CommentId == commentId).SingleOrDefault();
            if (comment != null)
            {
                comment.IsModerated = true;
                comment.IsValid = true;
            }
        }

        public void DenyComment(int commentId)
        {
            Comment comment = DbContext.Comments.Where(a => a.CommentId == commentId).SingleOrDefault();
            if (comment != null)
            {
                comment.IsModerated = true;
                comment.IsValid = false;
            }
        }

        public IEnumerable<Comment> GetComments()
        {
            return GetAll();
        }

       

        public void SaveComment(Comment c)
        {
            if(c.Post == null)
            {
                c.Post = DbContext.Posts.Single(a => a.PostId == c.PostId);

                c.Post.Comments.Add(c);

              
            }
           
        }
    }
}
