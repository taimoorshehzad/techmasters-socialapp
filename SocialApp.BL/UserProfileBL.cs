using SocailApp.Repository;
using SocialApp.DB.Model;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
namespace SocialApp.BL
{
    public class UserProfileBL
    {
        public void UserProfileInsert(UserProfileViewModel viewModel)
        {
            IUserProfileRepository repo = new UserProfileRepository();

            UserProfile user = new UserProfile();

            var fileName = Path.GetFileNameWithoutExtension(viewModel.ProfilePhoto.FileName);
            fileName += DateTime.Now.Ticks + Path.GetExtension(viewModel.ProfilePhoto.FileName);
            var basePath = "~/Content/Users/" + viewModel.UserID + "/Profile/Images/";
            var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);           
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/"+ viewModel.UserID +"/Profile/Images/"));
            viewModel.ProfilePhoto.SaveAs(path);
            
            user.OrganizationID = viewModel.SelectedOrganization;
            user.UserID = viewModel.UserID;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Address = viewModel.Address;
            user.Gender = viewModel.Gender;
            user.CityID = viewModel.CityID;
            user.PhoneNo = viewModel.MobileNO;
            user.DOB = viewModel.DOB;
            user.ProfilePicPath = basePath + fileName;
            user.ProfileCompeted = true;
            repo.Insert(user);
        }

        public IEnumerable<Country> GetCountries()
        {
            ICountryRepository countryRepo = new CountryRepository();
            return countryRepo.Get();
        }
        public ProfileViewModel GetProfileByUserID(string userID)
        {
            UserProfileRepository repo = new UserProfileRepository();
            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

            ProfileViewModel viewModel = new ProfileViewModel();

            var yourProfile = repo.Get().Where(s=> s.UserID == userID).FirstOrDefault();
            if (yourProfile != null)
            {
                var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
                var state = stateRepo.Get().Where(s => s.StateID == city.StateID).FirstOrDefault();
                var country = countryRepo.Get().Where(s => s.CountryID == state.CountryID).FirstOrDefault();

                viewModel.UserID = userID;
                viewModel.OrganizationID = yourProfile.OrganizationID;
                viewModel.FirstName = yourProfile.FirstName;
                viewModel.LastName = yourProfile.LastName;
                viewModel.Address = yourProfile.Address;
                viewModel.Gender = yourProfile.Gender;
                viewModel.MobileNO = yourProfile.PhoneNo;
                viewModel.ProfilePicPath = yourProfile.ProfilePicPath;
                viewModel.DOB = yourProfile.DOB;
                viewModel.City = city.CityName;
                viewModel.State = state.StateName;
                viewModel.Country = country.CoutnryName;
            }
            return viewModel;
        }

        public EditUserProfileViewModel EditUserProfile(string userID , int? orgID )
        {
            IUserProfileRepository profileRepo = new UserProfileRepository();
            ICountryRepository countryRepo = new CountryRepository();
            IStateRepository stateRepo = new StateRepository();
            ICityRepository cityRepo = new CityRepository();

            var yourProfile = profileRepo.Get().Where(s => s.UserID == userID && s.OrganizationID == orgID).FirstOrDefault();
            //var city = cityRepo.Get().Where(s => s.CityID == yourProfile.CityID).FirstOrDefault();
            //var state = stateRepo.Get().Where(s => s.StateID == city.StateID).FirstOrDefault();
            //var country = countryRepo.Get().Where(s => s.CountryID == state.CountryID).FirstOrDefault();

            EditUserProfileViewModel viewModel = new EditUserProfileViewModel();
            viewModel.UserID = userID;
            viewModel.OrganizationID = orgID;
            viewModel.FirstName = yourProfile.FirstName;
            viewModel.LastName = yourProfile.LastName;
            viewModel.Address = yourProfile.Address;
            viewModel.Gender = yourProfile.Gender;
            viewModel.MobileNO = yourProfile.PhoneNo;
            viewModel.ProfilePicPath = yourProfile.ProfilePicPath;
            viewModel.DOB = yourProfile.DOB;
            //viewModel.City = city.CityName;
            //viewModel.State = state.StateName;
            //viewModel.Country = country.CoutnryName;
            return viewModel;
        }

        public void InsertEditedUserProfile(EditUserProfileViewModel viewModel)
        {
            IUserProfileRepository repo = new UserProfileRepository();

            UserProfile user = new UserProfile();
            
            if (viewModel.ProfilePhoto != null)
            {
                var fileName = Path.GetFileNameWithoutExtension(viewModel.ProfilePhoto.FileName);
                fileName += DateTime.Now.Ticks + Path.GetExtension(viewModel.ProfilePhoto.FileName);
                var basePath = "~/Content/Users/" + viewModel.UserID + "/Profile/Images/";
                var path = Path.Combine(HttpContext.Current.Server.MapPath(basePath), fileName);
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/Users/" + viewModel.UserID + "/Profile/Images/"));
                viewModel.ProfilePhoto.SaveAs(path);

                user.ProfilePicPath = basePath + fileName;
            }
            else
            {
                user.ProfilePicPath = viewModel.ProfilePicPath;
            }

            user.OrganizationID = viewModel.OrganizationID;
            user.UserID = viewModel.UserID;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Address = viewModel.Address;
            user.Gender = viewModel.Gender;
            user.CityID = viewModel.CityID;
            user.PhoneNo = viewModel.MobileNO;
            user.DOB = viewModel.DOB;
            repo.Update(user);
        }
        public IEnumerable<State> GetStatesByCountryId(int id)
        {
            IStateRepository stateRepo =  new StateRepository();
            return stateRepo.Get().Where(s=> s.CountryID == id).ToList(); 
        }

        public IEnumerable<City> GetCitiesByStateId(int id)
        {
            ICityRepository cityRepo = new CityRepository();
            return cityRepo.Get().Where(s => s.StateID == id).ToList();
        }

        public bool? IsProfilecompleted(string userID)
        {
            IUserProfileRepository profileRepo = new UserProfileRepository();
            var profile = profileRepo.Get().Where(s => s.UserID == userID);
            return profile.Select(s=>s.ProfileCompeted).FirstOrDefault();   
        }
    }
}
