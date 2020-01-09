using DataLayer.Context;
using Microsoft.AspNet.Identity.Owin;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.JudgeManagmentViewModel;
using Microsoft.AspNet.Identity;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class JudgeManagmentController : Controller
    {
        ICityService _cityservices;
        IStateService _stateservices;
        IJudgeService _judgeservice;
        IJVTimeService _jvtimeservice;
        readonly IUnitOfWork _uow;

        public JudgeManagmentController(ICityService cityservice, IStateService stateservice, IJudgeService judgeservice, IJVTimeService jvtimeservice,
           IUnitOfWork uow)
        {
            _cityservices = cityservice;
            _stateservices = stateservice;
            _judgeservice = judgeservice;
            _jvtimeservice = jvtimeservice;
            _uow = uow;
        }

        // GET: DoctorManagment
        public async virtual Task<ActionResult> Index()
        {
            DateTime today = DateTime.Today;
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysUntilTuesday = ((int)DayOfWeek.Tuesday - (int)today.DayOfWeek + 7) % 7;
            DateTime nextTuesday = today.AddDays(daysUntilTuesday);

            JudgeListViewModel _judgelist = new JudgeListViewModel();
            _judgelist.States = await _stateservices.GetAllState();
            _judgelist.judges = await _judgeservice.GetAlljudge();
            return View(_judgelist);
        }


        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddItem(JudgeValidate jv, HttpPostedFileBase file)
        {

            if (jv.name != "" && jv.username != "" && jv.password != "" && jv.name!=null && jv.username!=null && jv.password!=null)
            {
                var user = new ApplicationUser { UserName = jv.username, Email = jv.username, RollId = 2 };
                var result = await UserManager.CreateAsync(user, jv.password);
                if (result.Succeeded)
                {
                    string imageurl = "";
                    if (file != null)
                    {
                        var fileName = Guid.NewGuid() + file.FileName;
                        var path = Path.Combine(Server.MapPath("~/uploads/Judge/"), fileName);
                        file.SaveAs(path);
                        imageurl = fileName;
                    }
                    await _judgeservice.Addjudge(jv.name, "","", jv.cityid, imageurl, user.Id);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _judgeservice.Deletejudge(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(JudgeValidate jv, HttpPostedFileBase fileupdate)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Judge/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _judgeservice.Updatejudge(jv.id,"", jv.name,"", jv.cityid, imageurl);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateJudgeInfo(int id,string accountnumber, string name="",string description="",int cityidupdate = 0, HttpPostedFileBase fileupdate=null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Judge/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _judgeservice.Updatejudge(id,accountnumber, name, description, cityidupdate, imageurl);
            return Redirect("/UserMainPages/Judge?id="+User.Identity.GetUserId());
        }

        [HttpPost]
        public virtual async Task<ActionResult> SearchItem(string text)
        {
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_JudgeListAjax", await _judgeservice.Searchjudge(text))
                    }
                };
            }
            catch (Exception)
            {

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = false
                    }
                };
            }

        }


        [HttpPost]
        public virtual async Task<ActionResult> ChangeComboItem(int stateid)
        {

            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_CityComboBox", await _cityservices.GetStateCity(stateid))
                    }
                };
            }
            catch (Exception)
            {

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = false
                    }
                };
            }

        }
        

        [HttpPost]
        public virtual async Task<ActionResult> ChangeActive(int id)
        {
            if (await _judgeservice.ChangeActive(id))
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
        public virtual async Task<ActionResult> Finishvisit(int visitid)
        {
            if (await _jvtimeservice.ChangeVisitJudgeToFalse(visitid))
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