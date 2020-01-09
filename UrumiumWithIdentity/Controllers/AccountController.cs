using DataLayer.Context;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using Microsoft.Owin;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.Common.UploadJson;
using System;
using System.IO;
using System.Collections.Generic;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;

namespace IdentitySample.Controllers
{
    public partial class AccountController : Controller
    {
        readonly IUnitOfWork _uow;
        IFooterService _footerservice;
        IPharmacyService _pharmacyservice;
        IDoctorService _doctorservice;
        IJudgeService _judgeservice;
        IStateService _stateservice;
        IIllnessService _illnessservice;
        IBimeService _bimeservice;
        IGroupService _groupservice;

        public AccountController(IPharmacyService pharmacyservice, IGroupService groupservice, IBimeService bimeservice, IDoctorService doctorservice, IJudgeService judgeservice, IIllnessService illnessservice, IStateService stateservice,
            IUnitOfWork uow)
        {
            _pharmacyservice = pharmacyservice;
            _judgeservice = judgeservice;
            _doctorservice = doctorservice;
            _illnessservice = illnessservice;
            _stateservice = stateservice;
            _groupservice = groupservice;
            _bimeservice = bimeservice;
            _uow = uow;
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, string s)
        {
            UserManager = userManager;
            SignInManager = signInManager;
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

        public virtual ActionResult TaiideModir()
        {
            return View();
        }
        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async virtual Task<ActionResult> Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var find = UserManager.Users.Where(a => a.UserName == User.Identity.Name).FirstOrDefault();
                if (find != null && find.EmailConfirmed == true)
                {
                    if (find.RollId == 1)
                    {
                        return RedirectToLocal("/UserMainPages/Doctor?id=" + find.Id);
                    }
                    else if (find.RollId == 2)
                    {
                        return RedirectToLocal("/UserMainPages/Judge?id=" + find.Id);
                    }
                    else if (find.RollId == 3)
                    {
                        return RedirectToLocal("/UserMainPages/Illness?id=" + find.Id);
                    }
                    else if (find.RollId == 4)
                    {
                        return RedirectToLocal("/UserMainPages/Pharmacy?id=" + find.Id);
                    }
                    else if (find.RollId == 5)
                    {
                        return RedirectToLocal("/Managment/Index?id=" + find.Id);
                    }
                }

                return RedirectToLocal("/Account/LoginMain");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async virtual Task<ActionResult> LoginMain(string returnUrl)
        {
            return View("Login");
        }


        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult LoginManagment(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                var find = UserManager.Users.Where(a => a.UserName == User.Identity.Name).FirstOrDefault();
                if (find != null && find.EmailConfirmed == true)
                {
                    if (find.RollId == 5)
                    {
                        return RedirectToLocal("/Managment/Index?id=" + find.Id);
                    }
                }
                return RedirectToLocal("/DoctorHome/Index");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        private ApplicationSignInManager _signInManager;

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set { _signInManager = value; }
        }

        //
        // POST: /Account/Login
        [HttpPost]
        public virtual async Task<ActionResult> Login(string Email, string Password, int rollid = 0)
        {
            LoginViewModel modeltest = new LoginViewModel();
            modeltest.Email = Email;
            modeltest.Password = Password;
            if (Email == "" || Password == "")
            {
                return View(modeltest);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(Email, Password, true, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        var find = UserManager.Users.Where(a => a.UserName == Email).FirstOrDefault();
                        if (find != null && find.EmailConfirmed == true)
                        {
                            if (find.RollId == 1)
                            {
                                return RedirectToLocal("/UserMainPages/Doctor?id=" + find.Id);
                            }
                            else if (find.RollId == 2)
                            {
                                return RedirectToLocal("/UserMainPages/Judge?id=" + find.Id);
                            }
                            else if (find.RollId == 3)
                            {
                                return RedirectToLocal("/UserMainPages/Illness?id=" + find.Id);
                            }
                            else if (find.RollId == 4)
                            {
                                return RedirectToLocal("/UserMainPages/Pharmacy?id=" + find.Id);
                            }
                            else if (find.RollId == 5)
                            {
                                return RedirectToLocal("/Managment/Index?id=" + find.Id);
                            }
                        }

                        return RedirectToLocal("/DoctorHome/Index");
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");

                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "همچین کاربری موجود نمیباشد");
                    return View(modeltest);
            }

        }

        [HttpPost]
        public virtual async Task<ActionResult> LoginMobile(string Mobilesms, string Passwordsms, int rollidsms = 0)
        {
            if (Mobilesms != "" && Passwordsms != "")
            {
                if (rollidsms == 1)
                {
                    var find = await _doctorservice.CheckLoginWithMobile(Mobilesms, Passwordsms);
                    if (find != null)
                    {
                        return RedirectToLocal("/UserMainPages/Doctor?id=" + find.Userid);
                    }

                }
                else if (rollidsms == 2)
                {
                    var find = await _judgeservice.CheckLoginwithmobile(Mobilesms, Passwordsms);
                    if (find != null)
                    {
                        return RedirectToLocal("/UserMainPages/Judge?id=" + find.Userid);
                    }
                }
                else if (rollidsms == 3)
                {
                    var find = await _illnessservice.CheckLoginwithmobile(Mobilesms, Passwordsms);
                    if (find != null)
                    {
                        return RedirectToLocal("/UserMainPages/Illness?id=" + find.Userid);
                    }
                }
                else if (rollidsms == 4)
                {
                    var find = await _pharmacyservice.CheckLoginwithmobile(Mobilesms, Passwordsms);
                    if (find != null)
                    {
                        return RedirectToLocal("/UserMainPages/Pharmacy?id=" + find.Userid);
                    }
                }
            }
            return RedirectToLocal("/Account/Login");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> LoginManagment(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // This doen't count login failures towards lockout only two factor authentication
            // To enable password failures to trigger lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {
                case SignInStatus.Success:
                    {
                        var find = UserManager.Users.Where(a => a.UserName == model.Email).FirstOrDefault();
                        if (find != null && find.EmailConfirmed == true)
                        {
                            //var code = await UserManager.GenerateEmailConfirmationTokenAsync(find.Id);
                            //var results = await UserManager.ConfirmEmailAsync(find.Id, code);
                           
                            if (find.RollId == 5)
                            {
                                return RedirectToLocal("/Managment/Index?id=" + find.Id);
                            }
                        }
                        return RedirectToLocal("/DoctorHome/Index");
                    }
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "همچین کاربری موجود نمیباشد");
                    return View(model);
            }

        }
        //
        // GET: /Account/VerifyCode
        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Require that the user has already logged in via username/password or external login
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            var user = await UserManager.FindByIdAsync(await SignInManager.GetVerifiedUserIdAsync());
            if (user != null)
            {
                ViewBag.Status = "For DEMO purposes the current " + provider + " code is: " + await UserManager.GenerateTwoFactorTokenAsync(user.Id, provider);
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "کد نا معتبر");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public async virtual Task<ActionResult> Register()
        {
            RegisterViewModel reglist = new RegisterViewModel();
            if (User.Identity.IsAuthenticated)
            {
                var find = UserManager.Users.Where(a => a.UserName == User.Identity.Name).FirstOrDefault();
                if (find != null && find.EmailConfirmed == true)
                {
                    //var code = await UserManager.GenerateEmailConfirmationTokenAsync(find.Id);
                    //var results = await UserManager.ConfirmEmailAsync(find.Id, code);
                    if (find.RollId == 1)
                    {
                        return RedirectToLocal("/UserMainPages/Doctor?id=" + find.Id);
                    }
                    else if (find.RollId == 2)
                    {
                        return RedirectToLocal("/UserMainPages/Judge?id=" + find.Id);
                    }
                    else if (find.RollId == 3)
                    {
                        return RedirectToLocal("/UserMainPages/Illness?id=" + find.Id);
                    }
                    else if (find.RollId == 4)
                    {
                        return RedirectToLocal("/UserMainPages/Pharmacy?id=" + find.Id);
                    }
                    else if (find.RollId == 5)
                    {
                        return RedirectToLocal("/Managment/Index?id=" + find.Id);
                    }
                }
                return RedirectToLocal("/DoctorHome/Index");
            }
            reglist.States = await _stateservice.GetAllState();
            return View(reglist);
        }


        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> Register(RegisterViewModel model, int rollid = 0, int cityid = 0, string Code = "", HttpPostedFileBase filecartmelli = null, HttpPostedFileBase fileshenasname = null, HttpPostedFileBase filenezampezeshki = null, HttpPostedFileBase fileparvane = null, HttpPostedFileBase filemadraketahsili = null)
        {

            if (ModelState.IsValid && cityid != 0)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, RollId = rollid };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    switch (rollid)
                    {
                        //doctor
                        case 1:
                            List<string> allfile = addimagetodoctor(filecartmelli, fileshenasname, filenezampezeshki);
                            var findgroup = await _groupservice.GetFirstGroup();
                            if (findgroup != null)
                            {
                                int id = await _doctorservice.AddDoctorMadrak(user.UserName, "", "", cityid, "", 0, false, user.Id, findgroup.Id, allfile[0], allfile[1], allfile[2]);
                                await _doctorservice.AddDoctorMoarefWithCode(Code, id);
                            }

                            break;
                        //judge
                        case 2:
                            List<string> alljudgefile = addimagetojudge(filecartmelli, fileshenasname, filemadraketahsili);
                            await _judgeservice.AddjudgeMadrak(user.UserName, "", "", cityid, "", user.Id, alljudgefile[0], alljudgefile[1], alljudgefile[2]);
                            break;
                        //illness
                        case 3:
                            var findbime = await _bimeservice.GetFirstInsurance();
                            if (findbime != null)
                            {
                                await _illnessservice.AddIllness(user.UserName, "", cityid, "", user.Id, 0, 0, 0, 0, "", findbime.Id);
                            }
                            break;
                        //pharmacy
                        case 4:
                            List<string> allpharmacyfile = addimagetopharmacy(filecartmelli, fileshenasname, filenezampezeshki, fileparvane);
                            await _pharmacyservice.AddPharmacyMadrak(user.UserName, "", cityid, "", user.Id, "", allpharmacyfile[0], allpharmacyfile[1], allpharmacyfile[3], allpharmacyfile[2]);
                            break;
                        default:
                            break;
                    }
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "تایید اکانت", "لطفا برای فعال سازی روی لینک روبرو کلیک کنید: <a href=\"" + callbackUrl + "\">لینک</a>");
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                AddErrors(result);
            }
            model.States = await _stateservice.GetAllState();
            // If we got this far, something failed, redisplay form
            return View(model);
        }


        [HttpPost]
        public virtual async Task<ActionResult> RegisterMobile(string Mobilesms="", string Passwordsms="", string rePasswordsms="", int rollid=0, int cmbstate=0, int cityid=0, string Code = "", HttpPostedFileBase filecartmelli = null, HttpPostedFileBase fileshenasname = null, HttpPostedFileBase filenezampezeshki = null, HttpPostedFileBase fileparvane = null, HttpPostedFileBase filemadraketahsili = null)
        {
            if (Passwordsms == rePasswordsms && Mobilesms != "" && Mobilesms.Length == 11)
            {
                switch (rollid)
                {
                    //doctor
                    case 1:
                        if (filecartmelli != null && fileshenasname != null && filenezampezeshki != null)
                        {
                            List<string> allfile = addimagetodoctor(filecartmelli, fileshenasname, filenezampezeshki);
                            var findgroup = await _groupservice.GetFirstGroup();
                            if (findgroup != null)
                            {
                                int id = await _doctorservice.AddDoctorMadrakWithMobile(Passwordsms,Mobilesms,Mobilesms, "", "", cityid, "", 0, false, Mobilesms, findgroup.Id, allfile[0], allfile[1], allfile[2]);
                                await _doctorservice.AddDoctorMoarefWithCode(Code, id);
                                return RedirectToLocal("/UserMainPages/Doctor?id=" + Mobilesms);
                            }

                        }

                        break;
                    //judge
                    case 2:
                        if (filecartmelli!=null && fileshenasname!=null && filemadraketahsili!=null)
                        {
                            List<string> alljudgefile = addimagetojudge(filecartmelli, fileshenasname, filemadraketahsili);
                            await _judgeservice.AddjudgeMadrakWithMobile(Passwordsms,Mobilesms,Mobilesms, "", "", cityid, "", Mobilesms, alljudgefile[0], alljudgefile[1], alljudgefile[2]);
                            return RedirectToLocal("/UserMainPages/Judge?id=" + Mobilesms);
                        }
                        
                        break;
                    //illness
                    case 3:
                        var findbime = await _bimeservice.GetFirstInsurance();
                        if (findbime != null)
                        {
                            await _illnessservice.AddIllnesswithmobile(Passwordsms,Mobilesms,Mobilesms, "", cityid, "", Mobilesms, 0, 0, 0, 0, "", findbime.Id);
                            return RedirectToLocal("/UserMainPages/Illness?id=" + Mobilesms);
                        }
                        break;
                    //pharmacy
                    case 4:
                        if (filecartmelli!=null && fileshenasname!=null && fileparvane!=null && filenezampezeshki!=null)
                        {
                            List<string> allpharmacyfile = addimagetopharmacy(filecartmelli, fileshenasname, filenezampezeshki, fileparvane);
                            await _pharmacyservice.AddPharmacyMadrakwithmobile(Passwordsms,Mobilesms,Mobilesms, "", cityid, "", Mobilesms, "", allpharmacyfile[0], allpharmacyfile[1], allpharmacyfile[3], allpharmacyfile[2]);
                            return RedirectToLocal("/UserMainPages/Pharmacy?id=" + Mobilesms);
                        }
                        break;
                    default:
                        break;
                }

            }

            return RedirectToLocal("/Account/Register");
        }

        public List<string> addimagetodoctor(HttpPostedFileBase cartemelli, HttpPostedFileBase shenasname, HttpPostedFileBase nezam)
        {
            List<string> files = new List<string>();
            if (cartemelli != null)
            {
                var fileName = Guid.NewGuid() + cartemelli.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Doctor/m/"), fileName);
                cartemelli.SaveAs(path);
                files.Add(fileName);
            }
            if (shenasname != null)
            {
                var fileName = Guid.NewGuid() + shenasname.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Doctor/s/"), fileName);
                shenasname.SaveAs(path);
                files.Add(fileName);
            }
            if (nezam != null)
            {
                var fileName = Guid.NewGuid() + nezam.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Doctor/n/"), fileName);
                nezam.SaveAs(path);
                files.Add(fileName);
            }
            return files;
        }

        public List<string> addimagetojudge(HttpPostedFileBase cartemelli, HttpPostedFileBase shenasname, HttpPostedFileBase madrak)
        {
            List<string> files = new List<string>();
            if (cartemelli != null)
            {
                var fileName = Guid.NewGuid() + cartemelli.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Judge/m/"), fileName);
                cartemelli.SaveAs(path);
                files.Add(fileName);
            }
            if (shenasname != null)
            {
                var fileName = Guid.NewGuid() + shenasname.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Judge/s/"), fileName);
                shenasname.SaveAs(path);
                files.Add(fileName);
            }
            if (madrak != null)
            {
                var fileName = Guid.NewGuid() + madrak.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Judge/madrak/"), fileName);
                madrak.SaveAs(path);
                files.Add(fileName);
            }
            return files;
        }

        public List<string> addimagetopharmacy(HttpPostedFileBase cartemelli, HttpPostedFileBase shenasname, HttpPostedFileBase nezam, HttpPostedFileBase parvane)
        {
            List<string> files = new List<string>();
            if (cartemelli != null)
            {
                var fileName = Guid.NewGuid() + cartemelli.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/m/"), fileName);
                cartemelli.SaveAs(path);
                files.Add(fileName);
            }
            if (shenasname != null)
            {
                var fileName = Guid.NewGuid() + shenasname.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/s/"), fileName);
                shenasname.SaveAs(path);
                files.Add(fileName);
            }
            if (nezam != null)
            {
                var fileName = Guid.NewGuid() + nezam.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/n/"), fileName);
                nezam.SaveAs(path);
                files.Add(fileName);
            }
            if (parvane != null)
            {
                var fileName = Guid.NewGuid() + parvane.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Pharmacy/p/"), fileName);
                parvane.SaveAs(path);
                files.Add(fileName);
            }
            return files;
        }

        public bool AddUsertodb(ApplicationUser user, int rollid)
        {
            if (rollid == 1)
            {

                return true;
            }
            else if (rollid == 2)
            {

                return true;
            }
            else if (rollid == 3)
            {

                return true;
            }
            else if (rollid == 4)
            {

                return true;
            }
            return false;
        }
        //
        // GET: /Account/ConfirmEmail
        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // GET: /Account/ForgotPassword
        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult ForgotPassword()
        {
            return View();
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return View("Login");
                }

                var code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Reset Password", "Please reset your password by clicking here: <a href=\"" + callbackUrl + "\">link</a>");
                ViewBag.Link = callbackUrl;
                return View("Login");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult ResetPassword(string code)
        {
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Generate the token and send it
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public virtual async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {
            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl });
                case SignInStatus.Failure:
                default:
                    // If the user does not have an account, then prompt the user to create an account
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public virtual async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "DoctorHome");
        }

        //
        // GET: /Account/ExternalLoginFailure
        [HttpGet]
        [AllowAnonymous]
        public virtual ActionResult ExternalLoginFailure()
        {
            return View();
        }

        public virtual ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddnewPasswordAsync(string id, string oldpass, string newpass, string renewpass)
        {
            if (newpass==renewpass && oldpass!="" && newpass!="")
            {
                ApplicationUser user = await UserManager.FindByIdAsync(id);
                if (user == null)
                {
                    return RedirectToLocal("/Account/ChangePassword?id="+id);
                }
                if (await UserManager.CheckPasswordAsync(user, oldpass))
                {
                    user.PasswordHash = UserManager.PasswordHasher.HashPassword(newpass);
                    var result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return View();
                    }
                    return View();
                }
                
            }
            return RedirectToLocal("/Account/ChangePassword?id=" + id);
        }

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}