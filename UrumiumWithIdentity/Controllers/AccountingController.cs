using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.JVTimeInterface;
using UrumiumMVC.ServiceLayer.Contract.TicketInterface;
using UrumiumMVC.ServiceLayer.Contract.VisitInterface;
using UrumiumMVC.ViewModel.EntityViewModel.AccountingViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class AccountingController : Controller
    {
        IVisitService _visitservices;
        IJVTimeService _judgevisitservice;
        readonly IUnitOfWork _uow;

        public AccountingController(IVisitService newvisitservice, IJVTimeService newjudgeservice,
            IUnitOfWork uow)
        {
            _visitservices = newvisitservice;
            _judgevisitservice = newjudgeservice;
            _uow = uow;
        }
        // GET: Accounting
        public virtual async Task<ActionResult> Index()
        {
            AccountingMainData newAccounting = new AccountingMainData();
            newAccounting.VisitCost = "0";
            newAccounting.VisitCount = "0";
            newAccounting.VisitList = null;
            return View(newAccounting);
        }

        [HttpPost]
        public virtual async Task<ActionResult> SearchValue(string start, string finish, int rollid)
        {
            AccountingMainData newAccounting = new AccountingMainData();
            if (start != "" && finish != "")
            {
                Converter cv = new Converter();
                DateTime startdt = cv.ConvertDatetoenglishforsearchaccounting(start);
                DateTime finishdt = cv.ConvertDatetoenglishforsearchaccounting(finish);
                if (rollid == 2)
                {
                    var find = await _judgevisitservice.GetAllJudgetimeforaccounting(startdt, finishdt);
                    int paycount = 0;
                    foreach (var item in find)
                    {
                        paycount += Convert.ToInt32(item.Cost);
                    }
                    newAccounting.VisitList = find;
                    newAccounting.VisitCost = paycount.ToString();
                    newAccounting.VisitCount = find.Count() + "";
                }
                else if (rollid == 1)
                {
                    var find = await _visitservices.Getallvisittimelist(startdt, finishdt);
                    int paycount = 0;
                    foreach (var item in find)
                    {
                        paycount += Convert.ToInt32(item.Cost);
                    }
                    newAccounting.VisitList = find;
                    newAccounting.VisitCost = paycount.ToString();
                    newAccounting.VisitCount = find.Count() + "";
                }

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_Accountinglist", newAccounting)
                    }
                };

            }
            newAccounting.VisitList = null;
            newAccounting.VisitCost = "0";
            newAccounting.VisitCount = "0";
            return new JsonNetResult
            {
                Data = new
                {
                    success = true,
                    View = this.RenderPartialViewToString("_Accountinglist", newAccounting)
                }
            };
            return View(newAccounting);
        }
    }
}