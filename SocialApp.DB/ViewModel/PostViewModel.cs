using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            Likes = new List<LikesVM>();
            Comments = new List<CommentsVM>();
        }

        public int PostID { get; set; }

        public int? PostToID { get; set; }
        public int? PostFromID { get; set; }
        public string PostContent { get; set; }
        public DateTime? PostedOn { get; set; }
        public List<LikesVM> Likes { get; set; }
        public List<CommentsVM> Comments { get; set; }

        public string PostFromProfilePicPath { get; set; }
        public string PostToProfilePicPath { get; set; }
    }
}
