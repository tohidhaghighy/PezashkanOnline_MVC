using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrumiumWithIdentity.Controllers
{
    public partial class GalleryManagmentController : Controller
    {
        // GET: GalleryManagment
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}