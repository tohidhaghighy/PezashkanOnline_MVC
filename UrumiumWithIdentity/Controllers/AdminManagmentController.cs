using DataLayer.Context;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.DomainClasses.Entities.Admin;
using UrumiumMVC.ServiceLayer.Contract.AdminInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class AdminManagmentController : Controller
    {
        IAdminService _adminservice;
        readonly IUnitOfWork _uow;

        public AdminManagmentController(IAdminService adminservice, IAdminService insuranceservice,
           IUnitOfWork uow)
        {
            _adminservice = adminservice;
            _uow = uow;
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

        public async virtual Task<ActionResult> Index()
        {
            return View(await _adminservice.GetAllAdmin());
        }


        [HttpPost]
        public virtual async Task<ActionResult> AddItem(string username, string password, string Name, bool AdminManagment = false, bool DoctorManagment = false, bool IllnessManagment = false, bool JudgeManagment = false, bool PharmacyManagment = false, bool CommonManagment = false, bool UserManagment = false, bool MedicineManagment = false, bool AccountManagment = false)
        {
            if (Name != "")
            {
                //Boolean i1 = Convert.ToBoolean(AdminManagment);
                //int userid = 0;
                var user = new ApplicationUser { UserName = username, Email = username, RollId = 5 };
                var result = await UserManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await _adminservice.AddAdmin(Name, DoctorManagment, IllnessManagment, JudgeManagment, CommonManagment, AccountManagment, MedicineManagment, PharmacyManagment, UserManagment, AdminManagment, user.Id);
                }
                var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                var resultconfirm = await UserManager.ConfirmEmailAsync(user.Id, code);

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _adminservice.DeleteAdmin(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> GetAdmin(string userid)
        {
            var find = await _adminservice.GetAdmin(userid);
            return new JsonNetResult
            {
                Data = new
                {
                    DoctorManagment = find.DoctorManagment,
                    IllnessManagment = find.IllnessManagment,
                    JudgeManagment = find.JudgeManagment,
                    AdminManagment = find.AdminManagment,
                    PharmacyManagment = find.PharmacyManagment,
                    CommonManagment = find.CommonManagment,
                    UserManagment = find.UserManagment,
                    MedicineManagment = find.MedicineManagment,
                    AccountManagment = find.AccountManagment
                }
            };
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(int id, string Name, bool AdminManagment = false, bool DoctorManagment = false, bool IllnessManagment = false, bool JudgeManagment = false, bool PharmacyManagment = false, bool CommonManagment = false, bool UserManagment = false, bool MedicineManagment = false, bool AccountManagment = false)
        {
            await _adminservice.UpdateAdmin(id, Name, DoctorManagment, IllnessManagment, JudgeManagment, CommonManagment, AccountManagment, MedicineManagment, PharmacyManagment, UserManagment, AdminManagment);
            return RedirectToAction("Index");
        }

    }
}