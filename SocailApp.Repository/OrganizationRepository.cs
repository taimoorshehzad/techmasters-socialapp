using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly SocialAppEntities _context;
        public OrganizationRepository()
        {
            _context = new SocialAppEntities();
        }
        public IEnumerable<Organization> Get()
        {
            var oraganization = _context.Organizations.ToList();
            return oraganization;
        }
    }
}