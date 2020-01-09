using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.DomainClasses.Entities.Setting;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;
using UrumiumMVC.ServiceLayer.Contract.SettingInterface;

namespace UrumiumWithIdentity.Controllers
{
    [Authorize]
    public partial class FooterSettingManagmentController : Controller
    {
        IFooterService _footerservice;
        ISettingService _settingservice;
        readonly IUnitOfWork _uow;
        public FooterSettingManagmentController(IFooterService footerservice, ISettingService settingservice,
            IUnitOfWork uow)
        {
            _footerservice = footerservice;
            _settingservice = settingservice;
            _uow = uow;
        }
        // GET: FooterSettingManagment
        public virtual async Task<ActionResult> Index()
        {
            return View(await _footerservice.GetFooter());
        }

        public virtual async Task<ActionResult> SettingIndex()
        {
            return View(await _settingservice.GetSetting());
        }
        [HttpPost]
        public async Task<Boolean> AddFooter(int parentid, string name)
        {
            return await _footerservice.AddFooter(new FooterItem()
            { 
                Name=name,
                ParentId=parentid
            });
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddSetting(Setting setting, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Guid.NewGuid() + file.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                file.SaveAs(path);
                setting.Icon = fileName;
            }
            await _settingservice.AddSetting(setting);
            return Redirect("SettingIndex");
        }

        [HttpPost]
        public async Task<Boolean> DeletFooter(int id)
        {
            return await _footerservice.DeleteFooter(id);
        }

    }
}