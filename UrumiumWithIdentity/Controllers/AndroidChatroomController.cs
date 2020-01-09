using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.AdminInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class AndroidChatroomController : Controller
    {

        IAdminService _adminservice;
        IMassageIService _imassageservice;
        IMassageJService _jmassageservice;
        readonly IUnitOfWork _uow;

        public AndroidChatroomController(IAdminService adminservice, IAdminService insuranceservice, IMassageIService imassageservice, IMassageJService jmassageservice,
           IUnitOfWork uow)
        {
            _adminservice = adminservice;
            _imassageservice = imassageservice;
            _jmassageservice = jmassageservice;
            _uow = uow;
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetIllnessMassage(int visitid)
        {
            return Json(await _imassageservice.GetAllIllnessMassage(visitid), JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> PostNewIllnessMassage(int visitid, string userid, string text, Boolean isuser, int type)
        {
            string file = "";
            // if type == 1 this is image
            if (type == 1)
            {
                var imgillnessmassagephoto = Guid.NewGuid().ToString() + ".jpg";
                string imgpath = Path.Combine(Server.MapPath("~/uploads/Chat/"), imgillnessmassagephoto);
                byte[] imageillnessmassageBytes = Convert.FromBase64String(text);
                System.IO.File.WriteAllBytes(imgpath, imageillnessmassageBytes);
                file = imgillnessmassagephoto;
                text = "<a href='uploads/Chat/'" + file + "><img src='uploads/Chat/'" + file + " style='height:70px;width:70px;' href='uploads/Chat/'" + file + "/></a>";
            }
            else if (type == 2)
            {

            }
            else if (type == 0)
            {
                file = text;
            }
            if (await _imassageservice.AddIllnessMassage(visitid, userid, file, isuser, text, type))
            {
                return Json("true");
            }
            return Json("false");
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeMassage(int visitid)
        {
            return Json(await _jmassageservice.GetAllJudgeIllness(visitid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> PostNewJudgeMassage(int visitid, string userid, string text, Boolean isuser, int type)
        {
            string file = "";
            // if type == 1 this is image
            if (type == 1)
            {
                var imgillnessmassagephoto = Guid.NewGuid().ToString() + ".jpg";
                string imgpath = Path.Combine(Server.MapPath("~/uploads/Chat/"), imgillnessmassagephoto);
                byte[] imageillnessmassageBytes = Convert.FromBase64String(text);
                System.IO.File.WriteAllBytes(imgpath, imageillnessmassageBytes);
                file = imgillnessmassagephoto;
                text = "<a href='uploads/Chat/'" + file + "><img src='uploads/Chat/'" + file + " style='height:70px;width:70px;' href='uploads/Chat/'" + file + "/></a>";
            }
            else if (type == 2)
            {

            }
            else if (type == 0)
            {
                file = text;
            }
            if (await _jmassageservice.AddJudgeIllness(visitid, userid, file, isuser, text, type))
            {
                return Json("true");
            }
            return Json("false");
        }
    }
}