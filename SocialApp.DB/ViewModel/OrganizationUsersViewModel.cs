using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.DB.ViewModel
{
    public class OrganizationUsersViewModel
    {
        public string OrganizationName { get; set; }
        public int OrganizationID { get; set; }

        public int UsersCount { get; set; }
    }
}
