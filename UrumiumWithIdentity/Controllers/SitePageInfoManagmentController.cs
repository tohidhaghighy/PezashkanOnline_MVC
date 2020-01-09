using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.SettingInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class SitePageInfoManagmentController : Controller
    {
        ISitePageInfoService _sitepageinfoservice;
        readonly IUnitOfWork _uow;
        public SitePageInfoManagmentController(ISitePageInfoService sitepageinfoservice, ISitePageInfoService sitepageinfoservice1,
            IUnitOfWork uow)
        {
            _sitepageinfoservice = sitepageinfoservice;
            _uow = uow;
        }


        // GET: SitePageInfoManagment
        public async virtual Task<ActionResult> Index()
        {
            return View(await _sitepageinfoservice.GetSitePageInfo());
        }

        [HttpPost]
        public async virtual Task<ActionResult> AddPageinfo(string aboutus, string siteroll, string coorporatewithus)
        {
            await _sitepageinfoservice.AddSitePagesInfo(aboutus, siteroll, coorporatewithus);
            return RedirectToAction("Index");
        }
    }
}