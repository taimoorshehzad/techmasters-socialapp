using SocailApp.Repository;
using SocialApp.DB.Model;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.BL
{
    public class CommentBL
    {
        ICommentRepository commentRepository = new CommentRepository();

        public void SaveComment(CommentsVM commentVM)
        {
            Comment comment = new Comment();

            comment.CommentBy = commentVM.CommentBy;
            comment.PostID = commentVM.PostID;
            comment.Text = commentVM.Text;

            commentRepository.SavePostComment(comment);
        }

        public List<CommentsVM>GetCommentsByPostID(int postID)
        {
            return commentRepository.GetCommentsByPost(postID).Select(s => new CommentsVM()
            {
                CommentBy = s.CommentBy,
                CommentID = s.CommentID,
                PostID = s.PostID,
                Text = s.Text,
                CommentByProfilePicPath = s.UserProfile.ProfilePicPath
            }).ToList();
        }
    }
}
