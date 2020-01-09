using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassagePharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyMassage;

namespace UrumiumWithIdentity.Controllers
{
    public partial class Pharmacy_MassageController : Controller
    {
        IMassagePharmacyService _pharmacymassageservice;
        IIllnessService _illnessservice;
        IPharmacyService _pharmacyservice;
        readonly IUnitOfWork _uow;

        public Pharmacy_MassageController(IMassagePharmacyService pharmacymassageservice, IIllnessService illnessservice, IPharmacyService pharmacyservice,
           IUnitOfWork uow)
        {
            _pharmacymassageservice = pharmacymassageservice;
            _illnessservice = illnessservice;
            _pharmacyservice = pharmacyservice;
            _uow = uow;
        }

        // GET: Pharmacy_Massage
        public async virtual Task<ActionResult> Index(string id)
        {
            var finduser = await _illnessservice.Getillness(id);
            PharmacyMassageInfoViewModel _pharmacymassage = new PharmacyMassageInfoViewModel();
            if (finduser != null)
            {
                _pharmacymassage.Illnessid = finduser.Id;
                _pharmacymassage.Illnessname = finduser.Name;
                _pharmacymassage.PhamacyMassageList = await _pharmacymassageservice.GetPharmacyNoskheMassageToIllness(finduser.Id);
            }

            return View(_pharmacymassage);
        }


        public async virtual Task<ActionResult> PharmacyMassageIndex(string id)
        {
            var finduser = await _pharmacyservice.GetPharmacy(id);
            List<PharmacyMassegeListViewModel> _pharmacymassage = new List<PharmacyMassegeListViewModel>();
            if (finduser != null)
            {
                var findlistmassage = await _pharmacymassageservice.GetPharmacyNoskheMassageToPharmacy(finduser.Id);
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

            return View(_pharmacymassage);
        }
    }
}