using DataLayer.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.ServiceLayer.Contract.AdminInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.NotificationInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel;
using UrumiumWithIdentity.Models;

namespace UrumiumWithIdentity.Controllers
{
    public partial class AndroidChatroomController : Controller
    {

        IAdminService _adminservice;
        IMassageIService _imassageservice;
        IMassageJService _jmassageservice;
        INotificationService _notificationservice;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        IJudgeService _judgeservice;
        IPharmacyService _pharmacyservice;

        readonly IUnitOfWork _uow;

        public AndroidChatroomController(IAdminService adminservice, IAdminService insuranceservice, IMassageIService imassageservice, IMassageJService jmassageservice,INotificationService notificationservice,IDoctorService doctorservice,IJudgeService judgeservice,IPharmacyService pharmacyservice,IIllnessService illnessservice,
           IUnitOfWork uow)
        {
            _adminservice = adminservice;
            _imassageservice = imassageservice;
            _jmassageservice = jmassageservice;
            _notificationservice = notificationservice;
            _illnessservice = illnessservice;
            _doctorservice = doctorservice;
            _judgeservice = judgeservice;
            _pharmacyservice = pharmacyservice;
            _uow = uow;
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetIllnessMassage(int visitid)
        {
            Converter convert = new Converter();
            List<IllnessMassageViewModel> allinfo = new List<IllnessMassageViewModel>();
            var list = await _imassageservice.GetAllIllnessMassage(visitid);
            foreach (var item in list)
            {
                string s = convert.GetPersianDate(item.Date);
                IllnessMassageViewModel newillness = new IllnessMassageViewModel()
                {
                    Id=item.Id,
                    Date=item.Date,
                    OnlyUrlText=item.OnlyUrlText,
                    Text=item.Text,
                    Time=s,
                    TypeMassage=item.TypeMassage,
                    UserDoctor=item.UserDoctor,
                    UserId=item.UserId,
                    VisitId=item.VisitId
                };
                allinfo.Add(newillness);
            }
            return Json(allinfo, JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> PostNewIllnessMassage(int visitid, string userid, string text, Boolean isuser, int type)
        {
            string file = "";
            // if type == 1 this is image
            if (type == 1)
            {
                var imgillnessmassagephoto = Guid.NewGuid().ToString() + ".jpg";
                string imgpath = Path.Combine(Server.MapPath("~/uploads/DoctorChat/"), imgillnessmassagephoto);
                byte[] imageillnessmassageBytes = Convert.FromBase64String(text);
                System.IO.File.WriteAllBytes(imgpath, imageillnessmassageBytes);
                file = "/uploads/DoctorChat/" + imgillnessmassagephoto;
                text = "<a href='" + file + "'><img src='" + file + "' style='height:70px;width:70px;' href='" + file + "'/></a>";
            }
            else if (type == 2)
            {

            }
            else if (type == 0)
            {
                file = text;
            }
            if (await _imassageservice.AddIllnessMassage(visitid, userid, file, isuser, text, type))
            {
                return Json("true");
            }
            return Json("false");
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeMassage(int visitid)
        {
            Converter convert = new Converter();
            List<IllnessMassageViewModel> allinfo = new List<IllnessMassageViewModel>();
            var list = await _jmassageservice.GetAllJudgeIllness(visitid);
            foreach (var item in list)
            {
                string s = convert.GetPersianDate(item.AnswerDatetime);
                IllnessMassageViewModel newillness = new IllnessMassageViewModel()
                {
                    Id = item.Id,
                    Date = item.AnswerDatetime,
                    OnlyUrlText = item.OnlyUrlText,
                    Text = item.Text,
                    Time = s,
                    TypeMassage = item.TypeMassage,
                    UserDoctor = item.UserJudge,
                    UserId = item.AnswerUserId
                };
                allinfo.Add(newillness);
            }
            return Json(allinfo, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> PostNewJudgeMassage(int visitid, string userid, string text, Boolean isuser, int type)
        {
            string file = "";
            // if type == 1 this is image
            if (type == 1)
            {
                var imgillnessmassagephoto = Guid.NewGuid().ToString() + ".jpg";
                string imgpath = Path.Combine(Server.MapPath("~/uploads/JudgeChat/"), imgillnessmassagephoto);
                byte[] imageillnessmassageBytes = Convert.FromBase64String(text);
                System.IO.File.WriteAllBytes(imgpath, imageillnessmassageBytes);
                file = "/uploads/JudgeChat/" + imgillnessmassagephoto;
                text = "<a href='" + file + "'><img src='" + file + "' style='height:70px;width:70px;' href='" + file + "'/></a>";
            }
            else if (type == 2)
            {

            }
            else if (type == 0)
            {
                file = text;
            }
            if (await _jmassageservice.AddJudgeIllness(visitid, userid, file, isuser, text, type))
            {
                return Json("true");
            }
            return Json("false");
        }


        [HttpPost]
        public async Task<string> Uploadfile(int visitid,string userid,Boolean isuser)
        {
            string vtitle = "";
            string vDesc = "";
            var voicename = Guid.NewGuid().ToString() + ".wav";
            string filepath = Path.Combine(Server.MapPath("~/uploads/DoctorChat/"), voicename);

            if (!string.IsNullOrEmpty(Request.Form["title"]))
            {
                vtitle = Request.Form["title"];
            }
            if (!string.IsNullOrEmpty(Request.Form["description"]))
            {
                vDesc = Request.Form["description"];
            }

            foreach (string item in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[item];
                file.SaveAs(filepath);
                string filename = "/uploads/DoctorChat/" + voicename;
                string text = "<a href='" + filename + "'><img src='" + filename + "' style='height:70px;width:70px;' href='" + filename + "'/></a>";
                if (await _imassageservice.AddIllnessMassage(visitid, userid, filename, isuser, text, 2))
                {
                    return "true";
                }
            }
            return "false";
        }



        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetNotifications(int type,string userid)
        {
            int usernumber = 0;
            if (type == 1)
            {
                var doctor = await _doctorservice.GetDoctorwithguidid(userid);
                usernumber = doctor.Id;
            }
            else if (type == 2)
            {
                var judge = await _judgeservice.Getjudge(userid);
                usernumber = judge.Id;
            }
            else if (type == 3)
            {
                var illness = await _illnessservice.Getillness(userid);
                usernumber = illness.Id;
            }
            else if (type == 4)
            {
                var pharmacy = await _pharmacyservice.GetPharmacy(userid);
                usernumber = pharmacy.Id;
            }
            return Json(await _notificationservice.GetNotification(usernumber.ToString(), type), JsonRequestBehavior.AllowGet);
        }
    }
}