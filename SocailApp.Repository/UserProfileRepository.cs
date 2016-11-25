using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.ViewModel;
using SocailApp.Repository;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private SocialAppEntities _context;
        public UserProfileRepository()
        {
            _context = new SocialAppEntities();
        }
        public void Insert(UserProfile user)
        {
            _context.UserProfiles.Add(user);
            _context.SaveChanges();
        }
        public List<UserProfile> Get()
        {
            return _context.UserProfiles.ToList();
        }
    }
}
