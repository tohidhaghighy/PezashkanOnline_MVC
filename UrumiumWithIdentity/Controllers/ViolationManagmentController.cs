using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.ViolationInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class ViolationManagmentController : Controller
    {
        IIllnessService _illnessservices;
        IDoctorService _doctorservice;
        IViolationService _violationservice;
        readonly IUnitOfWork _uow;

        public ViolationManagmentController(IDoctorService doctorservice, IIllnessService illnessservice, IViolationService violationservice,
           IUnitOfWork uow)
        {
            _doctorservice = doctorservice;
            _illnessservices = illnessservice;
            _violationservice = violationservice;
            _uow = uow;
        }

        // GET: DoctorManagment
        public async virtual Task<ActionResult> Index()
        {
            return View(await _violationservice.ListViolationOnlyNotCheck());
        }

        [HttpPost]
        public async virtual Task<ActionResult> GetList(string peigiri)
        {
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_ViolationListAjax", await _violationservice.GetViolationsearch(peigiri))
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
        public async virtual Task<ActionResult> CheckIsOk(int id, string answer)
        {
            if (await _violationservice.ChangeChecktoOk(id, answer))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_ViolationListAjax", await _violationservice.ListViolationOnlyNotCheck())
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
        public async virtual Task<ActionResult> AddTakhalof(string peigiri, string despei)
        {
            HttpCookie userid = Request.Cookies["usercookie"];
            HttpCookie usertype = Request.Cookies["usertype"];
            if (await _violationservice.AddViolation(peigiri, userid.Value, despei, 0, ""))
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
                    success = false,
                }
            };
        }

    }
}