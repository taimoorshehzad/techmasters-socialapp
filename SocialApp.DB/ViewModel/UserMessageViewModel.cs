using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
   public class UserMessageViewModel
    {
        public string Message { get; set; }
        public int MessageFrom { get; set; }
        public int MessageTo { get; set; }

        public int ThreadID { get; set; }
    }
}
