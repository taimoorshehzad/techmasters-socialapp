using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace SocailApp.Repository
{
    public interface IOrganizationRepository
    {
         IEnumerable<Organization> Get();
    }
}
