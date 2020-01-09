using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class ChatSignalrController : Controller
    {
        readonly IUnitOfWork _uow;
        IFooterService _footerservice;
        public ChatSignalrController(IFooterService footerservice, IFooterService footerservice1,
            IUnitOfWork uow)
        {
            _footerservice = footerservice;
            _uow = uow;
        }
        // GET: ChatSignalr
        public virtual ActionResult Chat()
        {
            return View();
        }
    }
}