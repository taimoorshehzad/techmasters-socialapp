using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public interface IPost
    {
        IEnumerable<Post> Get();
        void Save(Post postObj);

        IEnumerable<Post> GetPostsWithLikesAndComments(int postFrom);
    }
}
