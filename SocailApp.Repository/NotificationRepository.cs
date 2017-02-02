using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialApp.DB.Model;

namespace SocailApp.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private SocialAppEntities _dbContext;

        public NotificationRepository()
        {
            _dbContext = new SocialAppEntities();
        }
        public IEnumerable<Notification> GetByUserProfileID(int userProfileID)
        {
            return _dbContext.Notifications.Where(w => w.UserProfileID == userProfileID).OrderByDescending(o=>o.NotificationID).ToList();
        }

        public void Save(Notification notification)
        {
            _dbContext.Notifications.Add(notification);
            _dbContext.SaveChanges();
        }
    }
}
