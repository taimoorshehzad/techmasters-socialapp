using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.ViewModel;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public interface IUserProfileRepository
    {
        void Insert(UserProfile user);
        List<UserProfile> Get();
    }
}
