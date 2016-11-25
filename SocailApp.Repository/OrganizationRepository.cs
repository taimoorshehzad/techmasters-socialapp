using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;
using System.Web.Mvc;

namespace SocailApp.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private SocialAppEntities _Context;

        public OrganizationRepository()
        {
            _Context = new SocialAppEntities();  
        }
        public IEnumerable<Organization> Get()
        {
            return _Context.Organizations.ToList();
        }
    }
}
