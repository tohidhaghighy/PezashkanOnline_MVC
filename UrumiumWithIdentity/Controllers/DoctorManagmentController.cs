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
using UrumiumMVC.ServiceLayer.Contract.BimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class DoctorManagmentController : Controller
    {
        ICityService _cityservices;
        IStateService _stateservices;
        IDoctorService _doctorservice;
        IGroupService _groupservice;
        IBimeDoctorService _bimedoctorservice;
        readonly IUnitOfWork _uow;

        public DoctorManagmentController(IDoctorService doctorservice, IBimeDoctorService bimedoctorservice, ICityService cityservice, IStateService stateservice,IGroupService groupservice,
           IUnitOfWork uow)
        {
            _doctorservice = doctorservice;
            _cityservices = cityservice;
            _stateservices = stateservice;
            _groupservice = groupservice;
            _bimedoctorservice = bimedoctorservice;
            _uow = uow;
        }

        // GET: DoctorManagment
        public async virtual Task<ActionResult> Index()
        {
            DoctorManagmentViewModel _doctorlist = new DoctorManagmentViewModel();
            _doctorlist.Doctors = await _doctorservice.GetAllDoctor();
            _doctorlist.Groups = await _groupservice.GetAllGroup();
            _doctorlist.States = await _stateservices.GetAllState();
            return View(_doctorlist);
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
        public virtual async Task<ActionResult> AddItem(int cityid, string name, string description,int cost,int groupid, string username, string password, HttpPostedFileBase file)
        {

            if (name != "" && description != "" && username != "" && password != "")
            {
                
                var user = new ApplicationUser { UserName = username, Email = username, RollId = 1 };
                var result = await UserManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    string imageurl = "";
                    if (file != null)
                    {
                        var fileName = Guid.NewGuid() + file.FileName;
                        var path = Path.Combine(Server.MapPath("~/uploads/Doctor/"), fileName);
                        file.SaveAs(path);
                        imageurl = fileName;
                    }
                    await _doctorservice.AddDoctor(name, "", description, cityid, imageurl, cost, false, user.Id, groupid);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _doctorservice.DeleteDoctor(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(int id, int cityid= 1, string name="", string description="",int cost=10000,Boolean spetialdoctor=true,int groupid=1,string nezampezeshkicode="", HttpPostedFileBase fileupdate=null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Doctor/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _doctorservice.UpdateDoctor(id,"", name, description, cityid, imageurl,groupid,cost,spetialdoctor,nezampezeshkicode);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItemClient(int id, string accountnumber, int cityidupdate=0, string name="", string description="", int cost=0, int groupid=0,string nezampezeshkicode="", HttpPostedFileBase fileupdate=null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Doctor/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _doctorservice.UpdateDoctor(id,accountnumber, name, description, cityidupdate, imageurl, groupid, cost, false, nezampezeshkicode);
            var finduser = await _doctorservice.GetDoctor(id);
            return Redirect("/UserMainPages/Doctor?id="+finduser.Userid);
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
                        View = this.RenderPartialViewToString("_DoctorListAjax", await _doctorservice.SearchDoctor(text))
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
            if (await _doctorservice.ChangeActive(id))
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true
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
        public virtual async Task<ActionResult> ChangeComboItemUpdate(int stateid)
        {

            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_CityComboBoxUpdate", await _cityservices.GetStateCity(stateid))
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
        public virtual async Task<ActionResult> DoctorBimeList(int id)
        {

            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_BimeListAjax", await _bimedoctorservice.GetAllInsuranceDoctor(id))
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
        public virtual async Task<ActionResult> DeleteDoctorBime(int id,int doctorid)
        {
            try
            {
                await _bimedoctorservice.DeleteInsuranceDoctor(id);
               
                    return new JsonNetResult
                    {
                        Data = new
                        {
                            success = true,
                            View = this.RenderPartialViewToString("_BimeListAjax", await _bimedoctorservice.GetAllInsuranceDoctor(doctorid))
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