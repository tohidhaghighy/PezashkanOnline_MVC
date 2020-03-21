using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class JudgeWebServiceController : Controller
    {
        IJudgeService _judgeservice;
        ICostPersendService _costpersendservices;
        IJVTimeService _jvtimeservices;
        public JudgeWebServiceController(IJudgeService judgeservice, ICostPersendService costpersendservices, IJVTimeService jvtimeservices)
        {
            _judgeservice = judgeservice;
            _costpersendservices = costpersendservices;
            _jvtimeservices = jvtimeservices;
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllJudge()
        {
            return Json(await _judgeservice.GetAllJudgeForService(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeCost()
        {
            return Json(await _costpersendservices.GetCostPersend(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeInfo(string mobile)
        {
            return Json(await _judgeservice.GetJudgeInfowithmobile(mobile), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdateJudgeInfo(string mobile="", string name="",string bankcode="", string description="", int cityid=0, string image="")
        {
            string imagedoctor = "";
            if (image != "")
            {
                imagedoctor = Guid.NewGuid().ToString() + ".jpg";
                string imgillnessiamge = Path.Combine(Server.MapPath("~/uploads/Judge/"), imagedoctor);
                byte[] imageillnessBytes = Convert.FromBase64String(image);
                System.IO.File.WriteAllBytes(imgillnessiamge, imageillnessBytes);
            }
            return Json(await _judgeservice.Updatejudgewithmobile(mobile, name,bankcode, description, cityid, imagedoctor));
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeVisitList()
        {
            return Json(await _jvtimeservices.GetAllVisitJudgeListWebservice(), JsonRequestBehavior.AllowGet);
        }



    }
}