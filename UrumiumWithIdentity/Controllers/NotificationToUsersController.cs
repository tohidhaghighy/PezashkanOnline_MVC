using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.DomainClasses.Entities.Notification;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ServiceLayer.Contract.NotificationInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class NotificationToUsersController : Controller
    {

        INotificationService _notificationservices;
        IIllnessService _illnessservice;
        IDoctorService _doctorservice;
        IJudgeService _judgeservice;
        IPharmacyService _pharmacyservice;
        readonly IUnitOfWork _uow;

        public NotificationToUsersController(INotificationService notificationservice, IDoctorService doctorservice, IJudgeService judgeservice, IIllnessService illnessservice, IPharmacyService pharmacyservice,
            IUnitOfWork uow)
        {
            _notificationservices = notificationservice;
            _illnessservice = illnessservice;
            _doctorservice = doctorservice;
            _judgeservice = judgeservice;
            _pharmacyservice = pharmacyservice;
            _uow = uow;
        }
        // GET: NotificationToUsers
        public virtual async Task<ActionResult> Index()
        {
            var MainInfo = new NotificationMain();
            MainInfo.DoctorNotiCount = await _notificationservices.GetNotificationCount(1);
            MainInfo.JudgeNotiCount = await _notificationservices.GetNotificationCount(2);
            MainInfo.UserNotiCount = await _notificationservices.GetNotificationCount(3);
            MainInfo.PharmacyNotiCount = await _notificationservices.GetNotificationCount(4);
            MainInfo.AllNotifications = await _notificationservices.GetNotificationList(0);
            return View(MainInfo);
        }

        public virtual async Task<ActionResult> NotificationSend(int type)
        {
            var detailinfo = new NotificationDetail();
            detailinfo.Type = type;
            detailinfo.AllNotifications = await _notificationservices.GetNotificationList(type);
            //doctor
            if (type == 1)
            {
                detailinfo.AllUsers = await _doctorservice.GetDoctorNotifiList();
            }//judge
            else if (type == 2)
            {
                detailinfo.AllUsers = await _judgeservice.GetJudgeNotifi();
            }//illness
            else if (type == 3)
            {
                detailinfo.AllUsers = await _illnessservice.GetIllnessNotifi();
            }//pharmacy
            else if (type == 4)
            {
                detailinfo.AllUsers = await _pharmacyservice.GetPharmacyNotifi();
            }

            return View(detailinfo);
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddNotificationSend(int type, string text, string title, string userid)
        {
            var notifi = new Notification()
            {
                Text = text,
                Title = title,
                Type = type,
                UserId = userid
            };
            if (await _notificationservices.AddNotification(notifi))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_listnotification", await _notificationservices.GetNotificationList(type))
                    }
                };
            }


            return new JsonNetResult
            {
                Data = new
                {
                    success = false,
                    View = this.RenderPartialViewToString("_listnotification", await _notificationservices.GetNotificationList(type))
                }
            };
        }

        [HttpPost]
        public virtual async Task<ActionResult> DeleteNotificationSend(int id, int type)
        {
            if (await _notificationservices.DeleteNotification(id))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_listnotification", await _notificationservices.GetNotificationList(type))
                    }
                };
            }


            return new JsonNetResult
            {
                Data = new
                {
                    success = false,
                    View = this.RenderPartialViewToString("_listnotification", await _notificationservices.GetNotificationList(type))
                }
            };
        }
    }
}