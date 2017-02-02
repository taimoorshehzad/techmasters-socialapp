using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private SocialAppEntities _dbContext;

        public CommentRepository()
        {
            _dbContext = new SocialAppEntities();
        }

        public IEnumerable<Comment> GetCommentsByPost(int postID)
        {
            return _dbContext.Comments.Where(w => w.PostID == postID).ToList();
        }

        public void SavePostComment(Comment comment)
        {
            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();
        }
    }
}
