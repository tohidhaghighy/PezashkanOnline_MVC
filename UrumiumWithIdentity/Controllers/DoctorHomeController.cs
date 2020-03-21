using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.SettingInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.JudgeViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.MainPageViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class DoctorHomeController : Controller
    {
        readonly IUnitOfWork _uow;
        IFooterService _footerservice;
        IGroupService _groupservice;
        IPharmacyService _pharmacyservice;
        IDoctorService _doctorservice;
        IJudgeService _judgeservice;
        IIllnessService _illnessservice;
        IDayDoctorService _daydoctorservice;
        IVisitService _visitservices;
        ICityService _cityservice;
        ICostPersendService _costpersendservices;
        ISitePageInfoService _siteinfoservice;

        public DoctorHomeController(IGroupService groupservice,ISitePageInfoService siteinfoservice, IVisitService visitservices, ICostPersendService costpersendservice, ICityService cityservice, IPharmacyService pharmacyservice, IDoctorService doctorservice, IJudgeService judgeservice, IIllnessService illnessservice, IDayDoctorService daydoctorservice,
            IUnitOfWork uow)
        {
            _groupservice = groupservice;
            _siteinfoservice = siteinfoservice;
            _pharmacyservice = pharmacyservice;
            _doctorservice = doctorservice;
            _cityservice = cityservice;
            _judgeservice = judgeservice;
            _visitservices = visitservices;
            _costpersendservices = costpersendservice;
            _illnessservice = illnessservice;
            _daydoctorservice = daydoctorservice;
            _uow = uow;
        }
        
        public async virtual Task<ActionResult> Index()
        {
            
            MainPageViewModel alllistinfo = new MainPageViewModel();
            alllistinfo.Doctors = await _doctorservice.GetAllDoctorActive();
            alllistinfo.Groups = await _groupservice.GetAllGroup();
            alllistinfo.Judges = await _judgeservice.GetAlljudge();
            alllistinfo.Pharmacies = await _pharmacyservice.GetAllPharmacy();
            alllistinfo.Cities = await _cityservice.GetAllCity();
            var findillness = await _illnessservice.GetAllillness();
            alllistinfo.IllnessCount = findillness.Count;


            HttpCookie myCookie = Request.Cookies["usercookie"];
            HttpCookie usertype = Request.Cookies["usertype"];
            alllistinfo.IsLogin = 0;
            alllistinfo.UserId = "";
            alllistinfo.UsetType = "";
            if (myCookie != null)
            {
                alllistinfo.IsLogin = 1;
                alllistinfo.UserId = myCookie.Value;
                alllistinfo.UsetType = usertype.Value;
            }
            return View(alllistinfo);
        }

        public async virtual Task<ActionResult> ListDoctor(int groupid)
        {
            DoctorListViewModel _doctorlv = new DoctorListViewModel();
            if (groupid == 0)
            {
                _doctorlv.Doctors = await _doctorservice.GetAllDoctorActive();
            }
            else
            {
                _doctorlv.Doctors = await _doctorservice.GetGroupDoctor(groupid);
            }
            _doctorlv.Groups = await _groupservice.GetAllGroup();
            _doctorlv.Cities = await _cityservice.GetAllCity();
            return View(_doctorlv);
        }

        public async virtual Task<ActionResult> ListDoctorWithCity(int groupid, int cityid, string text)
        {
            DoctorListViewModel _doctorlv = new DoctorListViewModel();
            if (groupid == 0)
            {
                _doctorlv.Doctors = await _doctorservice.GetAllCityDoctor(cityid, text);
            }
            else
            {
                _doctorlv.Doctors = await _doctorservice.GetGroupCityDoctor(groupid, cityid, text);
            }
            _doctorlv.Groups = await _groupservice.GetAllGroup();
            _doctorlv.Cities = await _cityservice.GetAllCity();
            return View(_doctorlv);
        }

        public async virtual Task<ActionResult> ListPharmacy()
        {
            return View(await _pharmacyservice.GetAllPharmacyActive());
        }

        public virtual FileResult Download()
        {
            return File("~/uploads/test.apk", System.Net.Mime.MediaTypeNames.Application.Octet,"bermuda-darman.apk");
        }

        public async virtual Task<ActionResult> ListJudge()
        {
            CostJudgeList newcostjudge = new CostJudgeList();
            var findcost = await _costpersendservices.GetCostPersend();
            if (findcost!=null)
            {
                newcostjudge.CostJudge = findcost.CostJudgeVisit;
            }
            else
            {
                newcostjudge.CostJudge = 0;
            }

            HttpCookie myCookie = Request.Cookies["usercookie"];
            HttpCookie usertype = Request.Cookies["usertype"];
            newcostjudge.IsLogin = 0;
            if (myCookie != null)
            {
                newcostjudge.IsLogin = 1;
                newcostjudge.UserId = myCookie.Value;
                newcostjudge.WitchUser = usertype.Value;
            }
            newcostjudge.Judges = await _judgeservice.GetAlljudgeActive();
            return View(newcostjudge);
        }

        public async virtual Task<ActionResult> DetailDoctor(int id)
        {
            List<DoctorDays> alldatetimevisit = new List<DoctorDays>();
            DoctorDetailViewModel doctordetail = new DoctorDetailViewModel();
            doctordetail.Doctors = await _doctorservice.GetDoctor(id);
            var findtimes = await _daydoctorservice.GetAllDoctorDaysFromToday(id);
            foreach (var item in findtimes)
            {
                int findtimescount = await _visitservices.GetDatevisittimecount(item.Id);
                DoctorDays newdoctortime = new DoctorDays();
                newdoctortime.Id = item.Id;
                newdoctortime.ReserveEnglishDatetime = item.ReserveEnglishDatetime;
                newdoctortime.ReservePersianDatetime = item.ReservePersianDatetime;
                newdoctortime.DoctorId = item.DoctorId;
                newdoctortime.TimeVisit = item.TimeVisit;
                newdoctortime.CountVisit = item.CountVisit - findtimescount;
                alldatetimevisit.Add(newdoctortime);
            }
            doctordetail.DoctorDays = alldatetimevisit;
            HttpCookie myCookie = Request.Cookies["usercookie"];
            HttpCookie usertype = Request.Cookies["usertype"];
            doctordetail.IsLogin = 0;
            if (myCookie !=null)
            {
                doctordetail.IsLogin = 1;
                doctordetail.WitchUser = usertype.Value;
                doctordetail.UserId = myCookie.Value;
            }
            return View(doctordetail);
        }


        public async virtual Task<ActionResult> SiteRolles()
        {
            return View(await _siteinfoservice.GetSitePageInfo());
        }

        public async virtual Task<ActionResult> SiteAboutUs()
        {
            return View(await _siteinfoservice.GetSitePageInfo());
        }

        public async virtual Task<ActionResult> SiteCooperationwithus()
        {
            return View(await _siteinfoservice.GetSitePageInfo());
        }


        public String RemoveSession()
        {
            if (Request.Cookies["usercookie"] != null)
            {
                Response.Cookies["usercookie"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["usertype"].Expires = DateTime.Now.AddDays(-1);
            }
            return "با موفقیت حذف شد";
        }
    }
}