using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using Microsoft.AspNet.Identity;
using UrumiumMVC.Common.UploadJson;

namespace UrumiumWithIdentity.Controllers
{
    public partial class MassageIllnessController : Controller
    {
        IMassageIService _massageillnessservices;
        IIllnessService _illnessservices;
        readonly IUnitOfWork _uow;
        public MassageIllnessController(IMassageIService massageillnessservice, IIllnessService illnessservice,
            IUnitOfWork uow)
        {
            _massageillnessservices = massageillnessservice;
            _illnessservices = illnessservice;
            _uow = uow;
        }


        [HttpPost]
        public async virtual Task<ActionResult> AddMassageIllness(int visitid, string text)
        {
            if (await _massageillnessservices.AddIllnessMassage(visitid, User.Identity.GetUserId(), text, true,text,0))
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
        public async virtual Task<ActionResult> AddMassageDoctor(int visitid, string text)
        {
            if (await _massageillnessservices.AddIllnessMassage(visitid, User.Identity.GetUserId(), text, true,text,0))
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