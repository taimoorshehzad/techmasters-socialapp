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

        public IEnumerable<UserProfile> Get()
        {
            return _context.UserProfiles.ToList();
        }

        public void Update(UserProfile user)
        {
            var profile = _context.UserProfiles.Where(s => s.UserID == user.UserID).FirstOrDefault();
            profile.OrganizationID = user.OrganizationID;
            profile.ProfilePicPath = user.ProfilePicPath;
            profile.FirstName = user.FirstName;
            profile.LastName = user.LastName;
            profile.DOB = user.DOB;
            profile.Address = user.Address;
            profile.Gender = user.Gender;
            profile.PhoneNo = user.PhoneNo;
            profile.CityID = user.CityID;
            _context.SaveChanges();
        }
    }
}
