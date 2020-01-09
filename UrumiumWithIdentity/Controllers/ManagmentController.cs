using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using System.Threading.Tasks;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ManagmentViewModel;

namespace UrumiumMVC.Controllers
{
    [Authorize]
    public partial class ManagmentController : Controller
    {
        IDoctorService _doctorservices;
        IJudgeService _judgeservices;
        IPharmacyService _pharmacyservice;
        IIllnessService _illnessservice;
        readonly IUnitOfWork _uow;

        public ManagmentController(IDoctorService cityservice, IJudgeService stateservice, IPharmacyService judgeservice,IIllnessService illnessservice,
           IUnitOfWork uow)
        {
            _doctorservices = cityservice;
            _judgeservices = stateservice;
            _pharmacyservice = judgeservice;
            _illnessservice = illnessservice;
            _uow = uow;
        }

        public virtual async Task<ActionResult> Index()
        {
            ManagmentCountViewModel newlist = new ManagmentCountViewModel();
            newlist.DoctorCount = _doctorservices.GetAllDoctorCount();
            newlist.IllnessCount = _illnessservice.GetAllillnessCount();
            newlist.JudgeCount = _judgeservices.GetAlljudgeCount();
            newlist.PharmacyCount = _pharmacyservice.GetAllPharmacyCount();
            return View(newlist);
        }
    }
}