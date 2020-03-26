using SmsIrRestful;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.MedicineInterface;
using UrumiumMVC.ServiceLayer.Contract.NoskheInterface;
using UrumiumMVC.ServiceLayer.Contract.NurseInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.QuestionInterface;
using UrumiumMVC.ServiceLayer.Contract.SearchDayInterface;
using UrumiumMVC.ServiceLayer.Contract.ViolationInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.CityState;
using UrumiumMVC.ViewModel.EntityViewModel.InsuranceViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.ViolationViewModel;
using UrumiumWithIdentity.Models;
using UrumiumWithIdentity.SmsPanelList;

namespace UrumiumWithIdentity.Controllers
{
    public partial class DoctorWebServiceController : Controller
    {
        IGroupService _groupservice;
        IDoctorService _doctorservice;
        IIllnessService _illnessservice;
        IJudgeService _judgeservice;
        IPharmacyService _pharmacyservice;
        ICityService _cityservice;
        IBimeService _bimeservice;
        IStateService _stateservice;
        IDayDoctorService _daydoctorservice;
        IVisitService _visitservice;
        IMassageIService _illnessmassageservice;
        IJVTimeService _jvtimeservices;
        IMedicineService _medicineservice;
        IQuestionService _quesionservice;
        INoskheService _noskheservice;
        ICostPersendService _costpersend;
        INurseService _nurseservice;
        IMassageJService _massagejudgeservice;
        IViolationService _violationservice;

        public DoctorWebServiceController(IGroupService groupservice,IViolationService violationservice, IMassageJService massagejudgeservice, IMassageIService massageillnessservice, INurseService nurseservice, ICostPersendService costpersend, INoskheService noskheservice, IQuestionService questionservice, IMedicineService medicineservice, IJVTimeService jvtimeservice, IVisitService visitservice, IIllnessService illnessservice, IJudgeService judgeservice, IPharmacyService pharmacyservice, IDoctorService doctorservice, IDayDoctorService daydoctorservice, ICityService cityservice, IStateService stateservice, IBimeService bimeservice)
        {
            _groupservice = groupservice;
            _massagejudgeservice = massagejudgeservice;
            _cityservice = cityservice;
            _bimeservice = bimeservice;
            _stateservice = stateservice;
            _noskheservice = noskheservice;
            _doctorservice = doctorservice;
            _daydoctorservice = daydoctorservice;
            _nurseservice = nurseservice;
            _illnessservice = illnessservice;
            _pharmacyservice = pharmacyservice;
            _jvtimeservices = jvtimeservice;
            _judgeservice = judgeservice;
            _visitservice = visitservice;
            _medicineservice = medicineservice;
            _quesionservice = questionservice;
            _costpersend = costpersend;
            _violationservice = violationservice;
            _illnessmassageservice = massageillnessservice;
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetDoctor(int id)
        {
            return Json(await _doctorservice.GetDoctorWebService(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetVisitTimeDoctor(int id)
        {
            return Json(await _daydoctorservice.GetAllTimeForWebService(id), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllGroup()
        {
            return Json(await _groupservice.GetAllGroupForService(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetAllDoctor()
        {
            return Json(await _doctorservice.GetAllDoctorForService(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetGroupDoctor(int groupid)
        {
            return Json(await _doctorservice.GetGroupDoctorForService(groupid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetCityDoctor(int cityid)
        {
            return Json(await _doctorservice.GetCityDoctorForService(cityid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetTextSearchDoctor(string text)
        {
            return Json(await _doctorservice.GetTextDoctorForService(text), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetCityGroupDoctor(int groupid, int cityid)
        {
            return Json(await _doctorservice.GetCityGroupDoctorForService(cityid, groupid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetCityState()
        {
            var find = await _cityservice.GetAllCityWebservice();
            var findmoratab = find.OrderBy(a => a.Name).ToList();
            return Json(findmoratab, JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetBimelist()
        {
            return Json(await _bimeservice.GetAllInsuranceWebservice(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> Getkkk()
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddUserWithSms(string name, int cityid, string mobile, string password, int type)
        {
            if (type == 1)
            {
                var findgroup = await _groupservice.GetFirstGroup();
                return Json(await _doctorservice.AddDoctorwithSms(name, cityid, "", mobile, findgroup.Id, mobile, password));
            }
            else if (type == 2)
            {
                return Json(await _judgeservice.Addjudgewithsms(name, cityid, "", mobile, mobile, password));
            }
            else if (type == 3)
            {
                var findbime = await _bimeservice.GetFirstInsurance();
                return Json(await _illnessservice.AddIllnessWithSms(name, cityid, "", mobile, mobile, findbime.Id, password));
            }
            else if (type == 4)
            {
                return Json(await _pharmacyservice.AddPharmacywithsms(name, cityid, "", mobile, mobile, password));
            }
            else if (type == 5)
            {
                return Json(await _nurseservice.AddNurse(name, mobile, password, cityid));
            }
            return Json("", JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> ChangePassword(string mobile, string password, int type,string newpassword)
        {
            if (type == 1)
            {
                if (await _doctorservice.Changepassword(mobile, password,newpassword))
                {
                    return Json("true");
                }
            }
            else if (type == 2)
            {
                if (await _judgeservice.Changepassword(mobile, password,newpassword))
                {
                    return Json("true");
                }
            }
            else if (type == 3)
            {
                if (await _illnessservice.Changepassword(mobile, password,newpassword))
                {
                    return Json("true");
                }
            }
            else if (type == 4)
            {
                if (await _pharmacyservice.Changepassword(mobile, password,newpassword))
                {
                    return Json("true");
                }
            }
            else if (type == 5)
            {
                if (await _nurseservice.Changepassword(mobile, password,newpassword))
                {
                    return Json("true");
                }
            }
            return Json("false");
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> CheckUserWithSms(string mobile, string password, int type)
        {
            if (type == 1)
            {
                if (await _doctorservice.CheckLogin(mobile, password))
                {
                    return Json("true");
                }
            }
            else if (type == 2)
            {
                if (await _judgeservice.CheckLogin(mobile, password))
                {
                    return Json("true");
                }
            }
            else if (type == 3)
            {
                if (await _illnessservice.CheckLogin(mobile, password))
                {
                    return Json("true");
                }
            }
            else if (type == 4)
            {
                if (await _pharmacyservice.CheckLogin(mobile, password))
                {
                    return Json("true");
                }
            }
            else if (type == 5)
            {
                if (await _nurseservice.CheckLogin(mobile, password))
                {
                    return Json("true");
                }
            }
            return Json("false");
        }

        [System.Web.Http.HttpGet]
        public async Task<string> testsms(string mobile)
        {
            string username = "09144697941";
            string password = "6938";
            string from = "1000";
            bool isFlash = false;
            SendSoapClient soapClient = new SendSoapClient();
            soapClient.SendSimpleSMS(username, password, new string[] { "09144967941" }, from, "sakan azuzan", isFlash);
            return "true";
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> SendActiveSms(string mobile, string password, int type)
        {
            SendSms sends = new SendSms();
            if (type == 1)
            {
                if (await _doctorservice.CheckLogin(mobile, password))
                {
                    var findsms = await _doctorservice.GetDoctorValueWithMobile(mobile);
                    if (findsms != null)
                    {
                        sends.SendSmsFunction(mobile,findsms.CodeActiveUse);
                        return Json("true");
                    }
                }
            }
            else if (type == 2)
            {
                if (await _judgeservice.CheckLogin(mobile, password))
                {
                    var findsms = await _judgeservice.GetJudgeInfowithmobile(mobile);
                    if (findsms != null)
                    {
                        sends.SendSmsFunction(mobile,findsms.CodeActiveUse);
                        return Json("true");

                    }
                }
            }
            else if (type == 3)
            {
                if (await _illnessservice.CheckLogin(mobile, password))
                {
                    var findsms = await _illnessservice.GetIllnessWithMobile(mobile);
                    if (findsms != null)
                    {
                        sends.SendSmsFunction(mobile,findsms.CodeActiveUse);
                        return Json("true");

                    }
                }
            }
            else if (type == 4)
            {
                if (await _pharmacyservice.CheckLogin(mobile, password))
                {
                    var findsms = await _pharmacyservice.GetPharmacyInfoWithMobile(mobile);
                    if (findsms != null)
                    {
                        sends.SendSmsFunction(mobile,findsms.ActiveCode);
                        return Json("true");

                    }
                }
            }
            else if (type==5)
            {
                if (await _nurseservice.CheckLogin(mobile,password))
                {
                    var findsms = await _nurseservice.GetNurseInfowithmobile(mobile);
                    if (findsms!=null)
                    {
                        sends.SendSmsFunction(mobile, findsms.CodeActiveUse);
                        return Json("true");
                    }
                }
            }
            return Json("");
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> CheckSendCodeActiveSms(string mobile, string password, int type, string code)
        {
            SendSms sends = new SendSms();
            if (type == 1)
            {
                if (await _doctorservice.CheckLogin(mobile, password))
                {
                    var findsms = await _doctorservice.GetDoctorValueWithMobile(mobile);
                    if (findsms != null)
                    {
                        if (findsms.CodeActiveUse == code)
                        {
                            if (await _doctorservice.UpdateActiveDoctoruser(mobile))
                            {
                                return Json("true");
                            }

                        }

                    }
                }
            }
            else if (type == 2)
            {
                if (await _judgeservice.CheckLogin(mobile, password))
                {
                    var findsms = await _judgeservice.GetJudgeInfowithmobile(mobile);
                    if (findsms != null)
                    {
                        if (findsms.CodeActiveUse == code)
                        {
                            if (await _judgeservice.UpdateActiveJudgeuser(mobile))
                            {
                                return Json("true");
                            }
                        }

                    }
                }
            }
            else if (type == 3)
            {
                if (await _illnessservice.CheckLogin(mobile, password))
                {
                    var findsms = await _illnessservice.GetIllnessWithMobile(mobile);
                    if (findsms != null)
                    {

                        if (findsms.CodeActiveUse == code)
                        {
                            if (await _illnessservice.UpdateActiveIllnessuser(mobile))
                            {
                                return Json("true");
                            }

                        }

                    }
                }
            }
            else if (type == 4)
            {
                if (await _pharmacyservice.CheckLogin(mobile, password))
                {
                    var findsms = await _pharmacyservice.GetPharmacyInfoWithMobile(mobile);
                    if (findsms != null)
                    {
                        if (findsms.ActiveCode == code)
                        {
                            if (await _pharmacyservice.UpdateActivePharmacyuser(mobile))
                            {
                                return Json("true");
                            }
                        }

                    }
                }
            }
            else if (type == 5)
            {
                if (await _nurseservice.CheckLogin(mobile, password))
                {
                    var findsms = await _nurseservice.GetNurseInfowithmobile(mobile);
                    if (findsms != null)
                    {
                        if (findsms.CodeActiveUse == code)
                        {
                            if (await _nurseservice.UpdateActiveNurseuser(mobile))
                            {
                                return Json("true");
                            }
                        }

                    }
                }
            }
            return Json("");
        }

        //[System.Web.Http.HttpPost]
        //public async Task<ActionResult> SendCode(string mobile)
        //{
        //    return Json(await _doctorservice.AddDoctorwithSms(name, cityid, "", mobile, findgroup.Id, mobile), JsonRequestBehavior.AllowGet);
        //}

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> CheckCode(string mobile, string code)
        {
            return Json(await _doctorservice.ActiveSmsCode(mobile, code));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> SaveImageDoctor(string Number, string ImgStrMelliCart, string ImgStrShenasname, string ImgStrNezamPezeshki)
        {
            if (await _doctorservice.GetDoctorWithMobile(Number))
            {
                var imagenamemellicart = Guid.NewGuid().ToString() + ".jpg";
                var imagenameshenasname = Guid.NewGuid().ToString() + ".jpg";
                var imagenamenezampezeshki = Guid.NewGuid().ToString() + ".jpg";
                //set the image path
                string imgPathmellicart = Path.Combine(Server.MapPath("~/uploads/Doctor/m/"), imagenamemellicart);
                string imgPathshenasname = Path.Combine(Server.MapPath("~/uploads/Doctor/s/"), imagenameshenasname);
                string imgPathnezampezeshki = Path.Combine(Server.MapPath("~/uploads/Doctor/n/"), imagenamenezampezeshki);


                byte[] imagemelliBytes = Convert.FromBase64String(ImgStrMelliCart);
                byte[] imageshenasnameBytes = Convert.FromBase64String(ImgStrShenasname);
                byte[] imagenezampezeshkiBytes = Convert.FromBase64String(ImgStrNezamPezeshki);

                System.IO.File.WriteAllBytes(imgPathmellicart, imagemelliBytes);
                System.IO.File.WriteAllBytes(imgPathshenasname, imageshenasnameBytes);
                System.IO.File.WriteAllBytes(imgPathnezampezeshki, imagenezampezeshkiBytes);
                if (await _doctorservice.UpdateMadarekDoctorWithMobile(Number, imagenamemellicart, imagenameshenasname, imagenamenezampezeshki))
                {
                    return Json("true");
                }
                return Json("false");

            }
            return Json("false");
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> SaveImageJudge(string Number, string ImgStrMelliCart, string ImgStrShenasname, string ImgStrMadrak)
        {
            if (await _judgeservice.GetJudgewithmobile(Number))
            {
                var imagenamemellicart = Guid.NewGuid().ToString() + ".jpg";
                var imagenameshenasname = Guid.NewGuid().ToString() + ".jpg";
                var imagenamemadrak = Guid.NewGuid().ToString() + ".jpg";
                //set the image path
                string imgPathmellicart = Path.Combine(Server.MapPath("~/uploads/Judge/m/"), imagenamemellicart);
                string imgPathshenasname = Path.Combine(Server.MapPath("~/uploads/Judge/s/"), imagenameshenasname);
                string imgPathmadrak = Path.Combine(Server.MapPath("~/uploads/Judge/madrak/"), imagenamemadrak);


                byte[] imagemelliBytes = Convert.FromBase64String(ImgStrMelliCart);
                byte[] imageshenasnameBytes = Convert.FromBase64String(ImgStrShenasname);
                byte[] imagemadrakBytes = Convert.FromBase64String(ImgStrMadrak);

                System.IO.File.WriteAllBytes(imgPathmellicart, imagemelliBytes);
                System.IO.File.WriteAllBytes(imgPathshenasname, imageshenasnameBytes);
                System.IO.File.WriteAllBytes(imgPathmadrak, imagemadrakBytes);
                if (await _judgeservice.UpdateJudgeMadarekwithmobile(Number, imagenamemellicart, imagenameshenasname, imagenamemadrak))
                {
                    return Json("true");
                }
                return Json("false");

            }
            return Json("false");
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> SaveImagePharmacy(string Number, string ImgStrMelliCart, string ImgStrShenasname, string ImgStrNezamPezeshki, string ImgStrParvane)
        {
            if (await _pharmacyservice.GetPharmacyWithMobile(Number))
            {
                var imagenamemellicart = Guid.NewGuid().ToString() + ".jpg";
                var imagenameshenasname = Guid.NewGuid().ToString() + ".jpg";
                var imagenamenezampezeshki = Guid.NewGuid().ToString() + ".jpg";
                var imagenameparvane = Guid.NewGuid().ToString() + ".jpg";
                //set the image path
                string imgPathmellicart = Path.Combine(Server.MapPath("~/uploads/Pharmacy/m/"), imagenamemellicart);
                string imgPathshenasname = Path.Combine(Server.MapPath("~/uploads/Pharmacy/s/"), imagenameshenasname);
                string imgPathnezampezeshki = Path.Combine(Server.MapPath("~/uploads/Pharmacy/n/"), imagenamenezampezeshki);
                string imgPathParvane = Path.Combine(Server.MapPath("~/uploads/Pharmacy/p/"), imagenameparvane);

                byte[] imagemelliBytes = Convert.FromBase64String(ImgStrMelliCart);
                byte[] imageshenasnameBytes = Convert.FromBase64String(ImgStrShenasname);
                byte[] imagenezampezeshkiBytes = Convert.FromBase64String(ImgStrNezamPezeshki);
                byte[] imageparvaneBytes = Convert.FromBase64String(ImgStrParvane);

                System.IO.File.WriteAllBytes(imgPathmellicart, imagemelliBytes);
                System.IO.File.WriteAllBytes(imgPathshenasname, imageshenasnameBytes);
                System.IO.File.WriteAllBytes(imgPathnezampezeshki, imagenezampezeshkiBytes);
                System.IO.File.WriteAllBytes(imgPathParvane, imageparvaneBytes);
                if (await _pharmacyservice.UpdatePharmacyMadrakWithMobile(Number, imagenamemellicart, imagenameshenasname, imagenameparvane, imagenamenezampezeshki))
                {
                    return Json("true");
                }
                return Json("false");

            }
            return Json("false");
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddVisitDoctorItem(int timeid, string number, int doctorid, string date)
        {
            DateTime dt = Convert.ToDateTime(date, new CultureInfo("fa-IR"));
            var find = await _illnessservice.GetIllnessWithMobile(number);
            if (find != null)
            {
                if (_visitservice.AddVisitTimeWebService(timeid, doctorid, find.Id, dt) == true)
                {
                    return Json(true);
                }

            }
            return Json(false);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddVisitJudge(string number, int cost)
        {
            var findcost = await _costpersend.GetCostPersend();
            var find = await _illnessservice.GetIllnessWithMobile(number);
            if (findcost != null && find != null)
            {
                return Json(await _jvtimeservices.AddJudgeIllnessPayment(find.Id, findcost.CostJudgeVisit,""));
            }
            return Json(false);

        }


        // managment list 

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetDoctorInfo(string mobile)
        {
            return Json(await _doctorservice.GetDoctorWithMobileWebService(mobile), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetDoctorVisitList(string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _visitservice.GetAllUserVisitTimeWebservice(find.Id, DateTime.Now), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetDoctorVisitListWithDateFinishToStart(string mobile, string date)
        {
            Converter cv = new Converter();
            DateTime dt = cv.ConvertToEnglishSearchDatetimeStartToFinish(date);
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _visitservice.GetAllUserVisitTimeWebservice(find.Id, dt), JsonRequestBehavior.AllowGet);
            }
            return Json("false", JsonRequestBehavior.AllowGet);
        }


        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> UpdateDoctorInfo(int id = 0, string name = "",string bankcode="", int cityid = 0, int groupid = 0, string description = "", int cost = 0, string nezampezeshki = "", string image = "")
        {
            string imagedoctor = "";
            if (image != "")
            {
                imagedoctor = Guid.NewGuid().ToString() + ".jpg";
                string imgillnessiamge = Path.Combine(Server.MapPath("~/uploads/Doctor/"), imagedoctor);
                byte[] imageillnessBytes = Convert.FromBase64String(image);
                System.IO.File.WriteAllBytes(imgillnessiamge, imageillnessBytes);
            }

            return Json(await _doctorservice.UpdateDoctorWebservice(id, name,bankcode, cityid, groupid, nezampezeshki, cost, description, imagedoctor));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddDragDoctor(string mobile, string name, string description)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _medicineservice.AddMedicine(find.Id, name, description));
            }
            return Json("false");
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> DeleteDragDoctor(int id)
        {

            return Json(await _medicineservice.DeleteMedicine(id));

        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetDragDoctorList(string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _medicineservice.GetAllMedicine(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddQuestionDoctor(string mobile, string text)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _quesionservice.AddQuestion(find.Id, text));
            }
            return Json("false");
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> DeleteQuestionDoctor(int id)
        {
            return Json(await _quesionservice.DeleteQuestion(id));
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetQuestionDoctorList(string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _quesionservice.GetDoctorQuestionWebService(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetVisitDoctorList(string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _daydoctorservice.GetAllTimeForWebService(find.Id), JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> DeleteVisitDoctor(int id)
        {
            return Json(await _daydoctorservice.DeleteDoctorDays(id));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddVisitDoctorList(string date, string description, int count, string mobile)
        {
            var find = await _doctorservice.GetDoctorWithMobileWebService(mobile);
            if (find != null)
            {
                return Json(await _daydoctorservice.AddDayDoctorWebService(find.Id, date, description, count));
            }
            return Json("false");
        }


        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetNoskheInfo(int visitid)
        {
            return Json(await _visitservice.ShowNoskheinfoWebService(visitid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetNoskheMedicins(int visitid)
        {
            return Json(await _noskheservice.GetNoskheMedicinWebServiceFinally(visitid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetJudgeCost()
        {
            var find = await _costpersend.GetCostPersend();
            return Json(find.CostJudgeVisit.ToString(), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddToPharmacyNoskhe(int visitid)
        {
            return Json(await _visitservice.ShowNoskheToPharmacy(visitid));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> DeleteToPharmacyNoskhe(int visitid)
        {
            return Json(await _visitservice.ShowNoskheToPharmacy(visitid));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> GetIllnessdoctorMassage(int visitid)
        {
            return Json(await _illnessmassageservice.GetAllIllnessMassage(visitid));
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> GetIllnessJudgeMassage(int visitid)
        {
            return Json(await _massagejudgeservice.GetAllJudgeIllness(visitid));
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<string> SendSms(string number,string code)
        {
            SendSms sends = new SendSms();
            sends.SendSmsFunction(number, code);
            
            return "true";
        }


        //violation service
        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetViolationUser(string userid)
        {
            return Json(await _violationservice.GetViolationuserwithanswer(userid), JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<Boolean> AddViolationUser(string userid,string number,string description)
        {
            return await _violationservice.AddViolation(number,userid,description,0,"");
        }

        [System.Web.Http.HttpGet]
        public virtual async Task<ActionResult> GetZirmajmoeeInfo(string mobile,string password)
        {
            if (await _doctorservice.CheckLogin(mobile, password))
            {
                var findsms = await _doctorservice.GetDoctorValueWithMobile(mobile);
                if (findsms != null)
                {
                    return Json(await _doctorservice.ListStringDoctorMoarefzirmajmoee(findsms.Id,findsms.BusinessKey), JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Http.HttpPost]
        public virtual async Task<ActionResult> AddZirmajmoeeInfo(string mobile, string password,string code)
        {
            if (await _doctorservice.CheckLogin(mobile, password))
            {
                var finduser = await _doctorservice.GetDoctorValueWithMobile(mobile);
                if (finduser != null)
                {
                    return Json(await _doctorservice.AddDoctorMoarefWithCode(code,finduser.Id));
                }
            }
            return Json(null);
        }
        
    }
}
