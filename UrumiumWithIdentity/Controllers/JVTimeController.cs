using DataLayer.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumWithIdentity.Models;

namespace UrumiumWithIdentity.Controllers
{
    public partial class JVTimeController : Controller
    {
        IJVTimeService _jvtimeservices;
        IIllnessService _illnessservice;
        readonly IUnitOfWork _uow;
        public JVTimeController(IJVTimeService jvtimeservice, IIllnessService illnessservice,
            IUnitOfWork uow)
        {
            _jvtimeservices = jvtimeservice;
            _illnessservice = illnessservice;
            _uow = uow;
        }

        public async virtual Task<ActionResult> IllnessJudgeVisit(string id)
        {
            var finduser = await _illnessservice.Getillness(id);
            if (finduser!=null)
            {
                return View(await _jvtimeservices.GetVisitJudgeList(finduser.Id));
            }
            return View();
        }

        //[HttpPost]
        //public async virtual Task<ActionResult> AddVisitJudge(string illnessid,int cost)
        //{
        //    var finduser = await _illnessservice.Getillness(illnessid);
        //    if (finduser!=null)
        //    {
        //        if (await _jvtimeservices.AddJudgeIllnessPayment(finduser.Id, cost,""))
        //        {
        //            return new JsonNetResult
        //            {
        //                Data = new
        //                {
        //                    success = true,
        //                }
        //            };
        //        }
        //    }
            
           
        //        return new JsonNetResult
        //        {
        //            Data = new
        //            {
        //                success = false
        //            }
        //        };
        //}

        [HttpPost]
        public async virtual Task<ActionResult> AddVisitJudgePayment(string illnessid, string amount)
        {
            SendPayment pay = new SendPayment();
            HttpCookie myCookie = Request.Cookies["usercookie"];
            if (myCookie != null)
            {
                try
                {
                    string result = pay.payjudge(amount,myCookie.Value);
                    JsonParameters Parmeters = JsonConvert.DeserializeObject<JsonParameters>(result);

                    if (Parmeters.status == 1)
                    {
                        return new JsonNetResult
                        {
                            Data = new
                            {
                                data = "https://pay.ir/payment/gateway/" + Parmeters.transId,
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
                    data = "مشکل سرور ",
                    success = false
                }
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ReturnVisitPayment(Models.VerifyResultPayment Vresult)
        {
            SendPayment pay = new SendPayment();
            if (Request.Form["status"]=="1")
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
                            int cost = Convert.ToInt32(Parmeters.amount);
                            if (await _jvtimeservices.AddJudgeIllnessPayment(finduser.Id, cost, Parmeters.transId))
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

    }
}