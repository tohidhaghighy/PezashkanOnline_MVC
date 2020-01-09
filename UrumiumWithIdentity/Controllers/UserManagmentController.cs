using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrumiumMVC.Controllers
{
    public partial class UserManagmentController : Controller
    {
        // GET: UserManagment
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}