using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.Marketing;

namespace UrumiumWithIdentity.Controllers
{
    public partial class MarketingDoctorController : Controller
    {
        IDoctorService _doctorservices;
        ICostPersendService _costpersendservices;
        readonly IUnitOfWork _uow;
        public MarketingDoctorController(IDoctorService doctorservice, IDoctorService doctorsservice, ICostPersendService costpersendservices,
        IUnitOfWork uow)
        {
            _doctorservices = doctorservice;
            _costpersendservices = costpersendservices;
            _uow = uow;
        }
        // GET: MarketingDoctor
        public async virtual Task<ActionResult> Index(string id)
        {
            Marketing _market = new Marketing();
            var findoffer = await _costpersendservices.GetCostPersend();
            if (findoffer!=null)
            {
                _market.CostOffer = findoffer.PersendPerVisit;
                var finddoctor = await _doctorservices.GetDoctorwithguidid(id);
                List<Doctorlistmoaref> alllistmoaref = new List<Doctorlistmoaref>();
                alllistmoaref= await _doctorservices.ListStringDoctorMoaref(finddoctor.Id);
                _market.CountZirmajmoee = alllistmoaref.Count();
                _market.DoctorList = alllistmoaref;
                _market.Doctors = await _doctorservices.GetDoctor(finddoctor.Id);
                    return View(_market);
            }
            return View();
        }
    }
}