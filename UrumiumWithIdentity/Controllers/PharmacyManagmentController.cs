using DataLayer.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.Cryptography;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class PharmacyManagmentController : Controller
    {
        IPharmacyService _pharmacyservices;
        ICityService _cityservices;
        IStateService _stateservices;
        readonly IUnitOfWork _uow;
        public PharmacyManagmentController(IPharmacyService newpharmacyservice, ICityService newcityservice, IStateService newstateservice,
            IUnitOfWork uow)
        {
            _pharmacyservices = newpharmacyservice;
            _cityservices = newcityservice;
            _stateservices = newstateservice;
            _uow = uow;
        }
        
        // GET: PharmacyManagment
        public async virtual Task<ActionResult> Index()
        {
            var pharmacylist = new PharmacyVM()
            {
                Cities = await _cityservices.GetAllCity(),
                States = await _stateservices.GetAllState(),
                Pharmacies = await _pharmacyservices.GetAllPharmacy()
            };
            return View(pharmacylist);
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
        public virtual async Task<ActionResult> AddItem(int cityid, string name, string description, string username, string password, HttpPostedFileBase file)
        {
            var user = new ApplicationUser { UserName = username, Email = username, RollId = 4 };
            var result = await UserManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                if (name != "" && description != "" && username != "" && password != "")
                {
                    string imageurl = "";
                    if (file != null)
                    {
                        var fileName = Guid.NewGuid() + file.FileName;
                        var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/"), fileName);
                        file.SaveAs(path);
                        imageurl = fileName;
                    }


                    await _pharmacyservices.AddPharmacy(name, description, cityid, imageurl, user.Id,"");

                }
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _pharmacyservices.DeletePharmacy(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(int id, int cityid, string name, string description, HttpPostedFileBase fileupdate)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _pharmacyservices.UpdatePharmacy(id, name, description, cityid, imageurl,"");
            return RedirectToAction("Index");
        }

        public virtual async Task<ActionResult> UpdateItemClient(int pharmacyid=0, int cityidupdate = 0, string name="", string description="",string address="", HttpPostedFileBase fileupdate=null)
        {
            if (pharmacyid!=0 && cityidupdate != 0 && name!="")
            {
                string imageurl = "";
                if (fileupdate != null)
                {
                    var fileName = Guid.NewGuid() + fileupdate.FileName;
                    var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/"), fileName);
                    fileupdate.SaveAs(path);
                    imageurl = fileName;
                }

                await _pharmacyservices.UpdatePharmacy(pharmacyid, name, description, cityidupdate, imageurl,address);
                return Redirect("/UserMainPages/Pharmacy?id=" + User.Identity.GetUserId());
            }
            return Redirect("/UserMainPages/Pharmacy?id=" + User.Identity.GetUserId());
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
                        View = this.RenderPartialViewToString("_PharmacyListAjax", await _pharmacyservices.SearchPharmacy(text))
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
                        View = this.RenderPartialViewToString("_CityComboPharmacy", await _cityservices.GetStateCity(stateid))
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
            if (await _pharmacyservices.ChangeActive(id))
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