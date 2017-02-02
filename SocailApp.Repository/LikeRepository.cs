using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class LikeRepository : ILikeRepository
    {
        private SocialAppEntities _dbContext;

        public LikeRepository()
        {
            _dbContext = new SocialAppEntities();
        }

        public void RemoveLike(int likeID)
        {
            _dbContext.Likes.Remove(_dbContext.Likes.Find(likeID));
            _dbContext.SaveChanges();
        }

        public bool SavePostLike(Like like)
        {
            bool isLikeAdded = false;
            if (_dbContext.Likes.Where(w => w.LikeBy == like.LikeBy && w.PostID == like.PostID).Count() == 0)
            {
                _dbContext.Likes.Add(like);
                _dbContext.SaveChanges();
                isLikeAdded = true;
            }

            return isLikeAdded;
        }
    }
}
