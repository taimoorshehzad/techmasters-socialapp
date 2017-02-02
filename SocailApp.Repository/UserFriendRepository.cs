using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class UserFriendRepository : IUserFriendRepository
    {
        private SocialAppEntities _dbContext;

        public UserFriendRepository()
        {
            _dbContext = new SocialAppEntities();
        }
        public IEnumerable<UserFriend> GetFriendsByUser(int userID, bool isRequestPending)
        {
            return _dbContext.UserFriends.Where(w => w.FriendID == userID && w.IsRequestPending == isRequestPending).ToList();
        }

        public void Save(UserFriend userFriend)
        {
            if (userFriend.UserFriendID > 0)
            {
                var oldRecord = _dbContext.UserFriends.Find(userFriend.UserFriendID);
                oldRecord.IsRequestPending = userFriend.IsRequestPending;
                _dbContext.UserFriends.Attach(oldRecord);
                _dbContext.Entry(oldRecord).State = EntityState.Modified;
            }
            else
            {
                _dbContext.UserFriends.Add(userFriend);
            }
            
            _dbContext.SaveChanges();
        }

        public void Delete(int friendRequestID)
        {
            _dbContext.UserFriends.Remove(_dbContext.UserFriends.Find(friendRequestID));
            _dbContext.SaveChanges();
        }

        public IEnumerable<UserFriend> GetFriendsByUser(int userID)
        {
            return _dbContext.UserFriends.Where(w => w.UserProfileID == userID).ToList();
        }
    }
}
