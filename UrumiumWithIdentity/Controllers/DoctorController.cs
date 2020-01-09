using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.TimeDateDrInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class DoctorController : Controller
    {
        // GET: GroupManagment
        public virtual ActionResult Index()
        {
            return View();
        }

        
    }
}