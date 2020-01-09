using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.TicketInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorNoteViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.SubsetViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class SubsetManagmentController : Controller
    {
        IDoctorService _doctorservices;
        IDoctorNoteService _doctornoteservice;
        IVisitService _visitservice;
        readonly IUnitOfWork _uow;

        public SubsetManagmentController(IDoctorService newdoctorservice, IDoctorNoteService doctornoteservice, IVisitService visitservice,
            IUnitOfWork uow)
        {
            _doctorservices = newdoctorservice;
            _doctornoteservice = doctornoteservice;
            _visitservice = visitservice;
            _uow = uow;
        }
        // GET: SubsetManagment
        public virtual async Task<ActionResult> Index()
        {
            return View(await _doctorservices.SearchDoctor(""));
        }


        public virtual async Task<ActionResult> SubsetNotes(int doctorid)
        {
            DoctorNoteViewModel newnotes = new DoctorNoteViewModel();
            newnotes.DoctorSubsetPassages = await _doctornoteservice.GetAllDoctorSubsetPassage(doctorid);
            newnotes.Id = doctorid;
            return View(newnotes);
        }

        public virtual async Task<ActionResult> SubsetVisitDoctor(int doctorid)
        {
            SubsetViewModel newsubsert = new SubsetViewModel();
            newsubsert.Id = doctorid;
            newsubsert.AllVisitList = await _visitservice.GetDoctorVisitTime(doctorid);
            newsubsert.alllistmoaref = await _doctorservices.ListStringDoctorMoarefWithSubsetinfo(doctorid);
            return View(newsubsert);
        }

        public virtual async Task<ActionResult> SubsetVisitDoctorList(int doctorid)
        {
            return View(await _visitservice.GetAlldoctorVisitTimeWebservice(doctorid));
        }

        [HttpPost]
        public virtual async Task<ActionResult> SearchItem(string text)
        {
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_DoctorListAjax", await _doctorservices.SearchDoctor(text))
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


        [HttpPost]
        public virtual async Task<ActionResult> AddNote(string text, int doctorid)
        {
            if (await _doctornoteservice.AddDoctorSubsetPassage(text, doctorid))
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
        public virtual async Task<ActionResult> DeleteNote(int id)
        {
            if (await _doctornoteservice.DeleteDoctorSubsetPassage(id))
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
    }
}