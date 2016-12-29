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
        public string MessageFrom { get; set; }
        public string MessageTo { get; set; }

        public int ThreadID { get; set; }
    }
}
