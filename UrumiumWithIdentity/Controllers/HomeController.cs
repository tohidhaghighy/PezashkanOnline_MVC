using DataLayer.Context;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.MainPageViewModel;

namespace IdentitySample.Controllers
{
    public partial class HomeController : Controller
    {
        readonly IUnitOfWork _uow;
        IFooterService _footerservice;
        IGroupService _groupservice;
        IPharmacyService _pharmacyservice;
        IDoctorService _doctorservice;
        IJudgeService _judgeservice;
        IIllnessService _illnessservice;
        IDayDoctorService _daydoctorservice;

        public HomeController(IGroupService groupservice, IPharmacyService pharmacyservice, IDoctorService doctorservice, IJudgeService judgeservice,IIllnessService illnessservice, IDayDoctorService daydoctorservice,
            IUnitOfWork uow)
        {
            _groupservice = groupservice;
            _pharmacyservice = pharmacyservice;
            _doctorservice = doctorservice;
            _judgeservice = judgeservice;
            _illnessservice = illnessservice;
            _daydoctorservice = daydoctorservice;
            _uow = uow;
        }

        public async virtual Task<ActionResult> Index()
        {
            MainPageViewModel alllistinfo = new MainPageViewModel();
            alllistinfo.Doctors =await _doctorservice.GetAllDoctor();
            alllistinfo.Groups = await _groupservice.GetAllGroup();
            alllistinfo.Judges = await _judgeservice.GetAlljudge();
            alllistinfo.Pharmacies = await _pharmacyservice.GetAllPharmacy();
            var findillness = await _illnessservice.GetAllillness();
            alllistinfo.IllnessCount = findillness.Count;
            return View(alllistinfo);
        }

        public async virtual Task<ActionResult> ListDoctor(int groupid)
        {
            DoctorListViewModel _doctorlv = new DoctorListViewModel();
            if (groupid==0)
            {
                _doctorlv.Doctors = await _doctorservice.GetAllDoctor();
            }
            else
            {
                _doctorlv.Doctors = await _doctorservice.GetGroupDoctor(groupid);
            }
            _doctorlv.Groups = await _groupservice.GetAllGroup();
            return View(_doctorlv);
        }

        public async virtual Task<ActionResult> ListPharmacy()
        {
            return View(await _pharmacyservice.GetAllPharmacy());
        }

        public async virtual Task<ActionResult> ListJudge()
        {
            return View(await _judgeservice.GetAlljudge());
        }

        public async virtual Task<ActionResult> DetailDoctor(int id)
        {
            DoctorDetailViewModel doctordetail = new DoctorDetailViewModel();
            doctordetail.Doctors = await _doctorservice.GetDoctor(id);
            doctordetail.DoctorDays = await _daydoctorservice.GetAllDoctorDaysFromToday(id);
            return View(doctordetail);
        }
        
    }
}
