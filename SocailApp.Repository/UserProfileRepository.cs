using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class UserProfileRepository : IUserprofileRepository
    {
        private readonly SocialAppEntities _context;
        public UserProfileRepository()
        {
            _context = new SocialAppEntities();
        }

        public IEnumerable<UserProfile> Get()
        {
            return _context.UserProfiles.ToList();
        }

        //public int GetUserProfileById(int id)
        //{
        //    int profileCount = _context.UserProfiles.Where(w => w.OrganizationID == id).ToList().Count;
        //    return profileCount;
        //}

    }
}
