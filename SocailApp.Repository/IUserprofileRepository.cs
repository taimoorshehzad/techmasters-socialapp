using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailApp.Repository
{
    public interface IUserProfileRepository
    {
        IEnumerable<UserProfile> Get();

        void Insert(UserProfile user);

    }
}
