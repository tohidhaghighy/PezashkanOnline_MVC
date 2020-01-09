using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.AnswerQuestionInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ServiceLayer.Contract.MassagePharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.QuestionInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class IllnessWebServiceController : Controller
    {
        IIllnessService _illnessservice;
        IMassagePharmacyService _massagepharmacyservice;
        IJVTimeService _jvtimeservices;
        IVisitService _visitservice;
        IQuestionService _quesionservice;
        IAnswerQuestionService _answerquestion;

        public IllnessWebServiceController(IIllnessService illnessservice, IQuestionService questionservice, IAnswerQuestionService answerquestion, IMassagePharmacyService pharmacymassageservice, IJVTimeService jvtimeservice, IVisitService visitservice)
        {
            _illnessservice = illnessservice;
            _massagepharmacyservice = pharmacymassageservice;
            _jvtimeservices = jvtimeservice;
            _quesionservice = questionservice;
            _visitservice = visitservice;
            _answerquestion = answerquestion;
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetIllnessInfo(string mobile)
        {
            return Json(await _illnessservice.GetIllnessWithMobileWebService(mobile), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdateIllnessInfo(int id = 0, string name = "", int cityid = 0, int sugar = 0, int presure = 0, int bimeid = 0, int weight = 0, int age = 0, string serialbime = "", string date = "", string image = "")
        {
            string imageillness = "";
            if (image != "")
            {
                imageillness = Guid.NewGuid().ToString() + ".jpg";
                string imgillnessiamge = Path.Combine(Server.MapPath("~/uploads/Illness/"), imageillness);
                byte[] imageillnessBytes = Convert.FromBase64String(image);
                System.IO.File.WriteAllBytes(imgillnessiamge, imageillnessBytes);
            }

            return Json(await _illnessservice.UpdateillnessWithDate(id, name, cityid, imageillness,"", age, weight, sugar, presure, serialbime, bimeid, date));
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetIllnessVisitList(string mobile)
        {
            var find = await _illnessservice.GetIllnessWithMobile(mobile);
            if (find != null)
            {
                return Json(await _visitservice.GetAllUserVisitTimeWebservice(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetIllnessJudgeVisitList(string mobile)
        {
            var find = await _illnessservice.GetIllnessWithMobile(mobile);
            if (find != null)
            {
                return Json(await _jvtimeservices.GetOneUserVisitJudgeListWebservice(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetPharmacyMassageList(string mobile)
        {
            var find = await _illnessservice.GetIllnessWithMobile(mobile);
            if (find != null)
            {
                return Json(await _massagepharmacyservice.GetPharmacyWebSeriveListVisit(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeMassageList(string mobile)
        {
            var find = await _illnessservice.GetIllnessWithMobile(mobile);
            if (find != null)
            {
                return Json(await _jvtimeservices.GetVisitJudgeListWebservice(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetQuestionList(int visitid)
        {
            var find = await _visitservice.GetVisitFirst(visitid);
            if (find != null)
            {
                return Json(await _quesionservice.GetIllnessQuestion(find.DoctorId, find.UserId), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdateAnswerQuestion(int questionid, string text)
        {
            return Json(await _quesionservice.UpdateQuestion(questionid, text));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddAnswerQuestion(int questionid, int visitid, string text)
        {
            var find = await _visitservice.GetVisitFirst(visitid);
            if (find != null)
            {
                return Json(await _answerquestion.AddUserAnswerToQuestion(find.UserId, questionid, text));
            }
            return Json("false");
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdateAnswerQuestionForIllness(int questionid, int visitid, string text)
        {
            var find = await _visitservice.GetVisitFirst(visitid);
            if (find != null)
            {
                return Json(await _answerquestion.UpdateUserAnswerToQuestion(find.UserId, questionid, text));
            }
            return Json("false");
        }

    }
}