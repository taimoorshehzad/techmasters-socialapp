using SocialApp.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocailApp.Repository
{
    public interface IUserFriendRepository
    {
        IEnumerable<UserFriend> GetFriendsByUser(int userID, bool isRequestPending);
        IEnumerable<UserFriend> GetFriendsByUser(int userID);
        void Save(UserFriend friendRequest);
        void Delete(int requestID);
    }
}
