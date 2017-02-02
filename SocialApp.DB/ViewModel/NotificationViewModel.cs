using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class NotificationViewModel
    {
        public int NotificationID { get; set; }
        public int? UserProfileID { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public bool? Active { get; set; }
    }
}
