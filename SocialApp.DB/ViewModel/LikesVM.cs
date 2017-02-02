using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class LikesVM
    {
        public int LikeID { get; set; }
        public int? LikeBy { get; set; }

        public int? PostID { get; set; }

        public string NotificationFromFullName { get; set; }
        public int NotificationTo { get; set; }
    }
}
