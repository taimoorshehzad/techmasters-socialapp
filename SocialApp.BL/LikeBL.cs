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
    public class LikeBL
    {
        ILikeRepository likeRepository = new LikeRepository();

        public bool SaveLike(LikesVM likeVM)
        {
            Like like = new Like();

            like.LikeBy = likeVM.LikeBy;
            like.PostID = likeVM.PostID;

            return likeRepository.SavePostLike(like);
        }

        public void RemoveLike(int likeID)
        {
            likeRepository.RemoveLike(likeID);
        }
    }
}
