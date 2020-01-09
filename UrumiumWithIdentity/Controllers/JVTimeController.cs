using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;

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

        [HttpPost]
        public async virtual Task<ActionResult> AddVisitJudge(string illnessid,int cost)
        {
            var finduser = await _illnessservice.Getillness(illnessid);
            if (finduser!=null)
            {
                if (await _jvtimeservices.AddJudgeIllnessPayment(finduser.Id, cost))
                {
                    return new JsonNetResult
                    {
                        Data = new
                        {
                            success = true,
                        }
                    };
                }
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