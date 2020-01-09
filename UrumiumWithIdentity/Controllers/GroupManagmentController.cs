using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class GroupManagmentController : Controller
    {
        IGroupService _groupservices;
        readonly IUnitOfWork _uow;
        public GroupManagmentController(IGroupService newgroupservice, IGroupService newgroupservice1,
            IUnitOfWork uow)
        {
            _groupservices = newgroupservice;
            _uow = uow;
        }


        // GET: GroupManagment
        public async virtual Task<ActionResult> Index()
        {
            return View(await _groupservices.GetAllGroup());
        }

        [HttpPost]
        public virtual async Task<ActionResult> AddGroup(string parentid, string name, HttpPostedFileBase file)
        {
            string src = "";
            int parentidnum = Convert.ToInt32(parentid);
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Guid.NewGuid() + file.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/"), fileName);
                file.SaveAs(path);
                src = "uploads/" + fileName;
            }

            await _groupservices.AddGroup(parentidnum, name, src);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<Boolean> DeleteMenu(int id)
        {
            return await _groupservices.DeleteGroup(id);
        }

    }
}