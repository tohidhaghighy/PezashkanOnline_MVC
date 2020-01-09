using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MedicineInterface;
using UrumiumMVC.ServiceLayer.Contract.NoskheInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class NoskheWebServiceController : Controller
    {
        INoskheService _noskheservice;
        IVisitService _visitservices;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        IPharmacy_MassageService _pharmacymassageservice;
        IPharmacyService _pharmacyservice;
        IMedicineService _medicineservice;
        readonly IUnitOfWork _uow;

        public NoskheWebServiceController(INoskheService noskheservice, IMedicineService medicineservice, IVisitService visitservice, IPharmacyService pharmacyservice, IDoctorService doctorservice, IIllnessService illnessservice, IPharmacy_MassageService pharmacymassageservie,
           IUnitOfWork uow)
        {
            _noskheservice = noskheservice;
            _visitservices = visitservice;
            _illnessservice = illnessservice;
            _doctorservice = doctorservice;
            _medicineservice = medicineservice;
            _pharmacymassageservice = pharmacymassageservie;
            _pharmacyservice = pharmacyservice;
            _uow = uow;
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetNoskheMedicine(int visitid)
        {
            return Json(await _noskheservice.GetNoskheMedicinWebServiceFinally(visitid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetNoskheMedicineNotFinally(int visitid)
        {
            return Json(await _noskheservice.GetNoskheMedicinWebServiceNotFinally(visitid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> SearchMedicine(string text, string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _medicineservice.SearchMedicineWebService(text, find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddMedicine(string text, string description, string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _medicineservice.AddMedicine(find.Id, text, description));
            }
            return Json(null);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> FinalyMedicine(int visitid)
        {
            return Json(await _noskheservice.ChangeFinallyMedicinWebService(visitid));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> CheckFinalyMedicine(int visitid)
        {
            return Json(await _noskheservice.CheckFinallyMedicinWebService(visitid));
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddMedicineToNoskhe(int visitid, string text, int count)
        {
            return Json(await _noskheservice.AdMedicineToNoskheWebService(visitid, text, count));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> DeleteMedicineFromNoskhe(int id)
        {
            return Json(await _noskheservice.DeleteNoskhe(id));
        }

    }
}