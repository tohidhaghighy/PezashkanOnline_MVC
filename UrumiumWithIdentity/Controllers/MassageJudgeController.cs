using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;
using Microsoft.AspNet.Identity;
using UrumiumMVC.Common.UploadJson;

namespace UrumiumWithIdentity.Controllers
{
    public partial class MassageJudgeController : Controller
    {
        IMassageJService _massagejudgeservices;
        IIllnessService _illnessservices;
        readonly IUnitOfWork _uow;
        public MassageJudgeController(IMassageJService massagejudgeservice, IIllnessService illnessservice,
            IUnitOfWork uow)
        {
            _massagejudgeservices = massagejudgeservice;
            _illnessservices = illnessservice;
            _uow = uow;
        }
        // GET: MassageJudge

        [HttpPost]
        public async virtual Task<ActionResult> AddMassageIllness(int visitid, string text, Boolean isuser)
        {
            if (await _massagejudgeservices.AddJudgeIllness(visitid, User.Identity.GetUserId(), text, true,"",0))
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
        public async virtual Task<ActionResult> AddMassageJudge(int visitid, string text, Boolean isuser)
        {
            if (await _massagejudgeservices.AddJudgeIllness(visitid, User.Identity.GetUserId(), text, false,text,0))
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