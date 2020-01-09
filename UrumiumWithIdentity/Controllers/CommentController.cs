using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrumiumMVC.Controllers
{
    [Authorize]
    public partial class CommentController : Controller
    {
        // GET: Comment
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}