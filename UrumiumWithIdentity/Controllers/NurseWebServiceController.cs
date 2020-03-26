using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.NurseInterface;

namespace UrumiumWithIdentity.Controllers
{
    public class NurseWebServiceController : Controller
    {
        IDoctorService _doctorservice;
        INurseService _nurseservice;
        readonly IUnitOfWork _uow;
        public NurseWebServiceController(IDoctorService doctorservice,INurseService nurseservice,
            IUnitOfWork uow)
        {
            _doctorservice = doctorservice;
            _nurseservice = nurseservice;
            _uow = uow;
        }
        // GET: NurseWebService

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetZirmajmoeeInfo(string mobile, string password)
        {
            if (await _nurseservice.CheckLogin(mobile, password))
            {
                var findsms = await _nurseservice.GetNurseInfowithmobile(mobile);
                if (findsms != null)
                {
                    return Json(await _doctorservice.ListStringDoctorMoarefzirmajmoee(findsms.Id, findsms.BusinessKey), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}