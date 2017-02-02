using SocailApp.Repository;
using SocialApp.DB.Model;
using SocialApp.DB.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialApp.BL
{
    public class NotificationBL
    {
        INotificationRepository notificationRepository = new NotificationRepository();
        public List<NotificationViewModel> GetNotificationsByUser(int userProfileID)
        {
            return notificationRepository.GetByUserProfileID(userProfileID).Select(s => new NotificationViewModel()
            {
                Active = s.Active,
                Description = s.Description,
                Link = s.Link,
                NotificationID = s.NotificationID,
                UserProfileID = s.UserProfileID
            }).ToList();
        }

        public void SaveNotification(NotificationViewModel notificationVM)
        {
            Notification notification = new Notification();

            notification.Active = notificationVM.Active;
            notification.Description = notificationVM.Description;
            notification.Link = notificationVM.Link;
            notification.NotificationID = notificationVM.NotificationID;
            notification.UserProfileID = notificationVM.UserProfileID;

            notificationRepository.Save(notification);
        }
    }
}
