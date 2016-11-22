using SocailApp.Repository;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Organization()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrganization(AddOrganizationViewModel viewModel)
        {
            return RedirectToAction("Organization");
        }
      
        public ActionResult Dashboard()
        {
            IUserprofileRepository userProfileRepository = new UserProfileRepository();
            IOrganizationRepository organizationRepository = new OrganzationRepository();

            List<OrganizationUsersViewModel> viewModelList = new List<OrganizationUsersViewModel>();

            var organizations = organizationRepository.GetOrganization();
            foreach (var item in organizations)
            {
                OrganizationUsersViewModel viewModel = new OrganizationUsersViewModel();
                viewModel.OrganizationID = item.OrganizationID;
                viewModel.OrganizationName = item.Name;
                viewModel.UsersCount = userProfileRepository.Get().Where(s=> s.OrganizationID == item.OrganizationID).Count() ;

                viewModelList.Add(viewModel);

            }
             return View(viewModelList);
        }
    }
}