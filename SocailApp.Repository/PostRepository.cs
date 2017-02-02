using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailApp.Repository
{

    public class PostRepository : IPost
    {
        private SocialAppEntities _dbContext;

        public PostRepository()
        {
            _dbContext = new SocialAppEntities();
        }

        public IEnumerable<Post> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPostsWithLikesAndComments(int postFrom)
        {
            return _dbContext.Posts
                .Where(s => s.PostFrom == postFrom || s.PostTo == postFrom)
                .OrderByDescending(o => o.PostedOn).ToList();
        }

        public void Save(Post postObj)
        {
            _dbContext.Posts.Add(postObj);
            _dbContext.SaveChanges();
        }
    }
}
