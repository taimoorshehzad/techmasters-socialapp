using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class OrganzationRepository : IOrganizationRepository
    {
        private readonly SocialAppEntities _context;
        public OrganzationRepository()
        {
            _context = new SocialAppEntities();
        }
        public List<Organization> GetOrganization()
        {
            var oraganization = _context.Organizations.ToList();
            return oraganization;
        }
    }
}
