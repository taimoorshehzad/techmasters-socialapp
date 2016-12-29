using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace SocialApp.DB.ViewModel
{
    public class EditUserProfileViewModel
    {
        public string UserID { get; set; }
        public int? OrganizationID { get; set; }

        [Display(Name = "Profile Photo")]
        public HttpPostedFileBase ProfilePhoto { get; set; }

        [Display(Name = "Profile Image")]
        public string ProfilePicPath { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "DOB")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "Mobile")]
        public string MobileNO { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int CountryID { get; set; }

        [Required]
        [Display(Name = "State")]
        public int StateID { get; set; }

        [Required]
        [Display(Name = "City")]
        public int CityID { get; set; }
    }
}
