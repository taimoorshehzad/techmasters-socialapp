using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class CommentsVM
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public int? CommentBy { get; set; }
        public int? PostID { get; set; }
        
        public string CommentByProfilePicPath { get; set; }

        public string NotificationFromFullName { get; set; }
        public int NotificationTo { get; set; }
    }
}
