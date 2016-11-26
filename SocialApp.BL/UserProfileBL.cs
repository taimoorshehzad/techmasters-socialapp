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
            var fileName = Path.GetFileName(viewModel.ProfilePhoto.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/User/Profile/Images/"), fileName);           
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/Content/User/Profile/Images/"));
            viewModel.ProfilePhoto.SaveAs(path);
            user.OrganizationID = viewModel.SelectedOrganization;
            user.UserID = viewModel.UserID;
            user.FirstName = viewModel.FirstName;
            user.LastName = viewModel.LastName;
            user.Address = viewModel.Address;
            user.Gender = viewModel.Gender;
            user.Country = viewModel.Country;
            user.City = viewModel.City;
            user.PhoneNo = viewModel.MobileNO;
            user.DOB = viewModel.DOB;
            user.ProfilePicPath = fileName ;
            repo.Insert(user);
        }

        public ProfileViewModel GetProfileByUserAndOrganization(string userID, int? orgID)
        {
            UserProfileRepository repo = new UserProfileRepository();
            ProfileViewModel viewModel = new ProfileViewModel();
            var yourProfile = repo.Get().Where(s=> s.UserID == userID && s.OrganizationID == orgID).FirstOrDefault();

            var fileName = yourProfile.ProfilePicPath;
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/User/Profile/Images/"), fileName);
            
            viewModel.FirstName = yourProfile.FirstName;
            viewModel.LastName = yourProfile.LastName;
            viewModel.Address = yourProfile.Address;
            viewModel.Gender = yourProfile.Gender;
            viewModel.MobileNO = yourProfile.PhoneNo;
            viewModel.ProfilePicPath =yourProfile.ProfilePicPath;
            viewModel.DOB = yourProfile.DOB;
            viewModel.Country = yourProfile.Country;
            viewModel.City = yourProfile.City;
            return viewModel;
        }
    }
}
