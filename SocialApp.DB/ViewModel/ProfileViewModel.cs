using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            Notifications = new List<ViewModel.NotificationViewModel>();
        }

        public string UserID { get; set; }
        public int UserProfileID { get; set; }
        public int? OrganizationID { get; set; }
        
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "DOB")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Profile Photo")]
        public string ProfilePicPath { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        public string MobileNO { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }

        public bool IsOwnProfile { get; set; }

        public string Age { get; set; }

        public bool IsFriendRequestSent { get; set; }
        public bool IsFriend { get; set; }
        public bool IsFriendRequestPending { get; set; }
        public List<NotificationViewModel> Notifications { get; set; }
    }
}
