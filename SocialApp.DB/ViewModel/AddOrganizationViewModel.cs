using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class AddOrganizationViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "No more than 50 characters.", MinimumLength = 1)]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }
    }
}
