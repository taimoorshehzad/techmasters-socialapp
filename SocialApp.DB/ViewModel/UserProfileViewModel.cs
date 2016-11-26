using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace SocialApp.DB.ViewModel
{
    public class UserProfileViewModel
    {
        public string ProfilePhoto { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public DateTime DOB { get; set; }

        public string Address { get; set; }

        public string MobileNO { get; set; }

        public string Country { get; set; }

        public string  City { get; set; }

    }
}
