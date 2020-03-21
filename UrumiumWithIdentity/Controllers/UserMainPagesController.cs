using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.SearchDayInterface;
using UrumiumMVC.ServiceLayer.Contract.TimeDateDrInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.JudgeManagmentViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;
using UrumiumMVC.Common.UploadJson;
using OstanAg.Common.Extentions;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ServiceLayer.Contract.ViolationInterface;
using UrumiumMVC.ServiceLayer.Contract.NotificationInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class UserMainPagesController : Controller
    {
        ITimeDayDrService _doctortimeservices;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        IBimeService _bimeservice;
        IJudgeService _judgeservice;
        IGroupService _groupservice;
        IStateService _stateservice;
        IPharmacyService _pharmacyservice;
        IDayService _dayservice;
        IJVTimeService _jvtimeservice;
        IVisitService _visitservice;
        IViolationService _violationservice;
        INotificationService _notificationservice;
       
        readonly IUnitOfWork _uow;
        public UserMainPagesController(ITimeDayDrService newdoctortimeservice, INotificationService notificationservice, IViolationService violationservice, IJVTimeService jvtimeservice, IGroupService newgroupservice, IStateService newstateservice, IDoctorService newdoctorservice, IDayService dayservice,IIllnessService illnessservice,IBimeService bimeservice,IJudgeService judgeservie,IPharmacyService pharmacyservice,IVisitService visitservice,
            IUnitOfWork uow)
        {
            _groupservice = newgroupservice;
            _violationservice = violationservice;
            _notificationservice = notificationservice;
            _doctortimeservices = newdoctortimeservice;
            _stateservice = newstateservice;
            _jvtimeservice = jvtimeservice;
            _doctorservice = newdoctorservice;
            _dayservice = dayservice;
            _illnessservice = illnessservice;
            _bimeservice = bimeservice;
            _judgeservice = judgeservie;
            _pharmacyservice = pharmacyservice;
            _visitservice = visitservice;
            _uow = uow;
        }
        
        // GET: GroupManagment
        public async virtual Task<ActionResult> Doctor(string id)
        {
            DoctorViewModel newdocotrinfo = new DoctorViewModel();
            newdocotrinfo.doctor = await _doctorservice.GetDoctorwithguidid(id);
            if (newdocotrinfo.doctor.Active==false)
            {
                return View("TaiideModir");
            }
            newdocotrinfo.Groups = await _groupservice.GetAllGroup();
            newdocotrinfo.States = await _stateservice.GetAllState();
            newdocotrinfo.Days = await _dayservice.GetAllDay();
            try
            {
                newdocotrinfo.DoctorDays = await _doctortimeservices.GetAllDoctorSelectDays(newdocotrinfo.doctor.Id);
            }
            catch (Exception)
            {
            }
            return View(newdocotrinfo);
        }

        public async virtual Task<ActionResult> Judge(string id)
        {
            JudgeViewModel newjudge = new JudgeViewModel();
            newjudge.States = await _stateservice.GetAllState();
            newjudge.judges = await _judgeservice.Getjudge(id);
            if (newjudge.judges.Active==false)
            {
                return View("TaiideModir");
            }
            return View(newjudge);
        }

        public async virtual Task<ActionResult> Illness(string id)
        {
            IllnessViewModel newdocotrinfo = new IllnessViewModel();
            newdocotrinfo.Illness = await _illnessservice.Getillness(id);
            newdocotrinfo.States = await _stateservice.GetAllState();
            newdocotrinfo.Insurances = await _bimeservice.GetAllInsurance();
            return View(newdocotrinfo);
        }

        public async virtual Task<ActionResult> Pharmacy(string id)
        {
            PharmacyViewModel newpharmacy = new PharmacyViewModel();
            newpharmacy.States = await _stateservice.GetAllState();
            newpharmacy.Pharmacies = await _pharmacyservice.GetPharmacy(id);
            if (newpharmacy.Pharmacies.Active==false)
            {
                return View("TaiideModir");
            }
            return View(newpharmacy);
        }

        public async virtual Task<ActionResult> DoctorVisitList(string id)
        {
            DoctorVisitList dcall = new DoctorVisitList();
            var finduser= await _doctorservice.GetDoctorwithguidid(id);
            if (finduser!=null)
            {
                dcall.visitlist = await _visitservice.GetTodayDoctorVisitTime(finduser.Id, DateTime.Now);
                dcall.Mobile = finduser.Mobile;
                return View(dcall);
            }
            return null;
        }

        [HttpPost]
        public async virtual Task<ActionResult> DoctorDateSearchVisitList(string date,string id)
        {
            var finduser = await _doctorservice.GetDoctorValueWithMobile(id);
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_VisitDoctorListAjax", await _visitservice.GetSearchDateDoctorVisitTime(finduser.Id,date))
                    }
                };
            }
            catch (Exception)
            {

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = false
                    }
                };
            }
        }

        public async virtual Task<ActionResult> IllnessVisitList(string id)
        {
            var finduser = await _illnessservice.Getillness(id);
            if (finduser != null)
            {
                return View(await _visitservice.GetAllUserVisitTime(finduser.Id));
            }
            return null;
        }

        public async virtual Task<ActionResult> IllnessParvandeDoctorList(int doctorid,int illnessid)
        {
            
            return View(await _visitservice.GetParvandeIllness(doctorid,illnessid));
            
        }

        public async virtual Task<ActionResult> JudgeVisitList(string id)
        {
            return View(await _jvtimeservice.GetVisitJudgeOnlyFalseList());
        }

        public async virtual Task<ActionResult> PharmacyVisitList()
        {

            return View();
        }

        public async virtual Task<ActionResult> TaiideModir()
        {

            return View();
        }

        public async virtual Task<ActionResult> ViolationList(string id)
        {
            return View(await _violationservice.GetViolationuserwithanswer(id));
        }

        [HttpPost]
        public async virtual Task<ActionResult> NotificationList(int type)
        {
            HttpCookie myCookie = Request.Cookies["usercookie"];
            HttpCookie usertype = Request.Cookies["usertype"];
            int userid = 0;
            if (type==1)
            {
                var doctor = await _doctorservice.GetDoctorwithguidid(myCookie.Value);
                userid = doctor.Id;
            }
            else if (type==2)
            {
                var judge = await _judgeservice.Getjudge(myCookie.Value);
                userid = judge.Id;
            }
            else if (type==3)
            {
                var illness = await _illnessservice.Getillness(myCookie.Value);
                userid = illness.Id;
            }
            else if (type==4)
            {
                var pharmacy = await _pharmacyservice.GetPharmacy(myCookie.Value);
                userid = pharmacy.Id;
            }
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_notifylist", await _notificationservice.GetNotification(userid.ToString(), type))
                    }
                };
            }
            catch (Exception)
            {

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = false,
                        View = this.RenderPartialViewToString("_notifylist", await _notificationservice.GetNotification(userid.ToString(), type))
                    }
                };
            }
        }
    }
}