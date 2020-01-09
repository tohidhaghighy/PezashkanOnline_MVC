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
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class IllnessManagmentController : Controller
    {
        ICityService _cityservices;
        IStateService _stateservices;
        IIllnessService _illnessservice;
        IBimeService _bimeservice;
        readonly IUnitOfWork _uow;

        public IllnessManagmentController(ICityService cityservice, IStateService stateservice, IIllnessService illnessservice,IBimeService bimeservice,
           IUnitOfWork uow)
        {
            _cityservices = cityservice;
            _stateservices = stateservice;
            _illnessservice = illnessservice;
            _bimeservice = bimeservice;
            _uow = uow;
        }

        // GET: DoctorManagment
        public async virtual Task<ActionResult> Index()
        {
            IllnessListViewModel _illnesslist = new IllnessListViewModel();
            _illnesslist.States = await _stateservices.GetAllState();
            _illnesslist.Illnesses = await _illnessservice.GetAllillness();
            _illnesslist.Insurances = await _bimeservice.GetAllInsurance();
            return View(_illnesslist);
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
        public virtual async Task<ActionResult> AddItem(int cityid=0,int age=0,int weight=0,int suger=0,int pressure=0,string serialbime="", string name="",int bimeid=1, string username="", string password="", HttpPostedFileBase file=null)
        {

            if (name != "" && username != "" && password != "" && cityid!=0)
            {
                var user = new ApplicationUser { UserName = username, Email = username, RollId = 3 };
                var result = await UserManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    string imageurl = "";
                    if (file != null)
                    {
                        var fileName = Guid.NewGuid() + file.FileName;
                        var path = Path.Combine(Server.MapPath("~/uploads/Illness/"), fileName);
                        file.SaveAs(path);
                        imageurl = fileName;
                    }
                    await _illnessservice.AddIllness(name, "", cityid, imageurl, user.Id,age,weight,suger,pressure,serialbime,bimeid);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _illnessservice.Deleteillness(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(int id, int cityid=1, string name="", int age=0, int weight=0, int suger=0, int pressure=0, string serialbime="", int bimeid=0, HttpPostedFileBase fileupdate=null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Illness/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _illnessservice.Updateillness(id, name, cityid, imageurl, age, weight, suger, pressure, serialbime, bimeid);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItemClient(int id, int cityidupdate=0, string name="", int age=0, int weight=0, int suger=0, int pressure=0, string serialbime="", int bimeid=0,string date="", HttpPostedFileBase fileupdate=null, HttpPostedFileBase fileBime = null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Illness/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }
            string imageurlbimefirstpage = "";
            if (fileBime != null)
            {
                var fileName = Guid.NewGuid() + fileBime.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Illness/"), fileName);
                fileBime.SaveAs(path);
                imageurl = fileName;
            }
            await _illnessservice.UpdateillnessWithDate(id, name, cityidupdate, imageurl,imageurlbimefirstpage, age, weight, suger, pressure, serialbime, bimeid,date);
            var finduser = await _illnessservice.GetillnessClient(id);
            return Redirect("/UserMainPages/Illness?id=" + finduser.Userid);
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
                        View = this.RenderPartialViewToString("_IllnessListAjax", await _illnessservice.Searchillness(text))
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

    }
}