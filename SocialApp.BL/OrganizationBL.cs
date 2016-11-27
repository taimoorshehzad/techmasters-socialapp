using SocailApp.Repository;
using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using System.IO;
using SocialApp.DB.ViewModel;

namespace SocialApp.BL       
{
    public class OrganizationBL
    {
        private IOrganizationRepository repository;

        public OrganizationBL()
        {
            repository = new OrganizationRepository();
        }

        public IEnumerable<Organization> OrganizationList()
        {

            IEnumerable<Organization> organizationList = repository.Retrive();
            return organizationList;
        }

        public String CreateOrganization(AddOrganizationViewModel OrganizationViewModel, HttpPostedFileBase LogoPath)
        {
            String path = "";
            if (LogoPath != null)
            {
                //validate image
                if (ValidateImage(LogoPath))
                {
                    //Save image
                    path = SaveImage(LogoPath);
                }
            }
            Organization org = new Organization();
            org.Name = OrganizationViewModel.Name;
            org.LogoPath = Path.GetFileName(path);
            org.CreatedOn = DateTime.Now;
            repository.Create(org);
            return "Organization Created";
        }

        public EditOrganizationViewModel GetEditOrganization(int? id)
        {
            //PENDING => display image 
            var org = repository.GetById(id);
            var vmorg = new EditOrganizationViewModel();
            vmorg.OrganizationID = org.OrganizationID;
            vmorg.Name = org.Name;
            vmorg.LogoPath = org.LogoPath;
            return vmorg;
        }

        public String EditOrganization(EditOrganizationViewModel organizationViewModel, HttpPostedFileBase LogoPath)
        {

            String path = "";
            if (LogoPath != null)
            {
                //validate image
                if (ValidateImage(LogoPath))
                {
                    //deleting image
                    DeleteLogoImage(organizationViewModel.OrganizationID);
                    //Save image
                    path = SaveImage(LogoPath);
                }
            }
            Organization org = new Organization();
            org.OrganizationID = organizationViewModel.OrganizationID;
            org.Name = organizationViewModel.Name;
            org.LogoPath = Path.GetFileName(path);
            org.CreatedOn = DateTime.Now;
            repository.Update(org);
            return "Organization Edited";
        }

        public String DeleteOrganization(int? id)
        {
            if (DeleteLogoImage(id))
            {
                repository.Delete(id);
                return "Organization Deleted";
            }
            else
                return "Something went wrong please try again...";
        }

        private bool ValidateImage(HttpPostedFileBase file)
        {
            //if (file != null)
            //{
            String format = Path.GetExtension(file.FileName).ToString();
            String[] allowedFormat = new String[4] { ".jpg", ".png", ".gif", ".bmp" };
            int maxSize = 1048576;
            int minSize = 30584;

            if (file.ContentLength < maxSize && file.ContentLength > minSize)
            {
                if (allowedFormat.Contains(format))
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            //}
            //else
            //    return false;
        }

        private String SaveImage(HttpPostedFileBase file)
        {
            String extension = Path.GetExtension(file.FileName).ToString();
            String path = HttpContext.Current.Server.MapPath("~/Content/organization/logo/");
            String name = "";

            //Generating unique name for image
            string guid = Guid.NewGuid().ToString();
            name = guid + extension;
            //Generating Path to Save Image at Server
            String fullPath = Path.Combine(path, name);
            //Checking if directory exist
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //Saving Image
            file.SaveAs(fullPath);

            return fullPath;
        }

        private bool DeleteLogoImage(int? id)
        {
            Organization temp = repository.GetById(id);
            String relativePath = "~/Content/organization/logo/" + temp.LogoPath.ToString();
            String absolutePath = HttpContext.Current.Server.MapPath(relativePath);
            if (File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }
            return true;
        }

    }
}
