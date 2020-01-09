using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class CostPersendManagmentController : Controller
    {
        ICostPersendService _costpersendservices;
        readonly IUnitOfWork _uow;
        public CostPersendManagmentController(ICostPersendService newcostpersendservice, ICostPersendService newstateservice,
            IUnitOfWork uow)
        {
            _costpersendservices = newcostpersendservice;
            _uow = uow;
        }
        // GET: CostPersendManagment
        public async virtual Task<ActionResult> Index()
        {
            return View(await _costpersendservices.GetCostPersend());
        }

        public async virtual Task<ActionResult> AddCost(int PersendPerVisit, int ZirMajmoeVisitDoctor,int CostJudgeVisit)
        {
            await _costpersendservices.AddCostPersend(PersendPerVisit, ZirMajmoeVisitDoctor, CostJudgeVisit);
            return RedirectToAction("Index");
        }
    }
}