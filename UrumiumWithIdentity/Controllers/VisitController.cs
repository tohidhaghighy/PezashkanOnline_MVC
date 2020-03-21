using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using Microsoft.AspNet.Identity;
using UrumiumWithIdentity.Models;
using Newtonsoft.Json;

namespace UrumiumWithIdentity.Controllers
{
    public partial class VisitController : Controller
    {
        IVisitService _visitservices;
        IVisitService _visitservices1;
        IIllnessService _illnessservice;
        readonly IUnitOfWork _uow;
        public VisitController(IVisitService visitservice, IIllnessService illnessservice,
            IUnitOfWork uow)
        {
            _visitservices = visitservice;
            _illnessservice = illnessservice;
            _uow = uow;
        }
        // GET: Visit
        public virtual ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public async virtual Task<ActionResult> AddVisit(int id, int doctorid, string date)
        //{
        //    HttpCookie myCookie = Request.Cookies["usercookie"];
        //    if (myCookie!=null)
        //    {
        //        var finduser = await _illnessservice.Getillness(myCookie.Value);
        //        if (finduser != null)
        //        {
        //            DateTime dt = Convert.ToDateTime(date);
        //            if (await _visitservices.AddVisitTime(id, doctorid, finduser.Id, dt,""))
        //            {
        //                return new JsonNetResult
        //                {
        //                    Data = new
        //                    {
        //                        success = true,
        //                    }
        //                };
        //            }
        //        }
        //    }

        //    return new JsonNetResult
        //    {
        //        Data = new
        //        {
        //            success = false
        //        }
        //    };
        //}


        [HttpPost]
        public async virtual Task<ActionResult> AddVisitPayment(int visitid, int doctorid,string amount,string date)
        {
            SendPayment pay = new SendPayment();
            HttpCookie myCookie = Request.Cookies["usercookie"];
            if (myCookie != null)
            {
                try
                {
                    string result = pay.paydoctor(amount,visitid,myCookie.Value,doctorid,date);
                    JsonParameters Parmeters = JsonConvert.DeserializeObject<JsonParameters>(result);

                    if (Parmeters.status == 1)
                    {
                        return new JsonNetResult
                        {
                            Data = new
                            {
                                data= "https://pay.ir/payment/gateway/" + Parmeters.transId,
                                success = true
                            }
                        };
                    }
                    else
                    {
                        return new JsonNetResult
                        {
                            Data = new
                            {
                                data = "کدخطا : " + Parmeters.errorCode + "<br />" + "پیغام خطا : " + Parmeters.errorMessage,
                                success = false
                            }
                        };
                    }
                }
                catch
                {

                }
            }

            return new JsonNetResult
            {
                Data = new
                {
                    data="مشکل سرور ",
                    success = false
                }
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ReturnVisitPayment(Models.VerifyResultPayment Vresult)
        {
            SendPayment pay = new SendPayment();
            if (Request.Form["status"] == "1")
            {
                if (!string.IsNullOrEmpty(Request.Form["transId"]))
                {
                    string result = pay.verify(Request.Form["transId"]);
                    JsonParameters Parmeters = JsonConvert.DeserializeObject<JsonParameters>(result);
                    if (Parmeters.status == 1)
                    {
                        string[] allinfofromfactor = Parmeters.factorNumber.Split(',');
                        var finduser = await _illnessservice.Getillness(allinfofromfactor[0]);
                        if (finduser != null)
                        {
                            DateTime dt = Convert.ToDateTime(allinfofromfactor[3]);
                            int visitid = Convert.ToInt32(allinfofromfactor[2]);
                            int doctorid = Convert.ToInt32(allinfofromfactor[1]);
                            if (await _visitservices.AddVisitTime(visitid, doctorid, finduser.Id, dt, Parmeters.transId))
                            {
                                Payment p = new Payment()
                                {
                                    Stauts = 1,
                                    Amount = Parmeters.amount.ToString(),
                                    Name = finduser.Name,
                                    Peigiri = Parmeters.transId,
                                    Phone = ""
                                };
                                return View(p);
                            }
                        }
                    }
                }
            }
            Payment p1 = new Payment()
            {
                Stauts = 0,
                Amount = "",
                Name = "",
                Peigiri = "",
                Phone = ""
            };
            return View(p1);
        }

      
        [HttpPost]
        public async virtual Task<ActionResult> Finishvisit(int visitid)
        {
            
                if (await _visitservices.FinishVisit(visitid))
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