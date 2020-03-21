using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Notification;

namespace UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel
{
    public class NotificationMain
    {
        public int DoctorNotiCount { get; set; }
        public int UserNotiCount { get; set; }
        public int JudgeNotiCount { get; set; }
        public int PharmacyNotiCount { get; set; }
        public IEnumerable<Notification> AllNotifications { get; set; }
    }
}
