using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrumiumWithIdentity.Controllers
{
    public partial class ParvandeIllnessController : Controller
    {
        // GET: ParvandeIllness
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}