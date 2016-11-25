using SocailApp.Repository;
using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web.Mvc;

namespace SocialApp.BL       
{
    public class OrganizationBL
    {
        public SelectList OrganizationDropdown()
        {
            IOrganizationRepository repository = new OrganizationRepository();
            var collection = repository.Get().Select(s => new
            {
                Name = s.Name,
                ID = s.OrganizationID
            }).ToList();
            return new SelectList(collection, "ID", "Name");
        }
    }
}
