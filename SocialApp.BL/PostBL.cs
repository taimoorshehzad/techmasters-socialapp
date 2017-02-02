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
    public class PostBL
    {
        IPost postRepository = new PostRepository();
        IUserProfileRepository userProfileRepository = new UserProfileRepository();
        public void SavePost(PostViewModel postVM)
        {
            Post post = new Post();
           
            post.PostFrom = postVM.PostFromID;
            post.PostTo = postVM.PostToID;
            post.PostContent = postVM.PostContent;
            post.PostedOn = DateTime.Now;
            postRepository.Save(post);
        }

        public List<PostViewModel> GetPostsWithLikesAndComments(int postFrom)
        {
            return postRepository.GetPostsWithLikesAndComments(postFrom).Select(s => new PostViewModel()
            {
                Comments = s.Comments.Select(c => new CommentsVM()
                { CommentBy = c.CommentBy, CommentID = c.CommentID, PostID = c.PostID, Text = c.Text }).ToList(),
                Likes = s.Likes.Select(c => new LikesVM()
                { LikeBy = c.LikeBy, LikeID = c.LikeID, PostID = c.PostID }).ToList(),
                PostContent = s.PostContent,
                PostFromID = s.PostFrom,
                PostToID = s.PostTo,
                PostedOn = s.PostedOn,
                PostFromProfilePicPath = s.UserProfile.ProfilePicPath,
                PostToProfilePicPath = (s.UserProfile1 != null) ? s.UserProfile1.ProfilePicPath : "",
                PostID = s.PostID
            }).ToList();
        }
    }
}
