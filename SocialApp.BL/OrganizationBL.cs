using SocailApp.Repository;
using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SocialApp.BL       
{
    public class OrganizationBL
    {
        public IEnumerable<Organization> GetOrganizationsSelectList()
        {
            IOrganizationRepository repository = new OrganizationRepository();
            return repository.Get();
            //var collection = repository.Get().Select(s => new
            //{
            //    Name = s.Name,
            //    ID = s.OrganizationID
            //}).ToList();
            //return new SelectList(collection, "ID", "Name");
        }
    }
}
