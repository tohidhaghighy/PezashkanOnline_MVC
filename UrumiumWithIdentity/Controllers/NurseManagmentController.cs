using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.NurseInterface;

namespace UrumiumWithIdentity.Controllers
{
    public class NurseManagmentController : Controller
    {
        INurseService _nurseservice;
        readonly IUnitOfWork _uow;

        public NurseManagmentController(INurseService nurseservice,
           IUnitOfWork uow)
        {
            _nurseservice = nurseservice;
            _uow = uow;
        }
        // GET: NurseManagment
        public async Task<ActionResult> Index()
        {
            return View(await _nurseservice.GetNurses());
        }


        [HttpPost]
        public virtual async Task<ActionResult> ChangeActive(int id)
        {
            if (await _nurseservice.ChangeActive(id))
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