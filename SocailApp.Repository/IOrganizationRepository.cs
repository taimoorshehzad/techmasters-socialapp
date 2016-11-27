using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailApp.Repository
{
    public interface IOrganizationRepository
    {
        void Create(Organization Entity);
        IEnumerable<Organization> Retrive();
        void Update(Organization Entity);
        void Delete(int? id);

        Organization GetById(int? id);
    }
}
