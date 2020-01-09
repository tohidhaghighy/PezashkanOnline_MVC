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

        [HttpPost]
        public async virtual Task<ActionResult> AddVisit(int id, int doctorid, string date)
        {
            var finduser = await _illnessservice.Getillness(User.Identity.GetUserId());
            if (finduser != null)
            {
                DateTime dt = Convert.ToDateTime(date);
                if (await _visitservices.AddVisitTime(id, doctorid, finduser.Id, dt))
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