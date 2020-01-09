using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.DomainClasses.Entities.Noskhe;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.NoskheInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.NoskheViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;
using Microsoft.AspNet.Identity;

namespace UrumiumWithIdentity.Controllers
{
    public partial class NoskheController : Controller
    {
        // GET: BimeManagment
        INoskheService _noskheservice;
        IVisitService _visitservices;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        IPharmacy_MassageService _pharmacymassageservice;
        IPharmacyService _pharmacyservice;
        readonly IUnitOfWork _uow;

        public NoskheController(INoskheService noskheservice, IVisitService visitservice, IPharmacyService pharmacyservice, IDoctorService doctorservice, IIllnessService illnessservice, IPharmacy_MassageService pharmacymassageservie,
           IUnitOfWork uow)
        {
            _noskheservice = noskheservice;
            _visitservices = visitservice;
            _illnessservice = illnessservice;
            _doctorservice = doctorservice;
            _pharmacymassageservice = pharmacymassageservie;
            _pharmacyservice = pharmacyservice;
            _uow = uow;
        }
        // GET: Noskhe
        public async virtual Task<ActionResult> Index(string id)
        {
            var finddoctor = await _doctorservice.GetDoctorwithguidid(id);
            return View();
        }

        public async virtual Task<ActionResult> IllnessNoskheShow()
        {
            return View();
        }
        
        public async virtual Task<ActionResult> Noskhe(int visitid, int doctorid, int illnessid)
        {
            NoskheViewModel newnoskheviewmodel = new NoskheViewModel();
            newnoskheviewmodel.doctorid = doctorid;
            newnoskheviewmodel.illnessid = illnessid;
            newnoskheviewmodel.visitid = visitid;
            newnoskheviewmodel.NoskheMedicines = await _noskheservice.GetINoskheMedicins(visitid);
            if (newnoskheviewmodel.NoskheMedicines.Count() > 0)
            {
                newnoskheviewmodel.Is_Finaly = newnoskheviewmodel.NoskheMedicines[0].Is_Finaly;
            }
            return View(newnoskheviewmodel);
        }

        public async virtual Task<ActionResult> ClientNoskhe(int visitid, int doctorid, int illnessid,string date)
        {
            NoskheViewModel newnoskheviewmodel = new NoskheViewModel();
            newnoskheviewmodel.doctorid = doctorid;
            newnoskheviewmodel.Date = date;
            
            newnoskheviewmodel.Doctorinfo = await _doctorservice.GetDoctor(doctorid);
            newnoskheviewmodel.Illnessinfo = await _illnessservice.GetillnessClient(illnessid);
            newnoskheviewmodel.illnessid = illnessid;
            newnoskheviewmodel.visitid = visitid;
            var firstvisit = await _visitservices.GetVisitFirst(visitid);
            if (firstvisit != null)
            {
                newnoskheviewmodel.SendedTo_Pharmacy = firstvisit.ShowNoskheTo_Pharmacy;
                newnoskheviewmodel.Peigiricode = firstvisit.PeigiriCode;
            }

            newnoskheviewmodel.NoskheMedicines = await _noskheservice.GetINoskheMedicinsFinaly(visitid);
            return View(newnoskheviewmodel);
        }

        public async virtual Task<ActionResult> ClientNoskhePharmacy(int visitid, int doctorid, int illnessid)
        {
            NoskheViewModel newnoskheviewmodel = new NoskheViewModel();
            newnoskheviewmodel.doctorid = doctorid;
            newnoskheviewmodel.illnessid = illnessid;
            newnoskheviewmodel.visitid = visitid;
            newnoskheviewmodel.Doctorinfo = await _doctorservice.GetDoctor(doctorid);
            newnoskheviewmodel.Illnessinfo = await _illnessservice.GetillnessClient(illnessid);
            var firstvisit = await _visitservices.GetVisitFirst(visitid);
            if (firstvisit != null)
            {
                newnoskheviewmodel.SendedTo_Pharmacy = firstvisit.ShowNoskheTo_Pharmacy;
                newnoskheviewmodel.Peigiricode = firstvisit.PeigiriCode;
                newnoskheviewmodel.Date = firstvisit.DayTimes.ReservePersianDatetime;
            }
            newnoskheviewmodel.NoskheMedicines = await _noskheservice.GetINoskheMedicinsFinaly(visitid);
            return View(newnoskheviewmodel);
        }

        public async virtual Task<ActionResult> NoskhePharmacy(string id)
        {
            List<PharmacyListSendedNoskhe> _pharmacynoskhelist = new List<PharmacyListSendedNoskhe>();
            if (id != null)
            {
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
                return View(_pharmacynoskhelist);
            }
            return Redirect("/");
        }


        [HttpPost]
        public async virtual Task<ActionResult> AddMedicineToNoskhe(int visitid, int doctorid, int illnessid, int count, string text)
        {
            await _noskheservice.AddNoskhe(visitid, doctorid, illnessid, text, count);
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_NoskheListDoctorWithDeleted", await _noskheservice.GetINoskheMedicins(visitid))
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
            return View();
        }

        [HttpPost]
        public async virtual Task<ActionResult> DeleteMedicineFromNoskhe(int id, int visitid)
        {
            await _noskheservice.DeleteNoskhe(id);
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_NoskheListDoctorWithDeleted", await _noskheservice.GetINoskheMedicins(visitid))
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
            return View();
        }


        [HttpPost]
        public async virtual Task<ActionResult> FinalMedicinetoNoskhe(int visitid, int doctorid, int illnessid)
        {
            if (await _noskheservice.FinalINoskheMedicins(visitid))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }


        [HttpPost]
        public async virtual Task<ActionResult> ShowNoskheToPharmacy(int visitid, int doctorid, int illnessid)
        {
            if (await _visitservices.ShowNoskheToPharmacy(visitid))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }

        [HttpPost]
        public async virtual Task<ActionResult> NoskheIsExistInPharmacy(int visitid, int doctorid, int illnessid, string description)
        {
            var findpharmacy = await _pharmacyservice.GetPharmacy(User.Identity.GetUserId());
            if (findpharmacy != null)
            {
                if (await _pharmacymassageservice.AddPharmacy(description, illnessid, doctorid, findpharmacy.Id, visitid))
                {
                    if (await _visitservices.DontShowNoskheToPharmacy(visitid))
                    {
                        return new JsonNetResult
                        {
                            Data = new
                            {
                                success = true,
                                type = 0
                            }
                        };
                    }
                    
                }
                else
                {
                    return new JsonNetResult
                    {
                        Data = new
                        {
                            success = false,
                            type=1
                        }
                    };
                }
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false,
                    type=2
                }
            };
        }
    }
}