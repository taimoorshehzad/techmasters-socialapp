using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailApp.Repository
{
    public interface ICommentRepository
    {
        void SavePostComment(Comment comment);
        IEnumerable<Comment> GetCommentsByPost(int postID);
    }
}
