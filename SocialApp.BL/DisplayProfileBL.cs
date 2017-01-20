using SocailApp.Repository;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.BL
{
    public class DisplayProfileBL
    {
        public List<DisplayProfileViewModel> GetUsers()
        {
            UserProfileRepository repo = new UserProfileRepository();
            var yourProfiles = repo.Get();
            return (users(yourProfiles));
        }
        public List<DisplayProfileViewModel> GetUsersByOrganization(int? organizationID)
        {
            UserProfileRepository repo = new UserProfileRepository();
            var yourProfiles = repo.Get().Where(s => s.OrganizationID == organizationID).ToList();
            return (users(yourProfiles));

        }
        private List<DisplayProfileViewModel> users(IEnumerable<DB.Model.UserProfile> yourProfiles)
        {
            List<DisplayProfileViewModel> viewModels = new List<DisplayProfileViewModel>();
            foreach (var yourProfile in yourProfiles)
            {
                DisplayProfileViewModel viewModel = new DisplayProfileViewModel();
                viewModel.FirstName = yourProfile.FirstName;
                viewModel.LastName = yourProfile.LastName;
                viewModel.Gender = yourProfile.Gender;
                viewModel.DOB = yourProfile.DOB;
                viewModel.Address = yourProfile.Address;
                viewModel.PhoneNo = yourProfile.PhoneNo;
                viewModel.Country = yourProfile.City1.State.Country.CoutnryName;
                viewModel.City = yourProfile.City1.CityName;
                viewModel.UserID = yourProfile.UserID;
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
