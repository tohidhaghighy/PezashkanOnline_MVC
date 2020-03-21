using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Notification;

namespace UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel
{
    public class NotificationDetail
    {
        public IEnumerable<Notification> AllNotifications { get; set; }
        public IEnumerable<NotificationUser> AllUsers { get; set; }
        public int Type { get; set; }
    }
}
