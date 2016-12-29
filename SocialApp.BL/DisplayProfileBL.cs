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
        public List<DisplayProfileViewModel> GetUsers(int? id)
        {
            UserProfileRepository repo = new UserProfileRepository();
            var yourProfiles = repo.Get().Where(s => s.OrganizationID == id).ToList();
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
                viewModels.Add(viewModel);
            }
            return viewModels;
        }
    }
}
