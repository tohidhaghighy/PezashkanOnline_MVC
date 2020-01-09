using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.MenuInterface;

namespace UrumiumWithIdentity.Controllers
{
    [Authorize]
    public partial class MenuManagmentController : Controller
    {
        IMenuService _menuservices;
        readonly IUnitOfWork _uow;
        public MenuManagmentController(IMenuService newmenuservice, IMenuService newgroupservice1,
            IUnitOfWork uow)
        {
            _menuservices = newmenuservice;
            _uow = uow;
        }


        // GET: MenuManagment
        public async virtual Task<ActionResult> Index()
        {
            return View(await _menuservices.GetAllMenu());
        }


        [HttpPost]
        public async Task<Boolean> AddMenu(int parentid,string name)
        {

            return await _menuservices.AddMenu(parentid, name);
        }


        [HttpPost]
        public async Task<Boolean> DeleteMenu(int id)
        {
            return await _menuservices.DeleteMenu(id);
        }

        
    }
}