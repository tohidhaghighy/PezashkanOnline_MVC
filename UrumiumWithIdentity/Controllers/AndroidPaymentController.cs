using DataLayer.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.AdminInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;
using UrumiumWithIdentity.Models;

namespace UrumiumWithIdentity.Controllers
{
    public partial class AndroidPaymentController : Controller
    {

        IAdminService _adminservice;
        IMassageIService _imassageservice;
        IMassageJService _jmassageservice;
        readonly IUnitOfWork _uow;

        public AndroidPaymentController(IAdminService adminservice, IAdminService insuranceservice, IMassageIService imassageservice, IMassageJService jmassageservice,
           IUnitOfWork uow)
        {
            _adminservice = adminservice;
            _imassageservice = imassageservice;
            _jmassageservice = jmassageservice;
            _uow = uow;
        }


        [System.Web.Http.HttpGet]
        public virtual ActionResult GetPaymentDoctorLink(int visitid, string illnessid, int doctorid, string date, string amount)
        {
            SendPayment pay = new SendPayment();
            string result = pay.paydoctor(amount, visitid, illnessid, doctorid, date);
            JsonParameters Parmeters = JsonConvert.DeserializeObject<JsonParameters>(result);

            if (Parmeters.status == 1)
            {
                return Json(new { Status = "1", Data = "https://pay.ir/payment/gateway/" + Parmeters.transId }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = "0", Data = "کدخطا : " + Parmeters.errorCode + "<br />" + "پیغام خطا : " + Parmeters.errorMessage }, JsonRequestBehavior.AllowGet);
            }
        }

        [System.Web.Http.HttpGet]
        public virtual ActionResult GetPaymentJudgeLink(string illnessid, string amount)
        {
            SendPayment pay = new SendPayment();
            string result = pay.payjudge(amount, illnessid);
            JsonParameters Parmeters = JsonConvert.DeserializeObject<JsonParameters>(result);

            if (Parmeters.status == 1)
            {
                return Json(new { Status = "1", Data = "https://pay.ir/payment/gateway/" + Parmeters.transId }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Status = "0", Data = "کدخطا : " + Parmeters.errorCode + "<br />" + "پیغام خطا : " + Parmeters.errorMessage }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}