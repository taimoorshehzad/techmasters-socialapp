using SocailApp.Repository;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.BL
{
    public class DashboardBL
    {
        public List<OrganizationUsersViewModel> DashboardStats() 
        {

            IUserProfileRepository userProfileRepository = new UserProfileRepository();
            IOrganizationRepository organizationRepository = new OrganizationRepository();

            List<OrganizationUsersViewModel> viewModelList = new List<OrganizationUsersViewModel>();

            var organizations = organizationRepository.Retrive();
            foreach (var item in organizations)
            {
                OrganizationUsersViewModel viewModel = new OrganizationUsersViewModel();
                viewModel.OrganizationID = item.OrganizationID;
                viewModel.OrganizationName = item.Name;
                viewModel.UsersCount = userProfileRepository.Get().Where(s => s.OrganizationID == item.OrganizationID).Count();

                viewModelList.Add(viewModel);
            }
            return viewModelList;
        }

    }
}
