using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyMassage;
using UrumiumMVC.ServiceLayer.Contract.MassagePharmacyInterface;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.ServiceLayer.EFServices.PharmacyService;

namespace UrumiumWithIdentity.Controllers
{
    public partial class PharmacyWebServiceController : Controller
    {
        IPharmacyService _pharmacyservice;
        IVisitService _visitservices;
        IIllnessService _illnessservice;
        IMassagePharmacyService _pharmacymassageservice;
        IPharmacyIllnessService _pharmacyillness;
        public PharmacyWebServiceController(IPharmacyService pharmacyservice,PharmacyIllnessMassageService messageservice, IVisitService visitservices, IIllnessService illnessservice, IMassagePharmacyService pharmacymassageservice)
        {
            _pharmacyservice = pharmacyservice;
            _pharmacyillness = messageservice;
            _visitservices = visitservices;
            _illnessservice = illnessservice;
            _pharmacymassageservice = pharmacymassageservice;
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllPharmacy()
        {
            return Json(await _pharmacyservice.GetAllPharmacyForService(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetPharmacyInfo(string mobile)
        {
            return Json(await _pharmacyservice.GetPharmacyInfoWithMobile(mobile), JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdatePharmacyInfo(string mobile, string name, string description, int cityid, string address, string image)
        {
            string imagedoctor = "";
            if (image != "")
            {
                imagedoctor = Guid.NewGuid().ToString() + ".jpg";
                string imgillnessiamge = Path.Combine(Server.MapPath("~/uploads/Pharmacy/"), imagedoctor);
                byte[] imageillnessBytes = Convert.FromBase64String(image);
                System.IO.File.WriteAllBytes(imgillnessiamge, imageillnessBytes);
            }
            return Json(await _pharmacyservice.UpdatePharmacyInfoWithMobile(mobile, name, description, cityid, imagedoctor, address), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllPharmacyNoskhe()
        {
            List<PharmacyListSendedNoskhe> _pharmacynoskhelist = new List<PharmacyListSendedNoskhe>();

            var findvisits = await _visitservices.SendedListNoskheToPharmacy();
            if (findvisits != null)
            {
                foreach (var item in findvisits)
                {
                    PharmacyListSendedNoskhe _pharmacyitem = new PharmacyListSendedNoskhe();
                    _pharmacyitem.DoctorId = item.DoctorId;
                    _pharmacyitem.DoctorName = item.DayTimes.Doctors.Name;
                    _pharmacyitem.VisitId = item.Id;
                    _pharmacyitem.IllnessId = item.UserId;
                    var finduser = await _illnessservice.GetillnessClient(item.UserId);
                    if (finduser != null)
                    {
                        _pharmacyitem.IllnessName = finduser.Name;
                    }
                    _pharmacynoskhelist.Add(_pharmacyitem);
                }
            }
            return Json(_pharmacynoskhelist, JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllPharmacyMassage(string mobile)
        {
            var find = await _pharmacyservice.GetPharmacyInfoWithMobile(mobile);
            List<PharmacyMassegeListViewModel> _pharmacymassage = new List<PharmacyMassegeListViewModel>();
            if (find != null)
            {
                var findlistmassage = await _pharmacymassageservice.GetPharmacyNoskheMassageToPharmacy(find.Id);
                foreach (var item in findlistmassage)
                {
                    PharmacyMassegeListViewModel newpharmacy = new PharmacyMassegeListViewModel();
                    newpharmacy.Illnessid = item.IllnessId;
                    var illnessfind = await _illnessservice.GetillnessClient(item.IllnessId);
                    newpharmacy.Illnessname = illnessfind.Name;
                    newpharmacy.Text = item.Description;
                    newpharmacy.Visitid = item.VisitId;
                    newpharmacy.Doctorid = item.DoctorId;
                    _pharmacymassage.Add(newpharmacy);
                }
            }
            return Json(_pharmacymassage, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddPharmacyMassage(string mobile, int visitid, string massage)
        {
            var find = await _pharmacyservice.GetPharmacyInfoWithMobile(mobile);
            if (find != null)
            {
                var findvisit = await _visitservices.GetVisitFirst(visitid);
                if (findvisit != null)
                {
                    await _visitservices.DontShowNoskheToPharmacy(visitid);
                    return Json(await _pharmacymassageservice.AddPharmacyMassage(visitid, find.Id, findvisit.DoctorId, findvisit.UserId, massage));
                }
            }
            return Json(false);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> SendToPharmacyNoskhe(int visitid)
        {
            return Json(await _visitservices.ShowNoskheToPharmacy(visitid));
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> Addillnessmassage(string text, string image, string mobile)
        {
            if (image != "")
            {
                string imageillness = Guid.NewGuid().ToString() + ".jpg";
                string imgillnessiamge = Path.Combine(Server.MapPath("~/uploads/Pharmacy/"), imageillness);
                byte[] imageillnessBytes = Convert.FromBase64String(image);
                System.IO.File.WriteAllBytes(imgillnessiamge, imageillnessBytes);

                var findillness = await _illnessservice.GetIllnessWithMobile(mobile);
                if (findillness != null)
                {
                    await _pharmacyillness.AddPharmacyIllness(new Illness_Pharmacy_Massage()
                    {
                        IllnessId = findillness.Id,
                        Image = imageillness,
                        Text = text
                    });
                    return Json("true");
                }
            }
            return Json("false");
        }

        [System.Web.Http.HttpPost]
        public async Task<ActionResult> AddAnswerillnessmassage(int id,string text)
        {
            if (await _pharmacyillness.AddAnswer(text, id))
            {
                return Json("true");
            }
            return Json("false");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllillnessmassage(string mobile)
        {
            var alllist = new List<PharmacyIllnessMassage>();
            var findillness = await _illnessservice.GetIllnessWithMobile(mobile);
            if (findillness != null)
            {
                Converter convert = new Converter();
                var findmassage = await _pharmacyillness.GetAllIllness(findillness.Id);
                foreach (var item in findmassage)
                {
                    var one = new PharmacyIllnessMassage();
                    one.Id = item.Id;
                    one.Answer = item.Answer;
                    one.IllnessId = item.IllnessId;
                    one.Image = item.Image;
                    one.Text = item.Text;
                    one.Time = convert.GetPersianDate(item.Time);
                    alllist.Add(one);
                }
            }
            return Json(alllist, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllmassage()
        {
            Converter convert = new Converter();
            var alllist = new List<PharmacyIllnessMassage>();
            var findillness = await _pharmacyillness.GetAll();
            foreach (var item in findillness)
            {
                var one = new PharmacyIllnessMassage();
                one.Id = item.Id;
                one.Answer = item.Answer;
                one.IllnessId = item.IllnessId;
                one.Image = item.Image;
                one.Text = item.Text;
                one.Time = convert.GetPersianDate(item.Time);
                alllist.Add(one);
            }
            return Json(alllist, JsonRequestBehavior.AllowGet);
        }
    }
}