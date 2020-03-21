using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Notification;

namespace UrumiumMVC.ServiceLayer.Contract.NotificationInterface
{
    public interface INotificationService
    {
        Task<bool> AddNotification(Notification notificationItem);
        Task<bool> DeleteNotification(int id);
        Task<List<Notification>> GetNotification();
        Task<List<Notification>> GetNotification(string userid, int type);
        Task<int> GetNotificationCount(int type);
        Task<IEnumerable<Notification>> GetNotificationList(int type);
    }
}
